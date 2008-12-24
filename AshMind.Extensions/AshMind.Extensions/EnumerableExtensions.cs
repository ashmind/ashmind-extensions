using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Extensions
{
    public static class EnumerableExtensions
    {
        public static HashSet<T> ToSet<T>(this IEnumerable<T> enumerable) {
            return new HashSet<T>(enumerable);
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            enumerable.ForEach((item, index) => action(item));
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            int index = 0;
            foreach (T item in enumerable)
            {
                action(item, index);
                index += 1;
            }
        }
    }
}
