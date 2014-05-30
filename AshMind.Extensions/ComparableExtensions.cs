using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on IComparable&lt;&gt;.
    /// </summary>
    public static class ComparableExtensions {
        /// <summary>
        /// Determines whether the specified value is greater than another value.
        /// </summary>
        /// <typeparam name="TComparable">Type of the value to check.</typeparam>
        /// <typeparam name="T">Type that the value can be compared with.</typeparam>
        /// <param name="left">The value to compare</param>
        /// <param name="right">Value to compare with</param>
        /// <returns>
        /// True if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, false.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsGreaterThan<TComparable, T>([NotNull] this TComparable left, T right)
            where TComparable : IComparable<T>
        {
            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Determines whether the specified value is lesser than another value.
        /// </summary>
        /// <typeparam name="TComparable">Type of the value to check.</typeparam>
        /// <typeparam name="T">Type that the value can be compared with.</typeparam>
        /// <param name="left">The value to compare</param>
        /// <param name="right">Value to compare with</param>
        /// <returns>
        /// True if <paramref name="left" /> is lesser than <paramref name="right" />; otherwise, false.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsLesserThan<TComparable, T>([NotNull] this TComparable left, T right)
            where TComparable : IComparable<T>
        {
            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Determines whether the specified value is greater than or equal to another value.
        /// </summary>
        /// <typeparam name="TComparable">Type of the value to check.</typeparam>
        /// <typeparam name="T">Type that the value can be compared with.</typeparam>
        /// <param name="left">The value to compare</param>
        /// <param name="right">Value to compare with</param>
        /// <returns>
        /// True if <paramref name="left" /> is greater than or equal to <paramref name="right" />; otherwise, false.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsGreaterThanOrEqual<TComparable, T>([NotNull] this TComparable left, T right)
            where TComparable : IComparable<T> 
        {
            return !left.IsLesserThan(right);
        }

        /// <summary>
        /// Determines whether the specified value is lesser than or equal to another value.
        /// </summary>
        /// <typeparam name="TComparable">Type of the value to check.</typeparam>
        /// <typeparam name="T">Type that the value can be compared with.</typeparam>
        /// <param name="left">The value to compare</param>
        /// <param name="right">Value to compare with</param>
        /// <returns>
        /// True if <paramref name="left" /> is lesser than or equal to <paramref name="right" />; otherwise, false.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsLesserThanOrEqual<TComparable, T>([NotNull] this TComparable left, T right)
            where TComparable : IComparable<T> 
        {
            return !left.IsGreaterThan(right);
        }

        /// <summary>
        /// Determines whether the specified value is between two other values, inclusive.
        /// </summary>
        /// <typeparam name="TComparable">Type of the value to check.</typeparam>
        /// <typeparam name="T">Type that the value can be compared with.</typeparam>
        /// <param name="value">The value to compare</param>
        /// <param name="left">Minimum value that can cause true to be returned</param>
        /// <param name="right">Maximum value that can cause true to be returned</param>
        /// <returns>
        /// True if the specified value is between the minimm and maximum; otherwise, false.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsBetween<TComparable, T>([NotNull] this TComparable value, T left, T right)
            where TComparable : IComparable<T> 
        {
            return !value.IsLesserThan(left) && !value.IsGreaterThan(right);
        }
    }
}
