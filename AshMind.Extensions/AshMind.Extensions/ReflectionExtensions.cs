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

        public static bool IsSubclassOf<T>(this Type type) 
            where T : class
        {
            return type.IsSubclassOf(typeof(T));
        }

        public static bool HasInterface<T>(this Type type)
            where T : class
        {
            return type.GetInterfaces().Contains(typeof(T));
        }
    }
}
