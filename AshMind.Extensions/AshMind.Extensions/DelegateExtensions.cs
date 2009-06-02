using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of static (Shared in Visual Basic) methods for operations on delegates. 
    /// </summary>
    public static class DelegateExtensions {
        /// <summary>
        /// Converts Func&lt;T, bool&gt; into a Predicate&lt;T&gt;.
        /// </summary>
        /// <param name="function">Function to convert.</param>
        /// <returns>Predicate&lt;T&gt; identical to the original function.</returns>
        public static Predicate<T> AsPredicate<T>(this Func<T, bool> function) {
            return (Predicate<T>)Delegate.CreateDelegate(typeof(Predicate<T>), function.Target, function.Method);
        }
    }
}
