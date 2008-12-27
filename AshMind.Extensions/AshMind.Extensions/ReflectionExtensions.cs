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

        public static bool IsSubclassOf<T>(this Type type) {
            return type.IsSubclassOf(typeof(T));
        }
    }
}
