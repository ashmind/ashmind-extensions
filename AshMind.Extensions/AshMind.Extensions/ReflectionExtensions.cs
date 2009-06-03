using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AshMind.Extensions
{
    public static class ReflectionExtensions {
        public static TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider member, bool inherit) 
            where TAttribute : Attribute
        {
            return (TAttribute[])member.GetCustomAttributes(typeof(TAttribute), inherit);
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

        public static bool IsGenericDefinedBy(this Type type, Type otherType) {
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
