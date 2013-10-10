using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace AshMind.Extensions.Tests {
    public class EnumerableExtensionsTests {
        [Fact]
        public void Any_ReceivesCorrectIndex() {
            var list = new List<int> { 0, 1, 2, 3 };
            list.Any((item, index) => {
                Assert.Equal(item, index);
                return false;
            });
        }

        [Theory]
        [InlineData(2, true)]
        [InlineData(5, false)]
        public void Any_ProducesExpectedResult(int input, bool expected) {
            var list = new List<int> { 0, 1, 2, 3 };
            var result = list.Any((item, index) => item == input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ToSet_IncludesAllItems(bool withComparer) {
            var list = new[] { 0, 1, 2, 3 };
            var set = withComparer ? list.ToSet(EqualityComparer<int>.Default) : list.ToSet();

            Assert.Equal(list, set);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ToSet_CollapsesDuplicateItems(bool withComparer) {
            var list = new[] { 0, 1, 2, 3, 2 };
            var set = withComparer ? list.ToSet(EqualityComparer<int>.Default) : list.ToSet();

            Assert.Equal(list.Distinct(), set);
        }

        [Fact]
        public void ToSet_UsesCorrectComparer() {
            var list = new[] { "a", "b" };
            var set = list.ToSet(StringComparer.InvariantCultureIgnoreCase);

            Assert.False(set.Add("A"));
        }

        [Fact]
        public void HavingMax_ReturnsAllMaxValues() {
            var items = new[] {
                new { Name = "Andrey",  Salary = 15000 },
                new { Name = "Stan",    Salary = 9000 },
                new { Name = "William", Salary = 15000 },
            };

            Assert.Equal(
                items.HavingMax(p => p.Salary),
                new[] { items[0], items[2] }
            );
        }

        [Fact]
        public void HavingMax_ForSingleValue_ReturnsIt() {
            var items = new[] { new { Name = "Andrey", Salary = 15000 } };

            Assert.Equal(
                items.HavingMax(p => p.Salary),
                new[] { items[0] }
            );
        }

        [Fact]
        public void HavingMax_ForSingleValueThatIsDefaultForType_ReturnsIt() {
            var items = new[] { new { Name = "Andrey", Level = 0 } };

            Assert.Equal(items.HavingMax(p => p.Level), items);
        }

        [Fact]
        public void HavingMin_ReturnsAllMinValues() {
            var items = new[] {
                new { Name = "Andrey",  Salary = 9000 },
                new { Name = "Stan",    Salary = 9000 },
                new { Name = "William", Salary = 15000 },
            };

            Assert.Equal(
                items.HavingMin(p => p.Salary),
                new[] { items[0], items[1] }
            );
        }

        //[StaticTestFactory]
        //public static IEnumerable<Test> GetCommonTests() {
        //    var methods = typeof(EnumerableExtensions).GetMethods(BindingFlags.Static | BindingFlags.Public);
        //    foreach (var method in methods) {
        //        var methodFixed = method;
        //        if (method.ContainsGenericParameters)
        //            methodFixed = methodFixed.MakeGenericMethod(methodFixed.GetGenericArguments().Select(a => typeof(object)).ToArray());

        //        Gallio.Common.Action testMethodHandlesNullCorrectly = () => {
        //            try {
        //                methodFixed.Invoke(null, methodFixed.GetParameters().Select(p => (object)null).ToArray());
        //            }
        //            catch (TargetInvocationException ex) {
        //                throw ex.InnerException;
        //            }
        //        };

        //        yield return new TestCase(
        //            "Test" + method.Name + "HandlesNullCorrectly",
        //            () => Assert.Throws<ArgumentNullException>(testMethodHandlesNullCorrectly)
        //        );
        //    }
        //}
    }
}