using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;

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
        [Contracts.Pure] [Pure] [CanBeNull]
        [return: CodeAnalysis.MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key)
            where TKey: notnull
        {
            TValue value;
            var succeeded = dictionary.TryGetValue(key, out value);
            return succeeded ? value : default!; // default! is a limitation of NRT, see https://github.com/dotnet/roslyn/issues/30953
        }

        /// <summary>Gets the value associated with the specified key, or adds and returns the new value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get or add.</param>
        /// <param name="value">The value to add if <paramref name="key" /> is not found.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the <paramref name="value"/>.</returns>
        [CanBeNull]
        public static TValue GetOrAdd<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key, [CanBeNull] TValue value)
            where TKey : notnull
        {
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
        [CanBeNull]
        public static TValue GetOrAdd<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, [NotNull] TKey key, [NotNull] [InstantHandle] Func<TKey, TValue> valueFactory)
            where TKey : notnull
        {
            TValue found;
            if (dictionary.TryGetValue(key, out found))
                return found;

            var value = valueFactory(key);
            dictionary.Add(key, value);
            return value;
        }

        #if !No_ReadOnlyCollections
        /// <summary>
        /// Converts <see cref="IDictionary{TKey, TValue}" /> to <see cref="IReadOnlyDictionary{TKey, TValue}" />.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in <paramref name="dictionary"/>.</typeparam>
        /// <param name="dictionary">The dictionary to convert.</param>
        /// <returns>
        /// A <see cref="IReadOnlyDictionary{TKey, TValue}" /> that acts as a read-only wrapper around the current <see cref="IDictionary{TKey, TValue}"/>.</returns>
        /// <remarks>
        /// If the <paramref name="dictionary" /> is already of type <see cref="IReadOnlyDictionary{T, TValue}" /> this method returns it directly. Otherwise, it
        /// returns an new instance of <see cref="IReadOnlyDictionary{T, TValue}" /> acting as a read-only wrapper around the <paramref name="dictionary" />.
        /// </remarks>
        [Contracts.Pure] [Pure]
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary)
            where TKey : notnull
        {
            return (dictionary as IReadOnlyDictionary<TKey, TValue>) ?? new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        #if No_ReadOnlyDictionary_GetValueOrDefault
        /// <summary>Gets the value associated with the specified key, or a default value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the <typeparamref name="TValue"/> type.</returns>
        [Contracts.Pure] [Pure]
        [return: CodeAnalysis.MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this IReadOnlyDictionary<TKey, TValue> dictionary, [NotNull] TKey key) 
            where TKey: notnull
        {
            TValue value;
            dictionary.TryGetValue(key, out value);
            return value; // IReadOnlyDictionary<,> interface promises value == default(TValue) if not found
        }
        #endif

        /// <summary>Gets the value associated with the specified key, or a default value if the key was not found.</summary>
        /// <param name="dictionary">The dictionary to get value from.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <typeparam name="TKey">The type of keys in the <paramref name="dictionary"/>.</typeparam>
        /// <typeparam name="TValue">The type of values in the <paramref name="dictionary"/>.</typeparam>
        /// <returns>The value associated with the specified key, if the key is found; otherwise, the default value for the <typeparamref name="TValue"/> type.</returns>
        [Contracts.Pure] [Pure]
        [return: CodeAnalysis.MaybeNull]
        public static TValue GetValueOrDefault<TKey, TValue>([NotNull] this Dictionary<TKey, TValue> dictionary, [NotNull] TKey key)
            where TKey : notnull
        {
            return ((IReadOnlyDictionary<TKey, TValue>)dictionary).GetValueOrDefault(key);
        }
        #endif
    }
}