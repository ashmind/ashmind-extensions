using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;
using PureAttribute = JetBrains.Annotations.PureAttribute;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="MethodInfo" />.
    /// </summary>
    public static class MethodInfoExtensions {
        #if No_MethodInfo_CreateDelegate
        /// <summary>
        /// Creates a delegate of the specified type from a specified method.
        /// </summary>
        /// <param name="method">The method to create the delegate for.</param>
        /// <param name="delegateType">The type of the delegate to create.</param>
        /// <returns>The delegate for <paramref name="method" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="method"/> is null.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static Delegate CreateDelegate([NotNull] this MethodInfo method, [NotNull] Type delegateType) {
            if (method == null) throw new ArgumentNullException("method");
            Contract.EndContractBlock();

            return Delegate.CreateDelegate(delegateType, method);
        }

        /// <summary>
        /// Creates a delegate of the specified type with the specified target from a specified method.
        /// </summary>
        /// <param name="method">The method to create the delegate for.</param>
        /// <param name="delegateType">The type of the delegate to create.</param>
        /// <param name="target">The object targeted by the delegate.</param>
        /// <returns>The delegate for <paramref name="method" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="method"/> is null.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static Delegate CreateDelegate([NotNull] this MethodInfo method, [NotNull] Type delegateType, object target) {
            if (method == null) throw new ArgumentNullException("method");
            Contract.EndContractBlock();

            return Delegate.CreateDelegate(delegateType, target, method);
        }
        #endif

        /// <summary>
        /// Creates a delegate of the specified type from a specified method.
        /// </summary>
        /// <typeparam name="TDelegate">The type of the delegate to create.</typeparam>
        /// <param name="method">The method to create the delegate for.</param>
        /// <returns>The delegate for <paramref name="method" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="method"/> is null.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static TDelegate CreateDelegate<TDelegate>([NotNull] this MethodInfo method) {
            if (method == null) throw new ArgumentNullException(nameof(method));
            Contract.EndContractBlock();

            return (TDelegate)(object)method.CreateDelegate(typeof(TDelegate));
        }

        /// <summary>
        /// Creates a delegate of the specified type with the specified target from a specified method.
        /// </summary>
        /// <typeparam name="TDelegate">The type of the delegate to create.</typeparam>
        /// <param name="method">The method to create the delegate for.</param>
        /// <param name="target">The object targeted by the delegate.</param>
        /// <returns>The delegate for <paramref name="method" />.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="method"/> is null.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static TDelegate CreateDelegate<TDelegate>([NotNull] this MethodInfo method, object target) {
            if (method == null) throw new ArgumentNullException(nameof(method));
            Contract.EndContractBlock();

            return (TDelegate)(object)method.CreateDelegate(typeof(TDelegate), target);
        }
    }
}
