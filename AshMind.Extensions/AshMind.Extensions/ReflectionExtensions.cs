using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AshMind.Extensions
{
    public static class ReflectionExtensions
    {
        public static TAttribute[] GetCustomAttributes<TAttribute>(this MemberInfo member, bool inherit)
            where TAttribute : Attribute
        {
            return (TAttribute[])member.GetCustomAttributes(typeof(TAttribute), true);
        }

        public static TAttribute GetCustomAttribute<TAttribute>(this MemberInfo member, bool inherit)
            where TAttribute : Attribute
        {
            return Attribute.GetCustomAttribute(member, typeof(TAttribute), inherit) as TAttribute;
        }

        public static TAttribute GetCustomAttribute<TAttribute>(this MemberInfo member)
            where TAttribute : Attribute
        {
            return Attribute.GetCustomAttribute(member, typeof(TAttribute)) as TAttribute;
        }
    }
}
