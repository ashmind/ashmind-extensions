using System;
using System.Collections.Generic;
using System.Linq;

using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class EnumerableExtensionsTests {
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
    }
}
