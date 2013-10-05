using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

#if Contracts
using System.Diagnostics.Contracts;
using PureAttribute = System.Diagnostics.Contracts.PureAttribute;
#endif

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on reflection classes.
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
        [Pure] [NotNull]
        public static TAttribute[] GetCustomAttributes<TAttribute>([NotNull] this ICustomAttributeProvider member, bool inherit) 
            where TAttribute : Attribute
        {
            if (member == null)
                throw new ArgumentNullException("member");
            #if Contracts
            Contract.EndContractBlock();
            #endif

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
        [Pure] [NotNull]
        public static TAttribute[] GetCustomAttributes<TAttribute>([NotNull] this ICustomAttributeProvider provider) 
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            #if Contracts
            Contract.EndContractBlock();
            #endif

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
        [Pure] [NotNull]
        public static object[] GetCustomAttributes([NotNull] this ICustomAttributeProvider provider, [NotNull] Type attributeType) {
            if (provider == null)
                throw new ArgumentNullException("provider");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return provider.GetCustomAttributes(attributeType, true);
        }

        /// <summary>
        /// Returns an array containing all the custom attributes defined on this member.
        /// </summary>
        /// <param name="provider">The member which attributes will be retrieved.</param>
        /// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        [Pure] [NotNull]
        public static object[] GetCustomAttributes([NotNull] this ICustomAttributeProvider provider) {
            if (provider == null)
                throw new ArgumentNullException("provider");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return provider.GetCustomAttributes(true);
        }

        [Pure] [NotNull]
        public static TAttribute GetCustomAttribute<TAttribute>([NotNull] this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return provider.GetCustomAttributes<TAttribute>(inherit).Single();
        }

        [Pure] [NotNull]
        public static TAttribute GetCustomAttribute<TAttribute>([NotNull] this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return provider.GetCustomAttributes<TAttribute>(false).Single();
        }

        [Pure]
        public static bool IsDefined<TAttribute>([NotNull] this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return provider.IsDefined(typeof(TAttribute), inherit);
        }

        [Pure]
        public static bool IsSameAsOrSubclassOf([NotNull] this Type type, [NotNull] Type otherType)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (otherType == null)
                throw new ArgumentNullException("otherType");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return type == otherType || type.IsSubclassOf(otherType);
        }

        [Pure]
        public static bool IsSameAsOrSubclassOf<TClass>([NotNull] this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return type.IsSameAsOrSubclassOf(typeof(TClass));
        }

        [Pure]
        public static bool IsSubclassOf<T>([NotNull] this Type type) 
            where T : class
        {
            if (type == null)
                throw new ArgumentNullException("type");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return type.IsSubclassOf(typeof(T));
        }

        [Pure]
        public static bool IsGenericTypeDefinedAs([NotNull] this Type type, [NotNull] Type otherType) {
            if (type == null)
                throw new ArgumentNullException("type");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == otherType;
        }

        [Pure]
        public static bool HasInterface<T>([NotNull] this Type type)
            where T : class
        {
            if (type == null)
                throw new ArgumentNullException("type");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return type.GetInterfaces().Contains(typeof(T));
        }

        public static void SetValue([NotNull] this PropertyInfo property, [CanBeNull] object obj, [CanBeNull] object value) {
            if (property == null)
                throw new ArgumentNullException("property");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            property.SetValue(obj, value, null);
        }

        [Pure] [CanBeNull]
        public static object GetValue([NotNull] this PropertyInfo property, [CanBeNull] object obj) {
            if (property == null)
                throw new ArgumentNullException("property");
            #if Contracts
            Contract.EndContractBlock();
            #endif

            return property.GetValue(obj, null);
        }
    }
}
