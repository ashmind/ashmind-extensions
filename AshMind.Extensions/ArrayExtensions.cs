using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="Array" />.
    /// </summary>
    public static class ArrayExtensions {
        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the 
        /// entire <see cref="Array" />.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// 
        /// <returns>
        /// The zero-based index of the first occurrence of <paramref name="value" /> within
        /// the entire <paramref name="array" />, if found; otherwise, –1.
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        [Pure]
        public static int IndexOf<T>([NotNull] this T[] array, [CanBeNull] T value) {
            return Array.IndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements 
        /// in the <see cref="Array" /> that extends from the specified index to the last element.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// 
        /// <returns>
        /// The zero-based index of the first occurrence of <paramref name="value" /> within the range of elements
        /// in <paramref name="array" /> that extends from <paramref name="startIndex" /> to the last element, if found; otherwise, –1.
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.
        /// </exception>
        [Pure]
        public static int IndexOf<T>([NotNull] this T[] array, [CanBeNull] T value, int startIndex) {
            return Array.IndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the first occurrence within the range of elements 
        /// in the <see cref="Array" /> that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// 
        /// <returns>
        /// The zero-based index of the first occurrence of <paramref name="value" /> within the range of elements in 
        /// <paramref name="array" /> that starts at <paramref name="startIndex" /> and contains the number of elements 
        /// specified in <paramref name="count" />, if found; otherwise, –1.
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.
        /// -or-
        /// <paramref name="count" /> is less than zero.
        /// -or-
        /// <paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in <paramref name="array" />.
        /// </exception>
        [Pure]
        public static int IndexOf<T>([NotNull] this T[] array, [CanBeNull] T value, int startIndex, int count) {
            return Array.IndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence 
        /// within the entire <see cref="Array" />.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param> 
        /// 
        /// <returns>
        /// The zero-based index of the last occurrence of <paramref name="value" /> within the 
        /// entire <paramref name="array" />, if found; otherwise, –1.
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        [Pure]
        public static int LastIndexOf<T>([NotNull] this T[] array, [CanBeNull] T value) {
            return Array.LastIndexOf(array, value);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within the range of elements in the 
        /// <see cref="Array" /> that extends from the first element to the specified index.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param> 
        /// 
        /// <returns>
        /// The zero-based index of the last occurrence of <paramref name="value" /> within the range of elements in 
        /// <paramref name="array" /> that extends from the first element to <paramref name="startIndex" />, if found; 
        /// otherwise, –1.
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.
        /// </exception>
        [Pure]
        public static int LastIndexOf<T>([NotNull] this T[] array, [CanBeNull] T value, int startIndex) {
            return Array.LastIndexOf(array, value, startIndex);
        }

        /// <summary>
        /// Searches for the specified object and returns the index of the last occurrence within the range of elements
        /// in the <see cref="Array" /> that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to search.</param>
        /// <param name="value">The object to locate in <paramref name="array" />.</param>
        /// <param name="startIndex">The zero-based starting index of the backward search.</param>
        /// <param name="count">The number of elements in the section to search.</param> 
        /// 
        /// <returns>
        /// The zero-based index of the last occurrence of <paramref name="value" /> within the range of elements 
        /// in <paramref name="array" /> that contains the number of elements specified in <paramref name="count" /> and
        /// ends at <paramref name="startIndex" />, if found; otherwise, –1.
        /// </returns>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex" /> is outside the range of valid indexes for <paramref name="array" />.
        /// -or-
        /// <paramref name="count" /> is less than zero.
        /// -or-
        /// <paramref name="startIndex" /> and <paramref name="count" /> do not specify a valid section in <paramref name="array" />.
        /// </exception>
        [Pure]
        public static int LastIndexOf<T>([NotNull] this T[] array, [CanBeNull] T value, int startIndex, int count) {
            return Array.LastIndexOf(array, value, startIndex, count);
        }

        /// <summary>
        /// Reverses the sequence of the elements in the entire one-dimensional <see cref="Array" />.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional <see cref="Array" /> to reverse.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="RankException"><paramref name="array" /> is multidimensional.</exception> 
        public static void Reverse<T>([NotNull] this T[] array) {
            Array.Reverse(array);
        }

        /// <summary>
        /// Reverses the sequence of the elements in the entire one-dimensional <see cref="Array" />.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional <see cref="Array" /> to reverse.</param>
        /// <param name="index">The starting index of the section to reverse.</param>
        /// <param name="length">The number of elements in the section to reverse.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="RankException"><paramref name="array" /> is multidimensional.</exception> 
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than the lower bound of <paramref name="array" />.
        /// -or-
        /// <paramref name="length" /> is less than zero.
        /// </exception>
        public static void Reverse<T>([NotNull] this T[] array, int index, int length) {
            Array.Reverse(array, index, length);
        }

        /// <summary>
        /// Sorts the elements in an entire <see cref="Array" /> using the <see cref="IComparable{T}" /> generic interface implementation
        /// of each element of the <see cref="Array" />.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to sort.</param>
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// One or more elements in <paramref name="array" /> do not implement the <see cref="IComparable{T}" /> generic interface.
        /// </exception>
        public static void Sort<T>([NotNull] this T[] array) {
            Array.Sort(array);
        }

        /// <summary>
        /// Sorts the elements in an entire <see cref="Array" /> using the the specified <see cref="Comparison{T}" />.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to sort.</param>
        /// <param name="comparison">The <see cref="Comparison{T}" /> to use when comparing elements.</param>
        /// 
        /// <exception cref="ArgumentNullException">
        /// <paramref name="array" /> is null.
        /// -or-
        /// <paramref name="comparison" /> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The implementation of <paramref name="comparison" /> caused an error during the sort.
        /// For example, <paramref name="comparison" /> might not return 0 when comparing an item with itself.
        /// </exception>
        public static void Sort<T>([NotNull] this T[] array, [NotNull] [InstantHandle] Comparison<T> comparison) {
            Array.Sort(array, comparison);
        }

        /// <summary>
        /// Sorts the elements in an entire <see cref="Array" /> using the specified <see cref="IComparer{T}" /> 
        /// generic interface implementation.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to sort.</param>
        /// <param name="comparer">
        /// The <see cref="IComparer{T}" /> generic interface implementation to use when comparing 
        /// elements, or null to use the <see cref="IComparable{T}" /> generic interface implementation of each element.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="comparer" /> is null, and one or more elements in <paramref name="array" />
        /// do not implement the <see cref="IComparable{T}" /> generic interface.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The implementation of <paramref name="comparer" /> caused an error during the sort.
        /// For example, <paramref name="comparer" /> might not return 0 when comparing an item with itself.
        /// </exception>
        public static void Sort<T>([NotNull] this T[] array, [NotNull] IComparer<T> comparer) {
            Array.Sort(array, comparer);
        }

        /// <summary>
        /// Sorts the elements in a range of elements in an <see cref="Array" /> using the <see cref="IComparable{T}" />
        /// generic interface implementation of each element of the <see cref="Array" />.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to sort.</param>
        /// <param name="index">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than the lower bound of <paramref name="array" />.
        /// -or-
        /// <paramref name="length" /> is less than zero.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="index" /> and <paramref name="length" /> do not specify a valid range in <paramref name="array" />.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// One or more elements in <paramref name="array" /> do not implement the <see cref="IComparable{T}" /> generic interface.
        /// </exception>
        public static void Sort<T>([NotNull] this T[] array, int index, int length) {
            Array.Sort(array, index, length);
        }

        /// <summary>
        /// Sorts the elements in a range of elements in an <see cref="Array" /> using the specified <see cref="IComparer{T}" /> 
        /// generic interface implementation.
        /// </summary>
        /// 
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The one-dimensional, zero-based <see cref="Array" /> to sort.</param>
        /// <param name="index">The starting index of the range to sort.</param>
        /// <param name="length">The number of elements in the range to sort.</param>
        /// <param name="comparer">
        /// The <see cref="IComparer{T}" /> generic interface implementation to use when comparing 
        /// elements, or null to use the <see cref="IComparable{T}" /> generic interface implementation of each element.
        /// </param>
        /// 
        /// <exception cref="ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="index" /> is less than the lower bound of <paramref name="array" />.
        /// -or-
        /// <paramref name="length" /> is less than zero.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="index" /> and <paramref name="length" /> do not specify a valid range in <paramref name="array" />.
        /// -or-
        /// The implementation of <paramref name="comparer" /> caused an error during the sort. For example,
        /// <paramref name="comparer" /> might not return 0 when comparing an item with itself.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="comparer" /> is null, and one or more elements in <paramref name="array" /> 
        /// do not implement the <see cref="IComparable{T}" /> generic interface.
        /// </exception>
        public static void Sort<T>([NotNull] this T[] array, int index, int length, [NotNull] IComparer<T> comparer) {
            Array.Sort(array, index, length, comparer);
        }
    }
}
