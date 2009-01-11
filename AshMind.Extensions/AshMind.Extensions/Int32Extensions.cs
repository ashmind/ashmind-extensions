using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on Int32.
    /// </summary>
    public static class Int32Extensions {
        /// <summary>
        /// Determines the specified value in between two other values, inclusive.
        /// </summary>
        /// <param name="value">The value to compare</param>
        /// <param name="left">Minimum value that can cause true to be returned</param>
        /// <param name="right">Maximum value that can cause true to be returned</param>
        /// <returns>
        /// True if the specified value is between the minimm and maximum; otherwise, false.
        /// </returns>
        public static bool IsBetween(this int value, int left, int right) {
            return value >= left && value <= right;
        }
    }
}
