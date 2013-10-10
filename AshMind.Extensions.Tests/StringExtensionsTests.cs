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
        public void SubstringBefore(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringBefore(delimiter));
        }

        [Theory]
        [InlineData("ab18ba18", "18", "ab18ba")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "a", "")]
        [InlineData("abcdefgh", "fg", "abcde")]
        public void SubstringBeforeLast(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringBeforeLast(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "bc", "dabcd")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "h", "")]
        [InlineData("abcdefgh", "cd", "efgh")]
        public void SubstringAfter(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringAfter(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "bc", "d")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "h", "")]
        [InlineData("abcdefgh", "cd", "efgh")]
        public void SubstringAfterLast(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringAfterLast(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "ab", "cdabcd")]
        [InlineData("abcdabcd", "xy", "abcdabcd")]
        [InlineData("abcdabcd", "abcdabcd", "")]
        public void RemoveStart(string value, string prefix, string expectedResult) {
            Assert.Equal(expectedResult, value.RemoveStart(prefix));
        }


        [Theory]
        [InlineData("abcdabcd", "cd", "abcdab")]
        [InlineData("abcdabcd", "xy", "abcdabcd")]
        [InlineData("abcdabcd", "abcdabcd", "")]
        public void RemoveEnd(string value, string suffix, string expectedResult) {
            Assert.Equal(expectedResult, value.RemoveEnd(suffix));
        }
    }
}
