using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

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
        [Contracts.Pure] [Pure] [NotNull]
        public static ReadOnlyCollection<T> AsReadOnly<T>([NotNull] this IList<T> list) {
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
        public static void InsertRange<T>([NotNull] this IList<T> list, int index, [NotNull] IEnumerable<T> collection) {
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

        /// <summary>
        /// Removes a range of elements from the <see cref="IList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="list" />.</typeparam>
        /// <param name="list">The list to remove range from.</param>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="count">The number of elements to remove.</param>
        public static void RemoveRange<T>([NotNull] this IList<T> list, int index, int count) {
            var concreteList = list as List<T>;
            if (concreteList != null) {
                concreteList.RemoveRange(index, count);
                return;
            }

            for (var offset = count - 1; offset >= 0; offset--) {
                list.RemoveAt(index + offset);
            }
        }

        /// <summary>
        /// Produces a limited range of elements from the <see cref="IList{T}"/>. 
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="list" />.</typeparam>
        /// <param name="list">The list to produce range from.</param>
        /// <param name="index">The zero-based element index at which the range starts.</param>
        /// <param name="count">The number of elements in the range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing all elements from the specified range.
        /// </returns>
        [NotNull]
        public static IEnumerable<T> EnumerateRange<T>([NotNull] this IList<T> list, int index, int count) {
            for (var i = index; i < index + count; i++) {
                yield return list[i];
            }
        }

        #if IReadOnlyList
        /// <summary>
        /// Produces a limited range of elements from the <see cref="IReadOnlyList{T}"/>. 
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="list" />.</typeparam>
        /// <param name="list">The list to produce range from.</param>
        /// <param name="index">The zero-based element index at which the range starts.</param>
        /// <param name="count">The number of elements in the range.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing all elements from the specified range.
        /// </returns>
        [NotNull]
        public static IEnumerable<T> EnumerateRange<T>([NotNull] this IReadOnlyList<T> list, int index, int count) {
            for (var i = index; i < index + count; i++) {
                yield return list[i];
            }
        }
        #endif
    }
}
