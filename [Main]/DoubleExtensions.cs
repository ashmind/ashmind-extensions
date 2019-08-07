using System;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;

using static AshMind.Extensions.Internal.ObsoleteMessages;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on Double.
    /// </summary>
    public static class DoubleExtensions {
        /// <summary>Returns a value indicating whether the specified number evaluates to a value that is not a number (<see cref="Double.NaN" />).</summary>
        /// <param name="value">A <see cref="Double" /> value.</param>
        /// <returns>true if <paramref name="value" /> evaluates to <see cref="Double.NaN" />; otherwise, false.</returns>
        /// <seealso cref="Double.IsNaN"/>
        [Contracts.Pure] [Pure]
        [Obsolete(MethodWillBeRemovedInVersion4StaticConsistency)]
        public static bool IsNaN(this double value) {
            return Double.IsNaN(value);
        }

        /// <summary>
        ///     Returns a value indicating whether the specified number evaluates to positive or negative infinity.
        /// </summary>
        /// <param name="value">A <see cref="Double" /> value.</param>
        /// <returns>
        ///     true if <paramref name="value" /> evaluates to <see cref="Double.PositiveInfinity" /> or <see cref="Double.NegativeInfinity" />; otherwise, false.
        /// </returns>
        /// <seealso cref="Double.IsInfinity"/>
        [Contracts.Pure] [Pure]
        [Obsolete(MethodWillBeRemovedInVersion4StaticConsistency)]
        public static bool IsInfinity(this double value) {
            return Double.IsInfinity(value);
        }

        /// <summary>
        ///     Returns a value indicating whether the specified number evaluates to positive infinity.
        /// </summary>
        /// <param name="value">A <see cref="Double" /> value.</param>
        /// <returns>
        ///     true if <paramref name="value" /> evaluates to <see cref="Double.PositiveInfinity" />; otherwise, false.
        /// </returns>
        /// <seealso cref="Double.IsPositiveInfinity"/>
        [Contracts.Pure] [Pure]
        [Obsolete(MethodWillBeRemovedInVersion4StaticConsistency)]
        public static bool IsPositiveInfinity(this double value) {
            return Double.IsPositiveInfinity(value);
        }

        /// <summary>
        ///     Returns a value indicating whether the specified number evaluates to negative infinity.
        /// </summary>
        /// <param name="value">A <see cref="Double" /> value.</param>
        /// <returns>
        ///     true if <paramref name="value" /> evaluates to <see cref="Double.NegativeInfinity" />; otherwise, false.
        /// </returns>
        /// <seealso cref="Double.IsPositiveInfinity"/>
        [Contracts.Pure] [Pure]
        [Obsolete(MethodWillBeRemovedInVersion4StaticConsistency)]
        public static bool IsNegativeInfinity(this double value) {
            return Double.IsNegativeInfinity(value);
        }
    }
}
