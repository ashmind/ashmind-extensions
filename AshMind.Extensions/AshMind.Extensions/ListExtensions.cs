using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="IList&lt;T&gt;" />.
    /// </summary>
    public static class ListExtensions {
        /// <summary>
        /// Returns the input typed as <see cref="ReadOnlyCollection&lt;T&gt;" />. 
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="list" />.</typeparam>
        /// <param name="list">The list to type as <see cref="ReadOnlyCollection&lt;T&gt;" /></param>
        /// <returns>The input list typed as <see cref="ReadOnlyCollection&lt;T&gt;" />.</returns>
        /// <remarks>
        ///  For instances of <see cref="ReadOnlyCollection&lt;T&gt;" /> the same instance is returned.
        /// </remarks>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IList<T> list) {
            return (list as ReadOnlyCollection<T>) ?? new ReadOnlyCollection<T>(list);
        }
    }
}
