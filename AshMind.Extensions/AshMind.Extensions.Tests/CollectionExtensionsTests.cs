using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class CollectionExtensionsTests {
        [Test]
        public void TestRemoveWhereForListProvidesCorrectIndex() {
            var list = new List<int> {0, 1, 2, 3};
            list.RemoveWhere((item, index) => {
                Assert.AreEqual(item, index);
                return false;
            });
        }

        [Test]
        [Row(typeof(List<int>))]
        [Row(typeof(Collection<int>))]
        [Row(typeof(HashSet<int>))]
        public void TestRemoveWhereWithIndexRemovesFrom<T>()
            where T : ICollection<int>, new()
        {
            var collection = new T { 1, 2, 3, 4, 5 };
            collection.RemoveWhere((item, index) => item == 2);
            Assert.AreElementsEqualIgnoringOrder(new[] {1, 3, 4, 5}, collection);
        }

        [Test]
        [Row(typeof(List<int>))]
        [Row(typeof(Collection<int>))]
        [Row(typeof(HashSet<int>))]
        public void TestRemoveWhereRemovesFrom<T>()
            where T : ICollection<int>, new() 
        {
            var collection = new T { 1, 2, 3, 4, 5 };
            collection.RemoveWhere(item => item == 2);
            Assert.AreElementsEqualIgnoringOrder(new[] { 1, 3, 4, 5 }, collection);
        }

        [Test]
        [Row(typeof(List<int>))]
        [Row(typeof(Collection<int>))]
        [Row(typeof(HashSet<int>))]
        public void TestRemoveWhereReturnsCorrectCount<T>()
            where T : ICollection<int>, new() {
            var collection = new T { 1, 2, 3, 4, 5 };
            var count = collection.RemoveWhere(item => item > 2);
            
            Assert.AreEqual(3, count);
        }

        [Test]
        [Row(typeof(List<int>))]
        [Row(typeof(Collection<int>))]
        [Row(typeof(HashSet<int>))]
        public void TestRemoveWhereWithIndexReturnsCorrectCount<T>()
            where T : ICollection<int>, new() {
            var collection = new T { 1, 2, 3, 4, 5 };
            var count = collection.RemoveWhere(item => item > 2);

            Assert.AreEqual(3, count);
        }
    }
}
