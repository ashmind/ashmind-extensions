using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace AshMind.Extensions.Tests {
    public class StringExtensionsTests {
        [Theory]
        [InlineData("ab18ba18", "18",  "ab")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "a", "")]
        [InlineData("abcdefgh", "fg", "abcde")]
        public void TestSubstringBefore(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringBefore(delimiter));
        }

        [Theory]
        [InlineData("ab18ba18", "18", "ab18ba")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "a", "")]
        [InlineData("abcdefgh", "fg", "abcde")]
        public void TestSubstringBeforeLast(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringBeforeLast(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "bc", "dabcd")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "h", "")]
        [InlineData("abcdefgh", "cd", "efgh")]
        public void TestSubstringAfter(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringAfter(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "bc", "d")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "h", "")]
        [InlineData("abcdefgh", "cd", "efgh")]
        public void TestSubstringAfterLast(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringAfterLast(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "ab", "cdabcd")]
        [InlineData("abcdabcd", "xy", "abcdabcd")]
        [InlineData("abcdabcd", "abcdabcd", "")]
        public void TestRemoveStart(string value, string prefix, string expectedResult) {
            Assert.Equal(expectedResult, value.RemoveStart(prefix));
        }


        [Theory]
        [InlineData("abcdabcd", "cd", "abcdab")]
        [InlineData("abcdabcd", "xy", "abcdabcd")]
        [InlineData("abcdabcd", "abcdabcd", "")]
        public void TestRemoveEnd(string value, string suffix, string expectedResult) {
            Assert.Equal(expectedResult, value.RemoveEnd(suffix));
        }
    }
}
