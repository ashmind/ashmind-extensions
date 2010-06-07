using System;
using System.Collections.Generic;
using System.Linq;

using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class EnumerableExtensionsTests {
        [Test]
        public void TestAnyReceivesCorrectIndex() {
            var list = new List<int> { 0, 1, 2, 3 };
            list.Any((item, index) => {
                Assert.AreEqual(item, index);
                return false;
            });
        }

        [Test]
        [Row(2, true)]
        [Row(5, false)]
        public void TestAnyProducesExpectedResult(int input, bool expected) {
            var list = new List<int> { 0, 1, 2, 3 };
            var result = list.Any((item, index) => item == input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        [Row(false)]
        [Row(true)]
        public void TestToSetIncludesAllItems(bool withComparer) {
            var list = new[] { 0, 1, 2, 3 };
            var set = withComparer ? list.ToSet(EqualityComparer<int>.Default) : list.ToSet();

            Assert.AreElementsEqualIgnoringOrder(list, set);
        }

        [Test]
        [Row(false)]
        [Row(true)]
        public void TestToSetCollapsesDuplicateItems(bool withComparer) {
            var list = new[] { 0, 1, 2, 3, 2 };
            var set = withComparer ? list.ToSet(EqualityComparer<int>.Default) : list.ToSet();

            Assert.AreElementsEqualIgnoringOrder(list.Distinct(), set);
        }

        [Test]
        public void TestToSetUsesCorrectComparer() {
            var list = new[] { "a", "b" };
            var set = list.ToSet(StringComparer.InvariantCultureIgnoreCase);

            AssertEx.That(() => !set.Add("A"));
        }

        [Test]
        public void TestHavingMaxReturnsAllMaxValues() {
            var items = new[] {
                new { Name = "Andrey",  Salary = 15000 },
                new { Name = "Stan",    Salary = 9000 },
                new { Name = "William", Salary = 15000 },
            };

            Assert.AreElementsEqual(
                items.HavingMax(p => p.Salary),
                new[] { items[0], items[2] }
            );
        }

        [Test]
        public void TestHavingMaxForSingleValueReturnsIt() {
            var items = new[] { new { Name = "Andrey", Salary = 15000 } };

            Assert.AreElementsEqual(
                items.HavingMax(p => p.Salary),
                new[] { items[0] }
            );
        }

        [Test]
        public void TestHavingMaxReturnsSingleValueWhenItIsDefaultForType() {
            var items = new[] { new { Name = "Andrey", Level = 0 } };

            Assert.AreElementsEqual(items.HavingMax(p => p.Level), items);
        }

        [Test]
        public void TestHavingMinReturnsAllMinValues() {
            var items = new[] {
                new { Name = "Andrey",  Salary = 9000 },
                new { Name = "Stan",    Salary = 9000 },
                new { Name = "William", Salary = 15000 },
            };

            Assert.AreElementsEqual(
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