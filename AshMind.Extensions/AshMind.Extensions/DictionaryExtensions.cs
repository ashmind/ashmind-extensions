using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    public static class DictionaryExtensions {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {
            return GetValueOrDefault(dictionary, key, default(TValue));
        }

        public static TDefault GetValueOrDefault<TKey, TValue, TDefault>(this IDictionary<TKey, TValue> dictionary, TKey key, TDefault @default)
            where TValue : TDefault 
        {
            TValue value;
            bool succeeded = dictionary.TryGetValue(key, out value);
            return succeeded ? value : @default;
        }
    }
}
