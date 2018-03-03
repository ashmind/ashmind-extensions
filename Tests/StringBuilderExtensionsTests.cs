using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace AshMind.Extensions.Tests {
    public class StringBuilderExtensionsTests {
#if No_StringBuilder_AppendJoin
        [Theory]
        [InlineData(",", new[] { 1, 2 }, "[1,2]")]
        [InlineData(null, new[] { 1, 2 }, "[12]")]
        [InlineData(",", new int[0], "[]")]
        [InlineData(null, new int[0], "[]")]
        [InlineData(",", new[] { null, "x", null, "y", null }, "[,x,,y,]")]
        [InlineData(" s ", new[] { "x", "y" }, "[x s y]")]
        [InlineData(",", new[] { "x", "y", "z" }, "[x,y,z]")]
        public void AppendJoin_WorksCorrectly_WithEnumerable(string separator, Array values, string expectedResult) {
            var builder = new StringBuilder("[").AppendJoin(separator, values.Cast<object>()).Append("]");
            Assert.Equal(expectedResult, builder.ToString());
        }

        [Theory]
        [InlineData(",", new[] { 1, 2 }, "[1,2]")]
        [InlineData(" s ", new[] { 1, 2 }, "[1 s 2]")]
        [InlineData(",", new[] { 1, 2, 3 }, "[1,2,3]")]
        [InlineData(null, new[] { 1, 2 }, "[12]")]
        [InlineData(",", new int[0], "[]")]
        [InlineData(null, new int[0], "[]")]
        public void AppendJoin_WorksCorrectly_WithArray(string separator, int[] values, string expectedResult) {
            var builder = new StringBuilder("[").AppendJoin(separator, values).Append("]");
            Assert.Equal(expectedResult, builder.ToString());
        }

        [Theory]
        [InlineData(",", new[] { "a", "b" }, "[a,b]")]
        [InlineData(null, new[] { "a", "b" }, "[ab]")]
        [InlineData(",", new string[0], "[]")]
        [InlineData(null, new string[0], "[]")]
        [InlineData(",", new[] { null, "x", null, "y", null }, "[,x,,y,]")]
        [InlineData(" s ", new[] { "x", "y" }, "[x s y]")]
        [InlineData(",", new[] { "x", "y", "z" }, "[x,y,z]")]
        public void AppendJoin_WorksCorrectly_WithStringArray(string separator, string[] values, string expectedResult) {
            var builder = new StringBuilder("[").AppendJoin(separator, values).Append("]");
            Assert.Equal(expectedResult, builder.ToString());
        }

        [Fact]
        public void AppendJoin_ThrowsArgumentNullException_IfBuilderIsNull() {
            Assert.Throws<ArgumentNullException>(
                // ReSharper disable once AssignNullToNotNullAttribute
                () => ((StringBuilder)null).AppendJoin(",", new[] {1, 2})
            );
        }

        [Fact]
        public void AppendJoin_ThrowsArgumentNullException_IfBuilderIsNullForStringParamsOverload() {
            Assert.Throws<ArgumentNullException>(
                // ReSharper disable once AssignNullToNotNullAttribute
                () => ((StringBuilder)null).AppendJoin(",", "a", "b")
            );
        }

        [Fact]
        public void AppendJoin_ThrowsArgumentNullException_IfItemsAreNull() {
            Assert.Throws<ArgumentNullException>(
                // ReSharper disable once AssignNullToNotNullAttribute
                () => new StringBuilder().AppendJoin<string>(",", null)
            );
        }

        [Fact]
        public void AppendJoin_ThrowsArgumentNullException_IfItemsAreNullForStringParamsOverload() {
            Assert.Throws<ArgumentNullException>(
                // ReSharper disable once AssignNullToNotNullAttribute
                () => new StringBuilder().AppendJoin(",", null)
            );
        }

        private IEnumerable<T> Enumerate<T>(T[] values) {
            foreach (var item in values) {
                yield return item;
            }
        }
        #endif
    }
}
