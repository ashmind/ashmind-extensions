using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AshMind.Extensions.Tests {
    public class DictionaryExtensionsTests {
        [Fact]
        public void GetOrAdd_WithValue_WhenKeyIsPresent_ReturnsExistingValue() {
            var dictionary = new Dictionary<string, string> {{ "key", "existing" }};
            var value = dictionary.GetOrAdd("key", "new");

            Assert.Equal("existing", value);
        }

        [Fact]
        public void GetOrAdd_WithValue_WhenKeyIsNotPresent_ReturnsNewValue() {
            var dictionary = new Dictionary<string, string>();
            var value = dictionary.GetOrAdd("key", "new");

            Assert.Equal("new", value);
        }

        [Fact]
        public void GetOrAdd_WithValue_WhenKeyIsNotPresent_AddsNewValue() {
            var dictionary = new Dictionary<string, string>();
            dictionary.GetOrAdd("key", "new");

            Assert.True(dictionary.ContainsKey("key"));
            Assert.Equal(dictionary["key"], "new");
        }

        [Fact]
        public void GetOrAdd_WithFunction_WhenKeyIsPresent_ReturnsExistingValue() {
            var dictionary = new Dictionary<string, string> { { "key", "existing" } };
            var value = dictionary.GetOrAdd("key", _ => "new");

            Assert.Equal("existing", value);
        }

        [Fact]
        public void GetOrAdd_WithFunction_WhenKeyIsNotPresent_ReturnsNewValue() {
            var dictionary = new Dictionary<string, string>();
            var value = dictionary.GetOrAdd("key", _ => "new");

            Assert.Equal("new", value);
        }

        [Fact]
        public void GetOrAdd_WithFunction_WhenKeyIsNotPresent_AddsNewValue() {
            var dictionary = new Dictionary<string, string>();
            dictionary.GetOrAdd("key", _ => "new");

            Assert.True(dictionary.ContainsKey("key"));
            Assert.Equal(dictionary["key"], "new");
        }

        [Fact]
        public void GetOrAdd_WithFunction_WhenKeyIsNotPresent_CallsFunctionWithCorrectKey() {
            var dictionary = new Dictionary<string, string>();
            string key = null;
            dictionary.GetOrAdd("key", k => key = k);

            Assert.Equal("key", key);
        }
    }
}
