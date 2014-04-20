using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using AshMind.Extensions.Internal;

#if Contracts
using System.Diagnostics.Contracts;
using PureAttribute = System.Diagnostics.Contracts.PureAttribute;
#endif

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="IEnumerable{T}" />. 
    /// </summary>
    public static class EnumerableExtensions {
        #region Identity

        private static class Functions<TElement> {
            [NotNull]
            public static readonly Func<TElement, TElement> Identity = x => x;
        }

        #endregion

        /// <summary>Returns the elements of the specified sequence or an empty sequence if the sequence is <c>null</c>.</summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">The sequence to process.</param>
        /// <returns><paramref name="source"/> if it is not <c>null</c>; otherwise, <see cref="Enumerable.Empty{TSource}"/>.</returns>
        [Pure] [NotNull]
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
        public static bool Any<TSource>([NotNull] [InstantHandle] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Func<TSource, int, bool> predicate) {
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

        public static void ForEach<TSource>([NotNull] [InstantHandle] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Action<TSource> action) {
            source.ForEach((item, index) => action(item));
        }

        public static void ForEach<TSource>([NotNull] [InstantHandle] this IEnumerable<TSource> source, [NotNull] [InstantHandle] Action<TSource, int> action) {
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

        [Pure] [NotNull]
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

        /// <summary>
        /// Creates a new sequence that consists of the original sequence followed by the provided item.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
        /// <param name="source">The source sequence to concatenate.</param>
        /// <param name="item">The item to concatenate with the source sequence.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> that contains all elements from <paramref name="source" />, then value of <paramref name="item" />.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TSource> Concat<TSource>([NotNull] this IEnumerable<TSource> source, [CanBeNull] TSource item) {
            if (source == null)
                throw new ArgumentNullException("source");

            foreach (var each in source) {
                yield return each;
            }
            yield return item;
        }

        [Pure] [NotNull]
        public static IEnumerable<TSource> HavingMax<TSource, TValue>([NotNull] this IEnumerable<TSource> source, [NotNull] Func<TSource, TValue> selector) {
            return source.HavingMaxOrMin(selector, 1);
        }

        [Pure] [NotNull]
        public static IEnumerable<TSource> HavingMin<TSource, TValue>([NotNull] this IEnumerable<TSource> source, [NotNull] Func<TSource, TValue> selector) {
            return source.HavingMaxOrMin(selector, -1);
        }

        [Pure] [NotNull]
        private static IEnumerable<TSource> HavingMaxOrMin<TSource, TValue>([NotNull] this IEnumerable<TSource> source, [NotNull] Func<TSource, TValue> selector, int comparison) {
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

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a specified key selector function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each <see cref="IGrouping{TKey, TSource}"/> object contains a sequence of objects and a key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacentBy<TSource, TKey>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector
        ) {
            if (source == null) throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return source.GroupAdjacentBy(keySelector, Functions<TSource>.Identity, null);
        }

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a specified key selector function and compares the keys by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys.</param>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each <see cref="IGrouping{TKey, TValue}"/> object contains a sequence of objects and a key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacentBy<TSource, TKey>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector,
            [CanBeNull] IEqualityComparer<TKey> comparer
        ) {
            if (source == null)      throw new ArgumentNullException("source");
            if (keySelector == null) throw new ArgumentNullException("keySelector");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return source.GroupAdjacentBy(keySelector, Functions<TSource>.Identity, comparer);
        }

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a specified key selector function and projects the elements for each group by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <typeparam name="TElement">The type of the elements in the <see cref="IGrouping{TKey, TValue}"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{TValue}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TValue}"/>.</param>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each <see cref="IGrouping{TKey, TValue}"/> object contains a sequence of objects and a key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacentBy<TSource, TKey, TElement>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] [InstantHandle] Func<TSource, TKey> keySelector,
            [NotNull] [InstantHandle] Func<TSource, TElement> elementSelector
        ) {
            if (source == null)          throw new ArgumentNullException("source");
            if (keySelector == null)     throw new ArgumentNullException("keySelector");
            if (elementSelector == null) throw new ArgumentNullException("elementSelector");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return source.GroupAdjacentBy(keySelector, elementSelector, null);
        }

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a key selector function. The keys are compared by using a comparer and each group's elements are projected by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <typeparam name="TElement">The type of the elements in the <see cref="IGrouping{TKey, TValue}"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TValue}"/>.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{TKey}"/> to compare keys.</param>
        /// <returns>
        /// An IEnumerable&lt;IGrouping&lt;TKey, TSource&gt;&gt; in C# or IEnumerable(Of IGrouping(Of TKey, TSource)) in Visual Basic where each <see cref="IGrouping{TKey, TValue}"/> object contains a sequence of objects and a key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacentBy<TSource, TKey, TElement>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] [InstantHandle] Func<TSource, TKey> keySelector,
            [NotNull] [InstantHandle] Func<TSource, TElement> elementSelector,
            [CanBeNull] IEqualityComparer<TKey> comparer
        ) {
            if (source == null)          throw new ArgumentNullException("source");
            if (keySelector == null)     throw new ArgumentNullException("keySelector");
            if (elementSelector == null) throw new ArgumentNullException("elementSelector");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return source.GroupAdjacentBy(keySelector, elementSelector, Grouping<TKey, TElement>.Create, comparer);
        }

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a specified key selector function and creates a result value from each group and its key.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <returns>
        /// A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="resultSelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TResult>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector,
            [NotNull] Func<TKey, IEnumerable<TSource>, TResult> resultSelector
        ) {
            return source.GroupAdjacentBy(keySelector, Functions<TSource>.Identity, resultSelector, null);
        }

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a specified key selector function and creates a result value from each group and its key. The elements of each group are projected by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TValue}"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TValue}"/>.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <returns>
        /// A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="elementSelector"/> or <paramref name="resultSelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TElement, TResult>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector,
            [NotNull] Func<TSource, TElement> elementSelector,
            [NotNull] Func<TKey, IEnumerable<TElement>, TResult> resultSelector
        ) {
            return source.GroupAdjacentBy(keySelector, elementSelector, resultSelector, null);
        }

        /// <summary>
        /// Groups the adjacent elements in a sequence according to a specified key selector function and creates a result value from each group and its key. The keys are compared by using a specified comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{TKey}"/> to compare keys with.</param>
        /// <returns>
        /// A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="resultSelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TResult>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector,
            [NotNull] Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
            [CanBeNull] IEqualityComparer<TKey> comparer
        ) {
            return source.GroupAdjacentBy(keySelector, Functions<TSource>.Identity, resultSelector, comparer);
        }

        /// <summary>
        /// Groups the adjacent elements of a sequence according to a specified key selector function and creates a result value from each group and its key. Key values are compared by using a specified comparer, and the elements of each group are projected by using a specified function.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <typeparam name="TElement">The type of the elements in each <see cref="IGrouping{TKey, TValue}"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result value returned by <paramref name="resultSelector"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to group.</param>
        /// <param name="keySelector">A function to extract the key for each element.</param>
        /// <param name="elementSelector">A function to map each source element to an element in an <see cref="IGrouping{TKey, TValue}"/>.</param>
        /// <param name="resultSelector">A function to create a result value from each group.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{TKey}"/> to compare keys with.</param>
        /// <returns>
        /// A collection of elements of type <typeparamref name="TResult"/> where each element represents a projection over a group and its key.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="keySelector"/> or <paramref name="resultSelector"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TElement, TResult>(
            [NotNull] this IEnumerable<TSource> source,
            [NotNull] Func<TSource, TKey> keySelector,
            [NotNull] Func<TSource, TElement> elementSelector,
            [NotNull] Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
            [CanBeNull] IEqualityComparer<TKey> comparer
        ) {
            if (source == null)          throw new ArgumentNullException("source");
            if (keySelector == null)     throw new ArgumentNullException("keySelector");
            if (elementSelector == null) throw new ArgumentNullException("elementSelector");
            if (resultSelector == null)  throw new ArgumentNullException("resultSelector");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            comparer = comparer ?? EqualityComparer<TKey>.Default;

            var lastKey = default(TKey);
            var lastGroup = (List<TElement>)null;
            foreach (var item in source) {
                var key = keySelector(item);

                if (lastGroup == null || !comparer.Equals(lastKey, key)) {
                    if (lastGroup != null)
                        yield return resultSelector(lastKey, lastGroup);

                    lastGroup = new List<TElement>();
                    lastKey = key;
                }

                lastGroup.Add(elementSelector(item));
            }

            if (lastGroup != null)
                yield return resultSelector(lastKey, lastGroup);
        }

        /// <summary>
        /// Registers an action to be executed before the first element of a sequence is returned during enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> which should be used as a template for the result sequence.</param>
        /// <param name="action">An action that should be performed before first item is returned during enumeration.</param>
        /// <returns>
        /// A new sequence which is identical to <paramref name="source"/> when enumerated, but executes <paramref name="action" /> before returning the first item.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TSource> OnBeforeFirst<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] Action<TSource> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            var first = true;
            foreach (var value in source) {
                if (first) {
                    first = false;
                    action(value);
                }

                yield return value;
            }
        }

        /// <summary>
        /// Registers an action to be executed before each element of a sequence is returned during enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> which should be used as a template for the result sequence.</param>
        /// <param name="action">An action that should be performed before each item is returned during enumeration.</param>
        /// <returns>
        /// A new sequence which is identical to <paramref name="source"/> when enumerated, but executes <paramref name="action" /> before returning each item.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TSource> OnBeforeEach<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] Action<TSource> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            foreach (var value in source) {
                action(value);
                yield return value;
            }
        }

        /// <summary>
        /// Registers an action to be executed before each element of a sequence is returned during enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> which should be used as a template for the result sequence.</param>
        /// <param name="action">An action that should be performed before each item is returned during enumeration, receiving an item and its index.</param>
        /// <returns>
        /// A new sequence which is identical to <paramref name="source"/> when enumerated, but executes <paramref name="action" /> before returning each item.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is null.</exception>
        [Pure]
        [NotNull]
        public static IEnumerable<TSource> OnBeforeEach<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] Action<TSource, int> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            var index = 0;
            foreach (var value in source) {
                action(value, index);
                yield return value;
                index += 1;
            }
        }

        /// <summary>
        /// Registers an action to be executed after each element of a sequence is returned during enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> which should be used as a template for the result sequence.</param>
        /// <param name="action">An action that should be performed after each item is returned during enumeration.</param>
        /// <returns>
        /// A new sequence which is identical to <paramref name="source"/> when enumerated, but executes <paramref name="action" /> after returning each item.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TSource> OnAfterEach<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] Action<TSource> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            foreach (var value in source) {
                yield return value;
                action(value);
            }
        }

        /// <summary>
        /// Registers an action to be executed after each element of a sequence is returned during enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> which should be used as a template for the result sequence.</param>
        /// <param name="action">An action that should be performed after each item is returned during enumeration, receiving an item and its index.</param>
        /// <returns>
        /// A new sequence which is identical to <paramref name="source"/> when enumerated, but executes <paramref name="action" /> after returning each item.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is null.</exception>
        [Pure]
        [NotNull]
        public static IEnumerable<TSource> OnAfterEach<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] Action<TSource, int> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            var index = 0;
            foreach (var value in source) {
                yield return value;
                action(value, index);
                index += 1;
            }
        }

        /// <summary>
        /// Registers an action to be executed after the last element of a sequence is returned during enumeration.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An <see cref="IEnumerable{T}"/> which should be used as a template for the result sequence.</param>
        /// <param name="action">An action that should be performed after the last item is returned during enumeration.</param>
        /// <returns>
        /// A new sequence which is identical to <paramref name="source"/> when enumerated, but executes <paramref name="action" /> after returning the last item.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="action"/> is null.</exception>
        [Pure] [NotNull]
        public static IEnumerable<TSource> OnAfterLast<TSource>([NotNull] this IEnumerable<TSource> source, [NotNull] Action<TSource> action) {
            if (source == null) throw new ArgumentNullException("source");
            if (action == null) throw new ArgumentNullException("action");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            TSource last = default(TSource);
            var empty = true;
            foreach (var value in source) {
                empty = false;
                last = value;
                yield return value;
            }

            if (!empty)
                action(last);
        }

        /// <summary>
        ///   Converts an <see cref="IEnumerable{T}" /> to an <see cref="ICollection{T}" />.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence to convert.</param>
        /// <returns>
        /// Either <paramref name="source"/> if it can be cast to <see cref="ICollection{T}"/>; or a new ICollection&lt;T&gt; created from <c>source</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        [Pure] [NotNull]
        public static ICollection<TElement> AsCollection<TElement>([NotNull] this IEnumerable<TElement> source) {
            if (source == null) throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return (source as ICollection<TElement>) ?? source.ToList();
        }

        #if IReadOnlyCollection
        /// <summary>
        ///   Converts an <see cref="IEnumerable{T}" /> to an <see cref="IReadOnlyCollection{T}" />.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence to convert.</param>
        /// <returns>
        /// Either <paramref name="source"/> if it can be cast to <see cref="IReadOnlyCollection{T}"/>; or a new IReadOnlyCollection&lt;T&gt; created from <c>source</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        [Pure]
        [NotNull]
        public static IReadOnlyCollection<TElement> AsReadOnlyCollection<TElement>([NotNull] this IEnumerable<TElement> source) {
            if (source == null) throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return (source as IReadOnlyCollection<TElement>) ?? new ReadOnlyCollection<TElement>(source.AsList());
        }
        #endif

        /// <summary>
        ///   Converts an <see cref="IEnumerable{T}" /> to an <see cref="IList{T}" />.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence to convert.</param>
        /// <returns>
        /// Either <paramref name="source"/> if it can be cast to <see cref="IList{T}"/>; or a new IList&lt;T&gt; created from <c>source</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        [Pure]
        [NotNull]
        public static IList<TElement> AsList<TElement>([NotNull] this IEnumerable<TElement> source) {
            if (source == null) throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return (source as IList<TElement>) ?? source.ToList();
        }

        #if IReadOnlyList
        /// <summary>
        ///   Converts an <see cref="IEnumerable{T}" /> to an <see cref="IReadOnlyList{T}" />.
        /// </summary>
        /// <typeparam name="TElement">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A sequence to convert.</param>
        /// <returns>
        /// Either <paramref name="source"/> if it can be cast to <see cref="IReadOnlyList{T}"/>; or a new IReadOnlyList&lt;T&gt; created from <c>source</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is null.</exception>
        [Pure] [NotNull]
        public static IReadOnlyList<TElement> AsReadOnlyList<TElement>([NotNull] this IEnumerable<TElement> source) {
            if (source == null) throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return (source as IReadOnlyList<TElement>) ?? new ReadOnlyCollection<TElement>(source.AsList());
        }
        #endif
        
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
        public static HashSet<TSource> ToSet<TSource>([NotNull] [InstantHandle] this IEnumerable<TSource> source) {
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
        public static HashSet<TSource> ToSet<TSource>([NotNull] [InstantHandle] this IEnumerable<TSource> source, [NotNull] IEqualityComparer<TSource> comparer) {
            if (source == null)
                throw new ArgumentNullException("source");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return new HashSet<TSource>(source, comparer);
        }
    }
}
