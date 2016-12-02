using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace AshMind.Extensions.Tests {
    public class StringExtensionsTests {
        [Theory]
        [InlineData(null,  null)]
        [InlineData("",    null)]
        [InlineData("abc", "abc")]
        public void NullIfEmpty(string value, string expectedResult) {
            Assert.Equal(expectedResult, value.NullIfEmpty());
        }

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
        [InlineData("a.b.c.d", "a.b.d", "a.b.c.d")]
        public void SubstringAfter(string value, string delimiter, string expectedResult) {
            Assert.Equal(expectedResult, value.SubstringAfter(delimiter));
        }

        [Theory]
        [InlineData("abcdabcd", "bc", "d")]
        [InlineData("abcdefgh", "x", "abcdefgh")]
        [InlineData("abcdefgh", "h", "")]
        [InlineData("abcdefgh", "cd", "efgh")]
        [InlineData("a.b.c.d", "a.b.d", "a.b.c.d")]
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

        [Theory]
        [InlineData("a",     0, "")]
        [InlineData("a",     2, "a")]
        [InlineData("ab",    2, "ab")]
        [InlineData("abcde", 2, "ab")]
        public void TruncateEnd(string value, int maxLength, string expectedResult) {
            Assert.Equal(expectedResult, value.TruncateEnd(maxLength));
        }

        [Theory]
        [InlineData("a",     0, "$",    "")]
        [InlineData("a",     2, "$",    "a")]
        [InlineData("ab",    2, "$",    "ab")]
        [InlineData("abcde", 2, "$",    "a$")]
        [InlineData("abcd",  3, "1234", "123")]
        [InlineData("abcde", 3, "123",  "123")]
        [InlineData("abcde", 4, "123",  "a123")]
        public void TruncateEnd_WithSuffix(string value, int maxLength, string suffix, string expectedResult) {
            Assert.Equal(expectedResult, value.TruncateEnd(maxLength, suffix));
        }

    }
}
