using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

#pragma warning disable xUnit1019 // https://github.com/xunit/xunit/issues/1897

namespace AshMind.Extensions.Tests {
    public class CollectionExtensionsTests {
        public delegate ICollection<int> CollectionFactory(params int[] values);

        [Fact]
        public void RemoveWhere_ForList_ProvidesCorrectIndex() {
            var list = new List<int> {0, 1, 2, 3};
            list.RemoveWhere((item, index) => {
                Assert.Equal(item, index);
                return false;
            });
        }

        [Theory]
        [MemberData(nameof(Collections))]
        public void RemoveWhere_WithIndex_RemovesFrom(Expression<CollectionFactory> factory) {
            var collection = factory.Compile()(1, 2, 3, 4, 5);
            collection.RemoveWhere((item, index) => item == 2);
            Assert.Equal(new[] { 1, 3, 4, 5 }, collection.ToArray());
        }

        [Theory]
        [MemberData(nameof(Collections))]
        public void RemoveWhere_RemovesFrom(Expression<CollectionFactory> factory) {
            var collection = factory.Compile()(1, 2, 3, 4, 5);
            collection.RemoveWhere(item => item == 2);
            Assert.Equal(new[] { 1, 3, 4, 5 }, collection.ToArray());
        }

        [Theory]
        [MemberData(nameof(Collections))]
        public void RemoveWhere_ReturnsCorrectCount(Expression<CollectionFactory> factory) {
            var collection = factory.Compile()(1, 2, 3, 4, 5);
            var count = collection.RemoveWhere(item => item > 2);

            Assert.Equal(3, count);
        }

        [Theory]
        [MemberData(nameof(Collections))]
        public void RemoveWhere_WithIndex_ReturnsCorrectCount(Expression<CollectionFactory> factory) {
            var collection = factory.Compile()(1, 2, 3, 4, 5);
            var count = collection.RemoveWhere(item => item > 2);

            Assert.Equal(3, count);
        }

        public static IEnumerable<object[]> Collections {
            get {
                Func<Expression<CollectionFactory>, object[]> adapt = f => new object[] {f};

                yield return adapt(xs => new List<int>(xs));
                yield return adapt(xs => new Collection<int>(xs.ToList()));
                yield return adapt(xs => new HashSet<int>(xs));
                yield return adapt(xs => new SortedSet<int>(xs));
            }
        }
    }
}
