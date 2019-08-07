using AshMind.Extensions;
using System.Collections.Generic;

namespace AshMind.Extensions.Tests.Compilation
{
    public static class DictionaryExtensionsTests
    {
        public static void GetValueOrDefault_ReturnsNullableValue_IfDictionaryTValueIsNullable()
        {
            var dictionary = new Dictionary<string, string?>();
            var value = dictionary.GetValueOrDefault("x");

            CompilerAssert.Nullable(ref value);
        }

        public static void GetValueOrDefault_ReturnsNullableValue_IfDictionaryTValueIsNotNullable()
        {
            var dictionary = new Dictionary<string, string>();
            var value = dictionary.GetValueOrDefault("x");

            CompilerAssert.Nullable(ref value);
        }

        public static void GetValueOrDefault_ReturnsNullableValue_IfDictionaryTValueIsNullable_ForIDictionary()
        {
            var dictionary = (IDictionary<string, string?>)new Dictionary<string, string?>();
            var value = dictionary.GetValueOrDefault("x");

            CompilerAssert.Nullable(ref value);
        }

        public static void GetValueOrDefault_ReturnsNullableValue_IfDictionaryTValueIsNotNullable_ForIDictionary()
        {
            var dictionary = (IDictionary<string, string>)new Dictionary<string, string>();
            var value = dictionary.GetValueOrDefault("x");

            CompilerAssert.Nullable(ref value);
        }

        #if !NET40
        public static void GetValueOrDefault_ReturnsNullableValue_IfDictionaryTValueIsNullable_ForIReadOnlyDictionary()
        {
            var dictionary = (IReadOnlyDictionary<string, string?>)new Dictionary<string, string?>();
            var value = dictionary.GetValueOrDefault("x");

            CompilerAssert.Nullable(ref value);
        }

        public static void GetValueOrDefault_ReturnsNullableValue_IfDictionaryTValueIsNotNullable_ForIReadOnlyDictionary()
        {
            var dictionary = (IReadOnlyDictionary<string, string>)new Dictionary<string, string>();
            var value = dictionary.GetValueOrDefault("x");

            CompilerAssert.Nullable(ref value);
        }
        #endif
    }
}
