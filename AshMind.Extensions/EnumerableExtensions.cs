using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#if Contracts
using System.Diagnostics.Contracts;
using PureAttribute = System.Diagnostics.Contracts.PureAttribute;
#endif

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="IEnumerable{T}" />. 
    /// </summary>
    public static class EnumerableExtensions {
        /// <summary>Returns the elements of the specified sequence or an empty sequence if the sequence is <c>null</c>.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence to process.</param>
        /// <returns><paramref name="source"/> if it is not <c>null</c>; otherwise, <see cref="Enumerable.Empty{TSource}"/>.</returns>
        [Pure]
        public static IEnumerable<TSource> EmptyIfNull<TSource>([CanBeNull] this IEnumerable<TSource> source) {
            return source ?? Enumerable.Empty<TSource>();
        }

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
        [Pure]
        public static bool Any<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Func<TSource, int, bool> predicate) {
            if (source == null)
                throw new ArgumentNullException("source");
            if (predicate == null)
                throw new ArgumentNullException("predicate");
            #if Contracts
            Contract.EndContractBlock();
            #endif

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
        [Pure] [NotNull]
        public static HashSet<TSource> ToSet<TSource>([NotNull] this IEnumerable<TSource> source) {
            if (source == null)
                throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

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
        [Pure] [NotNull]
        public static HashSet<TSource> ToSet<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] IEqualityComparer<TSource> comparer) {
            if (source == null)
                throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return new HashSet<TSource>(source, comparer);
        }

        public static void ForEach<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Action<TSource> action) {
            source.ForEach((item, index) => action(item));
        }

        public static void ForEach<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Action<TSource, int> action) {
            if (source == null)
                throw new ArgumentNullException("source");
            if (action == null)
                throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            var index = 0;
            foreach (var item in source) {
                action(item, index);
                index += 1;
            }
        }

        [Pure]
        public static IEnumerable<TSource> Except<TSource>([NotNull] this IEnumerable<TSource> source, [CanBeNull] TSource item) {
            if (source == null)
                throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            foreach (var eachItem in source) {
                if (Equals(eachItem, item))
                    continue;

                yield return eachItem;
            }
        }

        [Pure]
        public static IEnumerable<TSource> Concat<TSource>([NotNull] this IEnumerable<TSource> source, [CanBeNull] TSource item) {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var each in source) {
                yield return each;
            }
            yield return item;
        }

        [Pure]
        public static IEnumerable<TSource> HavingMax<TSource, TValue>([NotNull] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Func<TSource, TValue> selector) {
            return source.HavingMaxOrMin(selector, 1);
        }

        [Pure]
        public static IEnumerable<TSource> HavingMin<TSource, TValue>([NotNull] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Func<TSource, TValue> selector) {
            return source.HavingMaxOrMin(selector, -1);
        }

        [Pure]
        private static IEnumerable<TSource> HavingMaxOrMin<TSource, TValue>([NotNull] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Func<TSource, TValue> selector, int comparison) {
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
