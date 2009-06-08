using System;
using System.Collections.Generic;
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
        public static TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider member, bool inherit) 
            where TAttribute : Attribute
        {
            return (TAttribute[])member.GetCustomAttributes(typeof(TAttribute), inherit);
        }

        /// <summary>
        /// Gets the custom attributes of the specified type defined on this member.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to search for. Only attributes that are assignable to this type are returned.</typeparam>
        /// <param name="member">The member which attributes will be retrieved.</param>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        public static TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider member) 
            where TAttribute : Attribute
        {
            return (TAttribute[])member.GetCustomAttributes(typeof(TAttribute), true);
        }
        
        /// <summary>
        /// Gets the custom attributes of the specified type defined on this member.
        /// </summary>
        /// <param name="member">The member which attributes will be retrieved.</param>
        /// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
        /// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="NullReferenceException">If <paramref name="attributeType" /> is a null reference (Nothing in Visual Basic).</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        public static object[] GetCustomAttributes(this ICustomAttributeProvider member, Type attributeType) {
            return member.GetCustomAttributes(attributeType, true);
        }

        /// <summary>
        /// Returns an array containing all the custom attributes defined on this member.
        /// </summary>
        /// <param name="member">The member which attributes will be retrieved.</param>
        /// <returns>An array that contains all the custom attributes, or an array with zero elements if no attributes are defined.</returns>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded.</exception>
        /// <exception cref="InvalidOperationException">This member belongs to a type that is loaded into the reflection-only context.</exception>
        public static object[] GetCustomAttributes(this ICustomAttributeProvider member) {
            return member.GetCustomAttributes(true);
        }
        
        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider member, bool inherit)
            where TAttribute : Attribute
        {
            return member.GetCustomAttributes<TAttribute>(inherit).Single();
        }

        public static TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider member)
            where TAttribute : Attribute
        {
            return member.GetCustomAttributes<TAttribute>(false).Single();
        }

        public static bool IsDefined<TAttribute>(this ICustomAttributeProvider provider, bool inherit)
            where TAttribute : Attribute
        {
            return provider.IsDefined(typeof(TAttribute), inherit);
        }

        public static bool IsSameAsOrSubclassOf(this Type type, Type otherType)
        {
            return type == otherType || type.IsSubclassOf(otherType);
        }

        public static bool IsSameAsOrSubclassOf<TClass>(this Type type)
        {
            return type.IsSameAsOrSubclassOf(typeof(TClass));
        }

        public static bool IsSubclassOf<T>(this Type type) 
            where T : class
        {
            return type.IsSubclassOf(typeof(T));
        }

        public static bool IsGenericDefinedAs(this Type type, Type otherType) {
            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == otherType;
        }

        public static bool HasInterface<T>(this Type type)
            where T : class
        {
            return type.GetInterfaces().Contains(typeof(T));
        }

        public static void SetValue(this PropertyInfo property, object obj, object value) {
            property.SetValue(obj, value, null);
        }

        public static object GetValue(this PropertyInfo property, object obj) {
            return property.GetValue(obj, null);
        }
    }
}
