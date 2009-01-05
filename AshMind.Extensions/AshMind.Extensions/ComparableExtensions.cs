using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    public static class ComparableExtensions {
        public static bool IsGreaterThan<TComparable, T>(this TComparable left, T right)
            where TComparable : IComparable<T>
        {
            return left.CompareTo(right) > 0;
        }

        public static bool IsLesserThan<TComparable, T>(this TComparable left, T right)
            where TComparable : IComparable<T>
        {
            return left.CompareTo(right) < 0;
        }
    }
}
