using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using AshMind.Constructs.Interfaces;

namespace AshMind.Constructs
{
    static partial class Switch
    {
        #region CaseBuilder<TBase> Class

        private class CaseBuilder<TBase, TResult> : IExpressionSwitchCase<TBase, TResult>
            where TBase : class
        {
            #region ExpressionCase class

            private struct ExpressionCase
            {
                public Type CaseType { get; private set; }
                public Expression Expression { get; private set; }

                public ExpressionCase(Type caseType, Expression expression) : this()
                {
                    this.CaseType = caseType;
                    this.Expression = expression;
                }
            }

            #endregion

            private const string SwitchParameterName = "x";
            private static readonly ParameterExpression SwitchParameter = Expression.Parameter(typeof(TBase), SwitchParameterName);
            
            private readonly List<ExpressionCase> m_cases = new List<ExpressionCase>();
            private Expression m_result = Expression.Constant(default(TResult));

            private IExpressionSwitchCase<TBase, TResult> Case<TCase>(Expression expression)
                where TCase : class, TBase
            {
                m_cases.Add(new ExpressionCase(typeof(TCase), expression));
                return this;
            }

            public IExpressionSwitchCase<TBase, TResult> Case<TCase>(Expression<Func<TCase, TResult>> func)
                where TCase : class, TBase
            {
                var invoke = Expression.Invoke(
                    func, Expression.TypeAs(SwitchParameter, typeof(TCase))
                );
                return this.Case<TCase>(invoke);
            }

            public IExpressionSwitchCase<TBase, TResult> Case<TCase>(TResult result)
                where TCase : class, TBase
            {
                return this.Case<TCase>(Expression.Constant(result));
            }

            public IExpressable<Func<TBase, TResult>> Otherwise(Expression<Func<TBase, TResult>> func)
            {
                m_result = Expression.Invoke(func, SwitchParameter);
                return this;
            }

            public IExpressable<Func<TBase, TResult>> Otherwise(TResult result)
            {
                m_result = Expression.Constant(result);
                return this;
            }

            private Expression Wrap(Expression expression, ExpressionCase @case)
            {
                var first = @case.Expression;
                var second = expression;

                if (first.Type != second.Type) {
                    first = Expression.Convert(first, typeof(TResult));
                    second = Expression.Convert(second, typeof(TResult));
                }

                return Expression.Condition(
                    Expression.TypeIs(SwitchParameter, @case.CaseType),
                    first, second
                );
            }

            public Expression<Func<TBase, TResult>> ToExpression()
            {
                Expression expression = m_result;
                for (int i = m_cases.Count - 1; i >= 0; i--)
                {
                    expression = this.Wrap(expression, m_cases[i]);
                }
                return Expression.Lambda<Func<TBase, TResult>>(
                    expression,
                    SwitchParameter
                );
            }

            public Func<TBase, TResult> Compile()
            {
                return this.ToExpression().Compile();
            }
        }

        #endregion

        #region ToReceiver<TBase> Class

        private struct ToReceiver<TBase> : IExpressionSwitchTo<TBase>
            where TBase : class
        {
            public IExpressionSwitchCase<TBase, TResult> To<TResult>()
                where TResult : class
            {
                return new CaseBuilder<TBase, TResult>();
            }
        }

        #endregion

        public static IExpressionSwitchTo<T> Type<T>()
            where T : class
        {
            return new ToReceiver<T>();
        }
    }
}
