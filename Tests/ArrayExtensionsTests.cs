using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

#pragma warning disable xUnit1019 // https://github.com/xunit/xunit/issues/1897

namespace AshMind.Extensions.Tests {
    public class ArrayExtensionsTests {
        [Theory]
        [MemberData(nameof(ActionMethods))]
        public void TestAction(Expression<Action<int[]>> extensionMethod, Expression<Action<int[]>> builtInMethod) {
            var arrayForExtensionMethod = new[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };
            var arrayForBuiltInMethod = arrayForExtensionMethod.ToArray();

            extensionMethod.Compile().Invoke(arrayForExtensionMethod);
            builtInMethod.Compile().Invoke(arrayForBuiltInMethod);

            Assert.Equal(arrayForBuiltInMethod, arrayForExtensionMethod);
        }

        [Theory]
        [MemberData(nameof(FunctionMethods))]
        public void TestFunction(Expression<Func<int[], object>> extensionMethod, Expression<Func<int[], object>> builtInMethod) {
            var array = new[] { 5, 4, 3, 2, 1, 2, 3, 4, 5 };

            var builtInResult = builtInMethod.Compile().Invoke(array);
            var extensionResult = extensionMethod.Compile().Invoke(array);

            Assert.Equal(builtInResult, extensionResult);
        }

        public static IEnumerable<object[]> ActionMethods {
            get { return GetMethods<Action<int[]>>(m => m.ReturnType == typeof(void)); }
        }

        public static IEnumerable<object[]> FunctionMethods {
            get { return GetMethods<Func<int[], object>>(m => m.ReturnType != typeof(void)); }
        }

        private static IEnumerable<object[]> GetMethods<TDelegate>(Func<MethodInfo, bool> filter) {
            var extensionMethods = typeof(ArrayExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static).Where(filter);
            var arrayMethods = typeof(Array).GetMethods();
            foreach (var method in extensionMethods) {
                var arrayMethod = arrayMethods.Where(m => Matches(m, method))
                                              .OrderByDescending(m => m.IsGenericMethodDefinition ? 1 : 0)
                                              .First();

                yield return new object[] { MakeCall<TDelegate>(method), MakeCall<TDelegate>(arrayMethod) };
            }
        }

        private static Expression<TDelegate> MakeCall<TDelegate>(MethodInfo method) {
            if (method.IsGenericMethodDefinition)
                method = method.MakeGenericMethod(typeof(int));

            var arrayParameter = Expression.Parameter(typeof(int[]), "array");
            var body = (Expression)Expression.Call(null, method, GuessArguments(method, arrayParameter));
            if (body.Type.IsValueType && body.Type != typeof(void))
                body = Expression.Convert(body, typeof(object));

            return Expression.Lambda<TDelegate>(body, arrayParameter);
        }

        private static IEnumerable<Expression> GuessArguments(MethodInfo method, ParameterExpression arrayParameter) {
            yield return arrayParameter;
            foreach (var parameter in method.GetParameters().Skip(1)) {
                yield return GuessArgumentValue(parameter);
            }
        }

        private static Expression GuessArgumentValue(ParameterInfo parameter) {
            if (parameter.Name.EndsWith("index", StringComparison.InvariantCultureIgnoreCase))
                return Expression.Constant(4);

            if (parameter.Name == "count" || parameter.Name == "length")
                return Expression.Constant(3);

            if (parameter.Name == "value")
                return Expression.Constant(4);

            if (parameter.ParameterType == typeof(Comparison<int>))
                return Expression.Constant((Comparison<int>) ((a, b) => a.CompareTo(b)));

            if (parameter.ParameterType == typeof(IComparer<int>))
                return Expression.Constant(Comparer<int>.Default, parameter.ParameterType);

            return Expression.Constant(null, parameter.ParameterType);
        }

        private static bool Matches(MethodInfo method, MethodInfo other) {
            return method.Name == other.Name
                && method.ReturnType == other.ReturnType
                && Enumerable.SequenceEqual(
                       method.GetParameters().Select(p => p.Name),
                       other.GetParameters().Select(p => p.Name)
                   );
        }
    }
}
