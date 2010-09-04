using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace AshMind.Extensions {
    public static class EnumerableExtensions {
        /// <summary>
        /// Determines whether any element of a sequence satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">
        ///   The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        ///   An <see cref="IEnumerable{T}" /> whose elements to apply the predicate to.
        /// </param>
        /// <param name="predicate">
        ///   A function to test each element for a condition;
        ///   the second parameter of the function represents the index of the element.
        /// </param>
        /// <returns>
        ///   <c>true</c> if any elements in the source sequence pass the test in the specified predicate; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Enumerable.Any{T}" />
        [DebuggerStepThrough]
        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate) {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            Contract.EndContractBlock();

            var index = 0;
            foreach (var item in source) {
                if (predicate(item, index))
                    return true;

                index += 1;
            }

            return false;
        }

        /// <summary>
        ///   Creates a <see cref="HashSet{T}" /> from an <see cref="IEnumerable{T}" />.
        /// </summary>
        /// <typeparam name="TSource">
        ///   The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        ///   The <see cref="IEnumerable{T}" /> to create a <see cref="HashSet{T}" /> from.
        /// </param>
        /// <returns>
        ///   A <see cref="HashSet{T}" /> that contains elements from the input sequence.
        /// </returns>
        [DebuggerStepThrough]
        public static HashSet<TSource> ToSet<TSource>(this IEnumerable<TSource> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            Contract.EndContractBlock();

            return new HashSet<TSource>(source);
        }

        /// <summary>
        ///   Creates a <see cref="HashSet{T}" /> from an <see cref="IEnumerable{T}" /> according to a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">
        ///   The type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">
        ///   The <see cref="IEnumerable{T}" /> to create a <see cref="HashSet{T}" /> from.
        /// </param>
        /// <param name="comparer">
        ///   The <see cref="IEqualityComparer{T}" /> to compare items.
        /// </param>
        /// <returns>
        ///   A <see cref="HashSet{T}" /> that contains elements from the input sequence.
        /// </returns>
        [DebuggerStepThrough]
        public static HashSet<TSource> ToSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer) {
            if (source == null)
                throw new ArgumentNullException("source");
            Contract.EndContractBlock();

            return new HashSet<TSource>(source, comparer);
        }

        [DebuggerStepThrough]
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action) {
            source.ForEach((item, index) => action(item));
        }

        [DebuggerStepThrough]
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action) {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");
            Contract.EndContractBlock();

            var index = 0;
            foreach (var item in source) {
                action(item, index);
                index += 1;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> source, TSource item) {
            if (source == null)
                throw new ArgumentNullException("source");
            Contract.EndContractBlock();

            foreach (var eachItem in source) {
                if (Equals(eachItem, item))
                    continue;

                yield return eachItem;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, TSource item) {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var each in source) {
                yield return each;
            }
            yield return item;
        }

        [DebuggerStepThrough]
        public static IEnumerable<TSource> HavingMax<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector) {
            return source.HavingMaxOrMin(selector, 1);
        }

        [DebuggerStepThrough]
        public static IEnumerable<TSource> HavingMin<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector) {
            return source.HavingMaxOrMin(selector, -1);
        }

        [DebuggerStepThrough]
        private static IEnumerable<TSource> HavingMaxOrMin<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector, int comparison) {
            if (source == null)
                throw new ArgumentNullException("source");

            if (selector == null)
                throw new ArgumentNullException("selector");

            var selectedItems = new List<TSource>();
            var selectedValue = default(TValue);
            var selected = false;

            var comparer = Comparer<TValue>.Default;

            foreach (var item in source) {
                var compared = comparer.Compare(selector(item), selectedValue);
                
                if (!selected || compared == comparison) {
                    selectedItems = new List<TSource> { item };
                    selectedValue = selector(item);
                    selected = true;

                    continue;
                }

                if (compared == 0)
                    selectedItems.Add(item);
            }

            return selectedItems;
        }
    }
}
