using System;
using System.Collections.Generic;
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
        /// Converts Func{T, bool} into a <see cref="Predicate{T}" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns>Predicate{T} identical to the original function.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Predicate<T> AsPredicate<T>([NotNull] this Func<T, bool> function) {
            return As<Predicate<T>>(function);
        }

        /// <summary>
        /// Converts <see cref="Predicate{T}" /> into a Func{T, bool}.
        /// </summary>
        /// <param name="predicate">A predicate to convert.</param>
        /// <returns>Func{T, bool} identical to the original predicate.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Func<T, bool> AsFunc<T>([NotNull] this Predicate<T> predicate) {
            return As<Func<T, bool>>(predicate);
        }

        /// <summary>
        /// Converts Func{T, T, int} into a <see cref="Comparison{T}" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns><see cref="Comparison{T}" /> identical to the original function.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Comparison<T> AsComparison<T>([NotNull] this Func<T, T, int> function) {
            return As<Comparison<T>>(function);
        }

        /// <summary>
        /// Converts <see cref="Comparison{T}" /> into a Func{T, T, int}.
        /// </summary>
        /// <param name="comparison">A comparison to convert.</param>
        /// <returns>Func{T, T, int} identical to the original comparison.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static Func<T, T, int> AsFunc<T>([NotNull] this Comparison<T> comparison) {
            return As<Func<T, T, int>>(comparison);
        }

        #if No_MethodInfo_CreateDelegate
        [Contracts.Pure] [NotNull]
        private static TDelegate As<TDelegate>([NotNull] Delegate @delegate) {
            return (TDelegate)(object)Delegate.CreateDelegate(typeof(TDelegate), @delegate.Target, @delegate.Method);
        }
        #else
        [Contracts.Pure] [NotNull]
        private static TDelegate As<TDelegate>([NotNull] Delegate @delegate) {
            var method = @delegate.GetMethodInfo();
            if (method == null)
                throw new ArgumentException("Delegate does not have a method info.", nameof(@delegate));

            return (TDelegate)(object)method.CreateDelegate(typeof(TDelegate), @delegate.Target);
        }
        #endif

        /// <summary>
        /// Converts <see cref="Comparison{T}" /> into an <see cref="IComparer{T}" />.
        /// </summary>
        /// <param name="comparison">A comparison to convert.</param>
        /// <returns><see cref="IComparer{T}" /> that acts identical to the original comparison.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static IComparer<T> ToComparer<T>([NotNull] this Comparison<T> comparison) {
            return new DelegateBasedComparer<T>(comparison);
        }

        /// <summary>
        /// Converts Func{T, T, int} into an <see cref="IComparer{T}" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns><see cref="IComparer{T}" /> that acts identical to the original function.</returns>
        [Contracts.Pure] [Pure] [NotNull]
        public static IComparer<T> ToComparer<T>([NotNull] this Func<T, T, int> function) {
            return new DelegateBasedComparer<T>(function.AsComparison());
        }
    }
}
