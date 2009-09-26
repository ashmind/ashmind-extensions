using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Extensions
{
    public static class TimeExtensions
    {
        public static TimeSpan Days(this double value)
        {
            return TimeSpan.FromDays(value);
        }

        public static TimeSpan Hours(this double value)
        {
            return TimeSpan.FromHours(value);
        }
        
        public static TimeSpan Minutes(this double value)
        {
            return TimeSpan.FromMinutes(value);
        }

        public static TimeSpan Seconds(this double value)
        {
            return TimeSpan.FromSeconds(value);
        }

        public static TimeSpan Milliseconds(this double value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        public static TimeSpan Days(this int value)
        {
            return TimeSpan.FromDays(value);
        }

        public static TimeSpan Hours(this int value)
        {
            return TimeSpan.FromHours(value);
        }

        public static TimeSpan Minute(this int value) {
            return TimeSpan.FromMinutes(value);
        }

        public static TimeSpan Minutes(this int value)
        {
            return TimeSpan.FromMinutes(value);
        }

        public static TimeSpan Seconds(this int value)
        {
            return TimeSpan.FromSeconds(value);
        }

        public static TimeSpan Milliseconds(this int value)
        {
            return TimeSpan.FromMilliseconds(value);
        }

        public static DateTime Ago(this TimeSpan value)
        {
            return DateTime.Now - value;
        }
    }
}
