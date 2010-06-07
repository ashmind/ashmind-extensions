using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    public static class CollectionExtensions {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values) {
            var list = collection as List<T>;
            if (list != null) {
                list.AddRange(values);
                return;
            }

            values.ForEach(collection.Add);
        }

        public static void RemoveAll<T>(this ICollection<T> collection, IEnumerable<T> values) {
            values.ForEach(item => collection.Remove(item));
        }

        /// <summary>
        /// Removes all elements that match the conditions defined by the specified predicate from the collection.
        /// </summary>
        /// <param name="collection">
        /// The collection from which to remove items.
        /// </param>
        /// <param name="predicate">
        /// The Func&lt;T, bool&gt; delegate that defines the conditions of the elements to remove.
        /// </param>
        /// <returns>The number of elements that were removed from the collection.</returns>
        public static int RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate) {
            var concreteList = collection as List<T>;
            if (concreteList != null)
                return concreteList.RemoveAll(predicate.AsPredicate());

            var list = collection as IList<T>;
            if (list != null)
                return RemoveFromListWhere(list, (item, index) => predicate(item));

            var set = collection as HashSet<T>;
            if (set != null)
                return set.RemoveWhere(predicate.AsPredicate());
            
            var itemsToRemove = new List<T>();
            foreach (var item in collection) {
                if (predicate(item))
                    itemsToRemove.Add(item);
            }

            collection.RemoveAll(itemsToRemove);
            return itemsToRemove.Count;
        }

        /// <summary>
        /// Removes all elements that match the conditions defined by the specified predicate from the collection.
        /// </summary>
        /// <param name="collection">
        /// The collection from which to remove items.
        /// </param>
        /// <param name="predicate">
        /// The Func&lt;T, int, bool&gt; delegate that defines the conditions of the elements to remove;
        /// the second parameter of the delegate represents the index of the element.
        /// </param>
        /// <returns>The number of elements that were removed from the collection.</returns>
        public static int RemoveWhere<T>(this ICollection<T> collection, Func<T, int, bool> predicate) {
            var list = collection as IList<T>;
            if (list != null)
                return RemoveFromListWhere(list, predicate);

            var index = 0;
            var itemsToRemove = new List<T>();
            foreach (var item in collection) {
                if (predicate(item, index))
                    itemsToRemove.Add(item);

                index += 1;
            }
            collection.RemoveAll(itemsToRemove);
            return itemsToRemove.Count;
        }

        private static int RemoveFromListWhere<T>(IList<T> list, Func<T, int, bool> predicate) {
            var removedCount = 0;
            for (var i = list.Count - 1; i >= 0; i--) {
                if (!predicate(list[i], i))
                    continue;

                list.RemoveAt(i);
                removedCount += 1;
            }

            return removedCount;
        }
    }
}
