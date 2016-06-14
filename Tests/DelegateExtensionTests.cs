using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AshMind.Extensions.Tests {
    public class DelegateExtensionTests {
        [Fact]
        public void Function_AsPredicate() {
            Func<string, bool> func = x => x == "test";
            var predicate = func.AsPredicate();

            Assert.Same(func.Target, predicate.Target);
            Assert.Same(func.Method, predicate.Method);
        }

        [Fact]
        public void Predicate_AsFunction() {
            Predicate<string> predicate = x => x == "test";
            var func = predicate.AsFunction();

            Assert.Same(predicate.Target, func.Target);
            Assert.Same(predicate.Method, func.Method);
        }

        [Fact]
        public void Function_AsComparison() {
            Func<string, string, int> func = (x, y) => x.CompareTo(y);
            var comparison = func.AsComparison();

            Assert.Same(func.Target, comparison.Target);
            Assert.Same(func.Method, comparison.Method);
        }

        [Fact]
        public void Comparison_AsFunction() {
            Comparison<string> comparison = (x, y) => x.CompareTo(y);
            var func = comparison.AsFunction();

            Assert.Same(comparison.Target, func.Target);
            Assert.Same(comparison.Method, func.Method);
        }

        [Fact]
        public void Comparison_ToComparer() {
            Comparison<string> comparison = (x, y) => x.CompareTo(y);
            var comparer = comparison.ToComparer();

            Assert.Equal(comparison("a", "b"), comparer.Compare("a", "b"));
            Assert.Equal(comparison("b", "a"), comparer.Compare("b", "a"));
            Assert.Equal(comparison("a", "a"), comparer.Compare("a", "a"));
        }

        [Fact]
        public void Function_ToComparer() {
            Func<string, string, int> func = (x, y) => x.CompareTo(y);
            var comparer = func.ToComparer();

            Assert.Equal(func("a", "b"), comparer.Compare("a", "b"));
            Assert.Equal(func("b", "a"), comparer.Compare("b", "a"));
            Assert.Equal(func("a", "a"), comparer.Compare("a", "a"));
        }
    }
}
