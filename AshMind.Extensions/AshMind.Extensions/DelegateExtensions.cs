using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for operations on delegates. 
    /// </summary>
    public static class DelegateExtensions {
        /// <summary>
        /// Converts Func&lt;T, bool&gt; into a <see cref="Predicate&lt;T&gt;" />.
        /// </summary>
        /// <param name="function">A function to convert.</param>
        /// <returns>Predicate&lt;T&gt; identical to the original function.</returns>
        public static Predicate<T> AsPredicate<T>(this Func<T, bool> function) {
            return (Predicate<T>)Delegate.CreateDelegate(typeof(Predicate<T>), function.Target, function.Method);
        }

        /// <summary>
        /// Converts <see cref="Predicate&lt;T&gt;" /> into a Func&lt;T, bool&gt;.
        /// </summary>
        /// <param name="predicate">A predicate to convert.</param>
        /// <returns>Func&lt;T&gt; identical to the original predicate.</returns>
        public static Func<T, bool> AsFunc<T>(this Predicate<T> predicate) {
            return (Func<T, bool>)Delegate.CreateDelegate(typeof(Func<T, bool>), predicate.Target, predicate.Method);
        }
    }
}
