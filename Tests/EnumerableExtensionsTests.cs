using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;
using Xunit.Extensions;

// ReSharper disable PossibleNullReferenceException

namespace AshMind.Extensions.Tests {
    public class EnumerableExtensionsTests {
        [Fact]
        public void EmptyIfNull_WhenEnumerableIsNotNull_ReturnsSameEnumerable() {
            var enumerable = Enumerable.Empty<int>();
            Assert.Same(enumerable, enumerable.EmptyIfNull());
        }

        [Fact]
        public void EmptyIfNull_WhenEnumerableIsNull_ReturnsEmptyEnmumerable() {
            // ReSharper disable once ExpressionIsAlwaysNull
            var result = ((IEnumerable<int>)null).EmptyIfNull();
            Assert.NotNull(result);
            Assert.Equal(Enumerable.Empty<int>(), result);
        }

        [Fact]
        public void Any_ReceivesCorrectIndex() {
            var list = new List<int> { 0, 1, 2, 3 };
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
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

        [Theory]
        [InlineData("A",                 "A:0")]
        [InlineData("A,A,A",             "A:0,1,2")]
        [InlineData("A,A,A,B,C,C,A,A,B", "A:0,1,2; B:3; C:4,5; A:6,7; B:8")]
        public void GroupAdjacentBy_GroupsByKeyCorrectly(string itemsString, string expected) {
            var items = itemsString.Split(',').Select((key, index) => new { key, index });
            var grouped = items.GroupAdjacentBy(x => x.key, x => x.index);
            var groupedString = string.Join("; ", grouped.Select(g => g.Key + ":" + string.Join(",", g)));

            Assert.Equal(expected, groupedString);
        }

        [Fact]
        public void GroupAdjacentBy_ReturnsEmptySequence_WhenPassedEmpty() {
            var grouped = (new string[0]).GroupAdjacentBy(x => x);
            Assert.Empty(grouped);
        }

        [Fact]
        public void GroupAdjacentBy_DoesNotCallKeySelectorImmediately() {
            var items = new[] { new { key = 1 } };
            var selectorCalled = false;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            items.GroupAdjacentBy(x => {
                selectorCalled = true;
                return x.key;
            });

            Assert.False(selectorCalled);
        }

        [Fact]
        public void GroupAdjacentBy_DoesNotCallElementSelectorImmediately() {
            var items = new[] { new { key = 1 } };
            var selectorCalled = false;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            items.GroupAdjacentBy(x => x.key, x => {
                selectorCalled = true;
                return x;
            });

            Assert.False(selectorCalled);
        }

        [Fact]
        public void GroupAdjacentBy_DoesNotCallResultSelectorImmediately() {
            var items = new[] { new { key = 1 } };
            var selectorCalled = false;

            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            items.GroupAdjacentBy(x => x.key, x => x, (_, xs) => {
                selectorCalled = true;
                return xs;
            });

            Assert.False(selectorCalled);
        }

        [Fact]
        public void AsList_UsesSameInstance_ForList() {
            var list = new List<int>();
            Assert.Same(list, list.AsList());
        }

        [Fact]
        public void AsList_CreatesNewList_ForEnumerable() {
            var enumerable = Enumerable.Range(1, 5);
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(enumerable, enumerable.AsList());
            // ReSharper restore PossibleMultipleEnumeration
        }

        [Fact]
        public void AsReadOnlyList_UsesSameInstance_ForReadOnlyCollection() {
            var list = new List<int>();
            Assert.Same(list, list.AsReadOnlyList());
        }

        [Fact]
        public void AsReadOnlyList_CreatesNewList_ForEnumerable() {
            var enumerable = Enumerable.Range(1, 5);
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(enumerable, enumerable.AsReadOnlyList());
            // ReSharper restore PossibleMultipleEnumeration
        }

        [Fact]
        public void AsCollection_UsesSameInstance_ForCollection() {
            var collection = new Collection<int>();
            Assert.Same(collection, collection.AsCollection());
        }

        [Fact]
        public void AsCollection_CreatesNewCollection_ForEnumerable() {
            var enumerable = Enumerable.Range(1, 5);
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(enumerable, enumerable.AsCollection());
            // ReSharper restore PossibleMultipleEnumeration
        }

        [Fact]
        public void AsReadOnlyCollection_UsesSameInstance_ForReadOnlyCollection() {
            var collection = new Collection<int>();
            Assert.Same(collection, collection.AsReadOnlyCollection());
        }

        [Fact]
        public void AsReadOnlyCollection_CreatesNewCollection_ForEnumerable() {
            var enumerable = Enumerable.Range(1, 5);
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(enumerable, enumerable.AsReadOnlyCollection());
            // ReSharper restore PossibleMultipleEnumeration
        }

        [Fact]
        public void AsSet_UsesSameInstance_ForSet() {
            var set = new HashSet<int>();
            Assert.Same(set, set.AsSet());
        }

        [Fact]
        public void AsSet_CreatesNewSet_ForEnumerable() {
            var enumerable = Enumerable.Range(1, 5);
            // ReSharper disable PossibleMultipleEnumeration
            Assert.Equal(enumerable, enumerable.AsSet());
            // ReSharper restore PossibleMultipleEnumeration
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