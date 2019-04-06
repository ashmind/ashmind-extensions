#if !No_ICustomAttributeProvider
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;
using PureAttribute = JetBrains.Annotations.PureAttribute;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="ICustomAttributeProvider" />.
    /// </summary>
    public static class ReflectionExtensions {
        /// <summary>
        /// Gets the custom attributes of the specified type defined on this member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to search for. Only attributes that are assignable to this type are returned.</typeparam>
        /// <param name="member">The member which attributes will be retrieved.</param>
        /// <param name="inherit">Specifies whether to search this member's inheritance chain to find the attributes.</param>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static TAttribute[] GetCustomAttributes<TAttribute>([NotNull] this ICustomAttributeProvider member, bool inherit)
            where TAttribute : Attribute
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
            Contract.EndContractBlock();

            return (TAttribute[])member.GetCustomAttributes(typeof(TAttribute), inherit);
        }

        /// <summary>
        /// Gets the custom attributes of the specified type defined on this member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to search for. Only attributes that are assignable to this type are returned.</typeparam>
        /// <param name="provider">The member which attributes will be retrieved.</param>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static TAttribute[] GetCustomAttributes<TAttribute>([NotNull] this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return (TAttribute[])provider.GetCustomAttributes(typeof(TAttribute), true);
        }

        /// <summary>
        /// Gets the custom attributes of the specified type defined on this member.
        /// </summary>
        /// <param name="provider">The provider which attributes will be retrieved.</param>
        /// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="NullReferenceException">If <paramref name="attributeType" /> is a null reference (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">This provider is a type loaded into the reflection-only context or a member of such type.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static object[] GetCustomAttributes([NotNull] this ICustomAttributeProvider provider, [NotNull] Type attributeType) {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return provider.GetCustomAttributes(attributeType, true);
        }

        /// <summary>
        /// Returns an array containing all the custom attributes defined on this member.
        /// </summary>
        /// <param name="provider">The member which attributes will be retrieved.</param>
        /// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static object[] GetCustomAttributes([NotNull] this ICustomAttributeProvider provider) {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return provider.GetCustomAttributes(true);
        }

        [Contracts.Pure] [Pure] [NotNull]
        public static TAttribute GetCustomAttribute<TAttribute>([NotNull] this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return provider.GetCustomAttributes<TAttribute>(inherit).Single();
        }

        [Contracts.Pure] [Pure] [NotNull]
        public static TAttribute GetCustomAttribute<TAttribute>([NotNull] this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return provider.GetCustomAttributes<TAttribute>(false).Single();
        }

        /// <summary>
        /// Indicates whether one or more instance of <paramref name="attributeType"/> is defined on the specified member.
        /// </summary>
        /// <param name="provider">The member to look up the attribute on.</param>
        /// <param name="attributeType">The type of the custom attributes.</param>
        /// <returns>
        /// <c>true</c> if the <paramref name="attributeType"/> is defined on this member; <c>false</c> otherwise.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsDefined([NotNull] this ICustomAttributeProvider provider, [NotNull] Type attributeType) {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (attributeType == null) throw new ArgumentNullException(nameof(attributeType));
            Contract.EndContractBlock();

            return provider.IsDefined(attributeType, false);
        }

        /// <summary>
        /// Indicates whether one or more instance of <typeparamref name="TAttribute"/> is defined on the specified member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the custom attributes.</typeparam>
        /// <param name="provider">The member to look up the attribute on.</param>
        /// <returns>
        /// <c>true</c> if the <typeparamref name="TAttribute"/> is defined on this member; <c>false</c> otherwise.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsDefined<TAttribute>([NotNull] this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return provider.IsDefined(typeof(TAttribute));
        }

        /// <summary>
        /// Indicates whether one or more instance of <typeparamref name="TAttribute"/> is defined on the specified member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the custom attributes.</typeparam>
        /// <param name="provider">The member to look up the attribute on.</param>
        /// <param name="inherit">When true, look up the hierarchy chain for the inherited custom attribute.</param>
        /// <returns>
        /// <c>true</c> if the <typeparamref name="TAttribute"/> is defined on this member; <c>false</c> otherwise.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsDefined<TAttribute>([NotNull] this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            Contract.EndContractBlock();

            return provider.IsDefined(typeof(TAttribute), inherit);
        }
    }
}
#endif