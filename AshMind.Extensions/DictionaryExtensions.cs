using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="IDictionary{TKey, TValue}" />. 
    /// </summary>
    public static class DictionaryExtensions {
        /// <summary>Gets the value associated with the specified key, or a default value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the <typeparamref name="TValue"/> type.</returns>
        [Contracts.Pure] [Pure]
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key) {
            return GetValueOrDefault(dictionary, key, default(TValue));
        }

        [Contracts.Pure] [Pure] [Obsolete("Please use overload without TDefault instead.")]
        public static TDefault GetValueOrDefault<TKey, TValue, TDefault>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key, [CanBeNull] TDefault @default)
            where TValue : TDefault 
        {
            TValue value;
            var succeeded = dictionary.TryGetValue(key, out value);
            return succeeded ? value : @default;
        }

        /// <summary>Gets the value associated with the specified key, or adds and returns the new value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get or add.</param>
        /// <param name="value">The value to add if <paramref name="key" /> is not found.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the <paramref name="value"/>.</returns>
        public static TValue GetOrAdd<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key, [CanBeNull] TValue value) {
            TValue found;
            if (dictionary.TryGetValue(key, out found))
                return found;

            dictionary.Add(key, value);
            return value;
        }

        /// <summary>Gets the value associated with the specified key, or adds and returns a new value by using the specified function if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get or add.</param>
        /// <param name="valueFactory">The function used to generate a value for the <paramref name="key" /> if it was not found.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the value returned by <paramref name="valueFactory"/>.</returns>
        public static TValue GetOrAdd<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key, [NotNull] [InstantHandle] Func<TKey, TValue> valueFactory) {
            TValue found;
            if (dictionary.TryGetValue(key, out found))
                return found;

            var value = valueFactory(key);
            dictionary.Add(key, value);
            return value;
        }

        #if IReadOnlyDictionary
        /// <summary>
        /// Converts <see cref="IDictionary{TKey, TValue}" /> to <see cref="ReadOnlyDictionary{TKey, TValue}" />.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in <paramref name="dictionary"/>.</typeparam>
        /// <param name="dictionary">The dictionary to convert.</param>
        /// <returns>
        /// A <see cref="ReadOnlyDictionary{TKey, TValue}" /> that acts as a read-only wrapper around the current <see cref="IDictionary{TKey, TValue}"/>.</returns>
        /// <remarks>
        /// If the <paramref name="dictionary" /> is already of type <see cref="ReadOnlyDictionary{T, TValue}" /> this method returns it directly. Otherwise, it
        /// returns an new instance of <see cref="ReadOnlyDictionary{T, TValue}" /> acting as a read-only wrapper around the <paramref name="dictionary" />.
        /// </remarks>
        [Contracts.Pure] [Pure]
        public static ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary) {
            return (dictionary as ReadOnlyDictionary<TKey, TValue>) ?? new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        /// <summary>Gets the value associated with the specified key, or a default value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the <typeparamref name="TValue"/> type.</returns>
        [Contracts.Pure] [Pure]
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this IReadOnlyDictionary<TKey, TValue> dictionary, [NotNull] TKey key) {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return value; // IReadOnlyDictionary<,> interface promises value == default(TValue) if not found
        }

        /// <summary>Gets the value associated with the specified key, or a default value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the <typeparamref name="TValue"/> type.</returns>
        [Contracts.Pure] [Pure]
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this Dictionary<TKey, TValue> dictionary, [NotNull] TKey key) {
            return ((IReadOnlyDictionary<TKey, TValue>)dictionary).GetValueOrDefault(key);
        }
        #endif
    }
}