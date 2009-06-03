using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace AshMind.Extensions
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static HashSet<T> ToSet<T>(this IEnumerable<T> enumerable) {
            return new HashSet<T>(enumerable);
        }

        [DebuggerStepThrough]
        public static HashSet<T> ToSet<T>(this IEnumerable<T> enumerable, IEqualityComparer<T> comparer) {
            return new HashSet<T>(enumerable, comparer);
        }

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            enumerable.ForEach((item, index) => action(item));
        }

        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            int index = 0;
            foreach (T item in enumerable)
            {
                action(item, index);
                index += 1;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, T item) {
            foreach (var eachItem in items) {
                if (object.Equals(eachItem, item))
                    continue;

                yield return eachItem;
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T item) {
            foreach (var eachItem in items) {
                yield return eachItem;
            }
            yield return item;
        }
    }
}
