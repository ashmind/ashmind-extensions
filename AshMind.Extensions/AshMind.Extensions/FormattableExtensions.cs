using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on IFormattable&lt;&gt;.
    /// </summary>
    public static class FormattableExtensions {
        /// <summary>
        /// Formats the value using the specified format provider.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <param name="provider">The provider to use to format the value.</param>
        /// <returns>The <paramref name="value"/> in the specified format.</returns>
        [DebuggerStepThrough]
        public static string ToString(this IFormattable value, IFormatProvider provider) {
            return value.ToString(null, provider);
        }

        /// <summary>
        /// Formats the value using the invariant culture format provider.
        /// </summary>
        /// <param name="value">The value to be formatted.</param>
        /// <returns>The <paramref name="value"/>, formatted using invariant culture format provider.</returns>
        [DebuggerStepThrough]
        public static string ToInvariantString(this IFormattable value) {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
