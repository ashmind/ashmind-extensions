using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on Int32.
    /// </summary>
    public static class Int32Extensions {
        /// <summary>
        /// Repeats the specified action given number of times.
        /// </summary>
        /// <param name="count">Count of times action should be repeated.</param>
        /// <param name="action">Action to repeat.</param>
        public static void Times(this int count, [NotNull] [InstantHandle] Action action) {
            for (var i = 0; i < count; i++) {
                action();
            }
        }

        /// <summary>
        /// Repeats the specified action given number of times.
        /// </summary>
        /// <param name="count">Count of times action should be repeated.</param>
        /// <param name="action">Action to repeat, receives current repetition index (starting from 0).</param>
        public static void Times(this int count, [NotNull] [InstantHandle] Action<int> action) {
            for (var i = 0; i < count; i++) {
                action(i);
            }
        }

        /// <summary>
        /// Repeats the specified function given number of times and collects all results into an array.
        /// </summary>
        /// <typeparam name="T">Type of the function return value.</typeparam>
        /// <param name="count">Count of times function should be repeated.</param>
        /// <param name="func">Function to repeat</param>
        /// <returns>Array of all function call results.</returns>
        [NotNull]
        public static T[] Times<T>(this int count, [NotNull] [InstantHandle] Func<T> func) {
            return Enumerable.Range(0, count).Select(i => func()).ToArray();
        }

        /// <summary>
        /// Repeats the specified function given number of times and collects all results into an array.
        /// </summary>
        /// <typeparam name="T">Type of the function return value.</typeparam>
        /// <param name="count">Count of times function should be repeated.</param>
        /// <param name="func">Function to repeat, receives current repetition index (starting from 0).</param>
        /// <returns>Array of all function call results.</returns>
        [NotNull]
        public static T[] Times<T>(this int count, [NotNull] [InstantHandle] Func<int, T> func) {
            return Enumerable.Range(0, count).Select(func).ToArray();
        }
    }
}
