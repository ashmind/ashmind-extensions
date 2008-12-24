using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            values.ForEach(collection.Add);
        }

        public static void RemoveRange<T>(this ICollection<T> collection, IEnumerable<T> values)
        {
            values.ForEach(item => collection.Remove(item));
        }
    }
}
