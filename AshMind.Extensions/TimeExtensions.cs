using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.Extensions {
    public static class TimeExtensions {
        [Pure]
        public static TimeSpan Days(this double value) {
            return TimeSpan.FromDays(value);
        }

        [Pure]
        public static TimeSpan Hours(this double value) {
            return TimeSpan.FromHours(value);
        }

        [Pure]
        public static TimeSpan Minutes(this double value) {
            return TimeSpan.FromMinutes(value);
        }

        [Pure]
        public static TimeSpan Seconds(this double value) {
            return TimeSpan.FromSeconds(value);
        }

        [Pure]
        public static TimeSpan Milliseconds(this double value) {
            return TimeSpan.FromMilliseconds(value);
        }

        [Pure]
        public static TimeSpan Days(this int value) {
            return TimeSpan.FromDays(value);
        }

        [Pure]
        public static TimeSpan Hours(this int value) {
            return TimeSpan.FromHours(value);
        }

        [Pure]
        public static TimeSpan Minute(this int value) {
            return TimeSpan.FromMinutes(value);
        }

        [Pure]
        public static TimeSpan Minutes(this int value) {
            return TimeSpan.FromMinutes(value);
        }

        [Pure]
        public static TimeSpan Seconds(this int value) {
            return TimeSpan.FromSeconds(value);
        }

        [Pure]
        public static TimeSpan Milliseconds(this int value) {
            return TimeSpan.FromMilliseconds(value);
        }

        [Pure]
        public static DateTime Ago(this TimeSpan value) {
            return DateTime.Now - value;
        }
    }
}
