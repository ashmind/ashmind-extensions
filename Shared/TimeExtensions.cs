using System;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

namespace AshMind.Extensions {
    public static class TimeExtensions {
        [Contracts.Pure] [Pure] public static TimeSpan Day(this int value) => TimeSpan.FromDays(value);
        [Contracts.Pure] [Pure] public static TimeSpan Days(this int value) => TimeSpan.FromDays(value);
        [Contracts.Pure] [Pure] public static TimeSpan Hour(this int value) => TimeSpan.FromHours(value);
        [Contracts.Pure] [Pure] public static TimeSpan Hours(this int value) => TimeSpan.FromHours(value);
        [Contracts.Pure] [Pure] public static TimeSpan Minute(this int value) => TimeSpan.FromMinutes(value);
        [Contracts.Pure] [Pure] public static TimeSpan Minutes(this int value) => TimeSpan.FromMinutes(value);
        [Contracts.Pure] [Pure] public static TimeSpan Second(this int value) => TimeSpan.FromMinutes(value);
        [Contracts.Pure] [Pure] public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);
        [Contracts.Pure] [Pure] public static TimeSpan Millisecond(this int value) => TimeSpan.FromMinutes(value);
        [Contracts.Pure] [Pure] public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);
    }
}
