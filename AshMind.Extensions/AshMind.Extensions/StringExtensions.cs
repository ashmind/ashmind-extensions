using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on String.
    /// </summary>
    public static class StringExtensions {
        public static bool IsNullOrEmpty(this string value) {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullOrEmpty(this string value) {
            return !string.IsNullOrEmpty(value);
        }

        public static string[] Split(this string value, params string[] separator) {
            return value.Split(separator, StringSplitOptions.None);
        }

        /// <summary>
        /// Returns a value indicating whether the specified String object occurs within this string.
        /// </summary>
        /// <param name="original">The <see cref="String" /> value to be analyzed.</param>
        /// <param name="value">The <see cref="String" /> object to seek.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison" /> values that determines how this string and value are compared.</param>
        /// <returns>
        ///     <c>true</c> if the value parameter occurs within this string, or if value is the empty string (""); otherwise, <c>false</c>.
        /// </returns>
        public static bool Contains(this string original, string value, StringComparison comparisonType) {
            return original.IndexOf(value, comparisonType) >= 0;
        }
    }
}
