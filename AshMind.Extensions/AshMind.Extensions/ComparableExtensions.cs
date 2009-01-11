using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on IComparable&lt;&gt;.
    /// </summary>
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

        /// <summary>
        /// Determines the specified value in between two other values, inclusive.
        /// </summary>
        /// <typeparam name="TComparable">Type of the value to check.</typeparam>
        /// <typeparam name="T">Type that the value can be compared with.</typeparam>
        /// <param name="value">The value to compare</param>
        /// <param name="left">Minimum value that can cause true to be returned</param>
        /// <param name="right">Maximum value that can cause true to be returned</param>
        /// <returns>
        /// True if the specified value is between the minimm and maximum; otherwise, false.
        /// </returns>
        public static bool IsBetween<TComparable, T>(this TComparable value, T left, T right)
            where TComparable : IComparable<T> 
        {
            return !value.IsLesserThan(left) && !value.IsGreaterThan(right);
        }
    }
}
