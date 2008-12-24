using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
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
        
        public static string Format(this string format, object arg0) {
            return string.Format(format, arg0);
        }

        public static string Format(this string format, params object[] args) {
            return string.Format(format, args);
        }

        public static string Format(this string format, IFormatProvider provider, params object[] args) {
            return string.Format(provider, format, args);
        }

        public static string Format(this string format, object arg0, object arg1) {
            return string.Format(format, arg0, arg1);
        }

        public static string Format(this string format, object arg0, object arg1, object arg2) {
            return string.Format(format, arg0, arg1, arg2);
        }
    }
}
