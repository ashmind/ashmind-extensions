using System;
using System.Collections.Generic;
using System.Linq;

using MbUnit.Framework;

namespace AshMind.Extensions.Tests {
    [TestFixture]
    public class DelegateExtensionTests {
        [Test]
        public void TestFunctionAsPredicate() {
            Func<string, bool> func = x => x == "test";
            var predicate = func.AsPredicate();

            Assert.AreSame(func.Target, predicate.Target);
            Assert.AreSame(func.Method, predicate.Method);
        }

        [Test]
        public void TestPredicateAsFunction() {
            Predicate<string> predicate = x => x == "test";
            var func = predicate.AsFunction();

            Assert.AreSame(predicate.Target, func.Target);
            Assert.AreSame(predicate.Method, func.Method);
        }

        [Test]
        public void TestFunctionAsComparison() {
            Func<string, string, int> func = (x, y) => x.CompareTo(y);
            var comparison = func.AsComparison();

            Assert.AreSame(func.Target, comparison.Target);
            Assert.AreSame(func.Method, comparison.Method);
        }

        [Test]
        public void TestComparisonAsFunction() {
            Comparison<string> comparison = (x, y) => x.CompareTo(y);
            var func = comparison.AsFunction();

            Assert.AreSame(comparison.Target, func.Target);
            Assert.AreSame(comparison.Method, func.Method);
        }

        [Test]
        public void TestComparisonToComparer() {
            Comparison<string> comparison = (x, y) => x.CompareTo(y);
            var comparer = comparison.ToComparer();

            Assert.AreEqual(comparison("a", "b"), comparer.Compare("a", "b"));
            Assert.AreEqual(comparison("b", "a"), comparer.Compare("b", "a"));
            Assert.AreEqual(comparison("a", "a"), comparer.Compare("a", "a"));
        }

        [Test]
        public void TestFunctionToComparer() {
            Func<string, string, int> func = (x, y) => x.CompareTo(y);
            var comparer = func.ToComparer();

            Assert.AreEqual(func("a", "b"), comparer.Compare("a", "b"));
            Assert.AreEqual(func("b", "a"), comparer.Compare("b", "a"));
            Assert.AreEqual(func("a", "a"), comparer.Compare("a", "a"));
        }
    }
}
