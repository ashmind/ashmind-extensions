using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Research
{
    public static class Switch2
    {
        private static bool TryType<TBase, TCase, TResult>(TBase value, Func<TCase, TResult> func, out TResult result)
            where TCase : class, TBase
            where TBase : class
        {
            TCase cast = value as TCase;
            if (cast != null)
            {
                result = func(cast);
                return true;
            }
            else
            {
                result = default(TResult);
                return false;
            }
        }

        public static TResult Type<TBase, TCase1, TResult>(TBase value, Func<TCase1, TResult> func1)
            where TCase1 : class, TBase
            where TBase  : class
        {
            TResult result;
            bool matched = TryType(value, func1, out result);
            return result;
        }

        public static TResult Type<TBase, TCase1, TCase2, TResult>(TBase value, Func<TCase1, TResult> func1, Func<TCase2, TResult> func2)
            where TCase1 : class, TBase
            where TCase2 : class, TBase
            where TBase : class
        {
            TResult result;
            bool matched = TryType(value, func1, out result)
                         || TryType(value, func2, out result);

            return result;
        }

        public static TResult Type<TBase, TCase1, TCase2, TResult>(TBase value, Func<TCase1, TResult> func1, Func<TCase2, TResult> func2, Func<TBase, TResult> otherwise)
            where TCase1 : class, TBase
            where TCase2 : class, TBase
            where TBase : class
        {
            TResult result;
            bool matched = TryType(value, func1, out result)
                         || TryType(value, func2, out result);

            return matched ? result : otherwise(value);
        }
    }
}
