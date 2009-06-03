using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace AshMind.Extensions {
    public static class FormattableExtensions {
        [DebuggerStepThrough]
        public static string ToString(this IFormattable value, IFormatProvider provider) {
            return value.ToString(null, provider);
        }

        [DebuggerStepThrough]
        public static string ToStringInvariant(this IFormattable value) {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
