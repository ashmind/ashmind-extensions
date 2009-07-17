using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class ListExtensionsTests {
        [Test]
        public void TestAsReadOnlyReturnsAllItemsFromTheOriginalList() {
            var list = (new List<int> { 1, 2, 4 }) as IList<int>;
            Assert.AreElementsEqual(list, list.AsReadOnly());
        }

        [Test]
        public void TestAsReadOnlyReturnsSameInstanceForTheReadOnlyCollection() {
            var collection = new ReadOnlyCollection<int>(new[] { 1, 2, 4 });
            Assert.AreSame(collection, collection.AsReadOnly());
        }

        [Test]
        public void TestInsertRangeWorksCorrectly() {
            IList<int> list = new List<int> { 0, 1, 2, 3, 4 };
            list.InsertRange(3, new[] { 21, 22, 23 });

            Assert.AreElementsEqual(
                new[] { 0, 1, 2, 21, 22, 23, 3, 4 },
                list
            );
        }
    }
}
