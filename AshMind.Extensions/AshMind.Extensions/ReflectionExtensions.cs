﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;

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
        [Pure]
        public static TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider member, bool inherit) 
            where TAttribute : Attribute
        {
            if (member == null)
                throw new ArgumentNullException("member");
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
        [Pure]
        public static TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider provider) 
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            Contract.EndContractBlock();

            return (TAttribute[])provider.GetCustomAttributes(typeof(TAttribute), true);
        }
        
        /// <summary>
        /// Gets the custom attributes of the specified type defined on this member.
        /// </summary>
        /// <param name="member">The provider which attributes will be retrieved.</param>
        /// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="NullReferenceException">If <paramref name="attributeType" /> is a null reference (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        [Pure]
        public static object[] GetCustomAttributes(this ICustomAttributeProvider provider, Type attributeType) {
            if (provider == null)
                throw new ArgumentNullException("provider");
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
        [Pure]
        public static object[] GetCustomAttributes(this ICustomAttributeProvider provider) {
            if (provider == null)
                throw new ArgumentNullException("provider");
            Contract.EndContractBlock();

            return provider.GetCustomAttributes(true);
        }

        [Pure]
        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            Contract.EndContractBlock();

            return provider.GetCustomAttributes<TAttribute>(inherit).Single();
        }

        [Pure]
        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider)
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            Contract.EndContractBlock();

            return provider.GetCustomAttributes<TAttribute>(false).Single();
        }

        [Pure]
        public static bool IsDefined<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            if (provider == null)
                throw new ArgumentNullException("provider");
            Contract.EndContractBlock();

            return provider.IsDefined(typeof(TAttribute), inherit);
        }

        [Pure]
        public static bool IsSameAsOrSubclassOf(this Type type, Type otherType)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            if (otherType == null)
                throw new ArgumentNullException("otherType");
            Contract.EndContractBlock();

            return type == otherType || type.IsSubclassOf(otherType);
        }

        [Pure]
        public static bool IsSameAsOrSubclassOf<TClass>(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            Contract.EndContractBlock();

            return type.IsSameAsOrSubclassOf(typeof(TClass));
        }

        [Pure]
        public static bool IsSubclassOf<T>(this Type type) 
            where T : class
        {
            if (type == null)
                throw new ArgumentNullException("type");
            Contract.EndContractBlock();

            return type.IsSubclassOf(typeof(T));
        }

        [Pure]
        public static bool IsGenericTypeDefinedAs(this Type type, Type otherType) {
            if (type == null)
                throw new ArgumentNullException("type");
            Contract.EndContractBlock();

            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == otherType;
        }

        [Pure]
        public static bool HasInterface<T>(this Type type)
            where T : class
        {
            if (type == null)
                throw new ArgumentNullException("type");
            Contract.EndContractBlock();

            return type.GetInterfaces().Contains(typeof(T));
        }

        public static void SetValue(this PropertyInfo property, object obj, object value) {
            if (property == null)
                throw new ArgumentNullException("property");
            Contract.EndContractBlock();

            property.SetValue(obj, value, null);
        }

        [Pure]
        public static object GetValue(this PropertyInfo property, object obj) {
            if (property == null)
                throw new ArgumentNullException("property");
            Contract.EndContractBlock();

            return property.GetValue(obj, null);
        }
    }
}
