using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AshMind.Extensions.Tests {
    public class DictionaryExtensionsTests {
        [Fact]
        public void GetValueOrDefault_GetsDefault_IfValueIsNotPresent_ForReferenceType() {
            var dictionary = new Dictionary<string, string>();
            Assert.Null(dictionary.GetValueOrDefault("key"));
        }

        [Fact]
        public void GetValueOrDefault_GetsDefault_IfValueIsNotPresent_ForValueType() {
            var dictionary = new Dictionary<string, int>();
            Assert.Equal(0, dictionary.GetValueOrDefault("key"));
        }

        [Fact]
        public void GetValueOrDefault_GetsValue_IfValueIsPresent() {
            var dictionary = new Dictionary<string, string> {
                { "key", "value" }
            };
            Assert.Equal("value", dictionary.GetValueOrDefault("key"));
        }

        [Fact]
        public void GetValueOrDefault_Compiles_ForEachType() {
            var dictionary = new Dictionary<string, object>();
            
            // ReSharper disable ReturnValueOfPureMethodIsNotUsed
            // ReSharper disable RedundantCast
            dictionary.GetValueOrDefault("x");
            ((IDictionary<string, object>)dictionary).GetValueOrDefault("x");
            ((IReadOnlyDictionary<string, object>)dictionary).GetValueOrDefault("x");
            // ReSharper restore RedundantCast
            // ReSharper restore ReturnValueOfPureMethodIsNotUsed
        }

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
