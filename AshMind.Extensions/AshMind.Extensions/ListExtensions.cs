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

        /// <summary>
        /// Inserts the elements of a collection into the <see cref="IList{T}"/> at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="list" />.</typeparam>
        /// <param name="list">The list to which new elements will be inserted.</param>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">
        /// The collection whose elements should be inserted into the <see cref="IList{T}"/>. The collection itself cannot
        /// be a null reference (<c>Nothing</c> in Visual Basic), but it can contain elements that are a null 
        /// reference (<c>Nothing</c> in Visual Basic), if type <typeparamref name="T"/> is a reference type.
        /// </param>
        public static void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> collection) {
            var concreteList = list as List<T>;
            if (concreteList != null) {
                concreteList.InsertRange(index, collection);
                return;
            }

            var currentIndex = index;
            foreach (var item in collection) {
                list.Insert(currentIndex, item);
                currentIndex += 1;
            }
        }
    }
}
