using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on delegates. 
    /// </summary>
    public static class DelegateExtensions {
        #region DelegateBasedComparer Class

        private class DelegateBasedComparer<T> : IComparer<T> {
            [NotNull] private readonly Comparison<T> comparison;

            public DelegateBasedComparer([NotNull] Comparison<T> comparison) {
                this.comparison = comparison;
            }

            public int Compare(T x, T y) {
                return comparison(x, y);
            }
        }

        #endregion

        /// <summary>
        /// Converts Func&lt;T, bool&gt; into a <see cref="Predicate&lt;T&gt;" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns>Predicate&lt;T&gt; identical to the original function.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Predicate<T> AsPredicate<T>([NotNull] this Func<T, bool> function) {
            return As<Predicate<T>>(function);
        }

        /// <summary>
        /// Converts <see cref="Predicate&lt;T&gt;" /> into a Func&lt;T, bool&gt;.
        /// </summary>
        /// <param name="predicate">A predicate to convert.</param>
        /// <returns>Func&lt;T, bool&gt; identical to the original predicate.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Func<T, bool> AsFunction<T>([NotNull] this Predicate<T> predicate) {
            return As<Func<T, bool>>(predicate);
        }

        /// <summary>
        /// Converts Func&lt;T, T, int&gt; into a <see cref="Comparison&lt;T&gt;" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns><see cref="Comparison&lt;T&gt;" /> identical to the original function.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Comparison<T> AsComparison<T>([NotNull] this Func<T, T, int> function) {
            return As<Comparison<T>>(function);
        }

        /// <summary>
        /// Converts <see cref="Comparison&lt;T&gt;" /> into a Func&lt;T, T, int&gt;.
        /// </summary>
        /// <param name="comparison">A comparison to convert.</param>
        /// <returns>Func&lt;T, T, int&gt; identical to the original comparison.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Func<T, T, int> AsFunction<T>([NotNull] this Comparison<T> comparison) {
            return As<Func<T, T, int>>(comparison);
        }

        #if MethodInfo_CreateDelegate
        [Contracts.Pure] [NotNull]
        private static TDelegate As<TDelegate>([NotNull] Delegate @delegate) {
            return (TDelegate)(object)@delegate.GetMethodInfo().CreateDelegate(typeof(TDelegate), @delegate.Target);
        }
        #else
        [Contracts.Pure] [NotNull]
        private static TDelegate As<TDelegate>([NotNull] Delegate @delegate) {
            return (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), @delegate.Target, @delegate.Method);
        }
        #endif

        /// <summary>
        /// Converts <see cref="Comparison&lt;T&gt;" /> into an <see cref="IComparer&lt;T&gt;" />.
        /// </summary>
        /// <param name="comparison">A comparison to convert.</param>
        /// <returns><see cref="IComparer&lt;T&gt;" /> that acts identical to the original comparison.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static IComparer<T> ToComparer<T>([NotNull] this Comparison<T> comparison) {
            return new DelegateBasedComparer<T>(comparison);
        }

        /// <summary>
        /// Converts Func&lt;T, T, int&gt; into an <see cref="IComparer&lt;T&gt;" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns><see cref="IComparer&lt;T&gt;" /> that acts identical to the original function.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static IComparer<T> ToComparer<T>([NotNull] this Func<T, T, int> function) {
            return new DelegateBasedComparer<T>(function.AsComparison());
        }
    }
}
