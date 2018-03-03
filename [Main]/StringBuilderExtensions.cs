using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;
using JetBrains.Annotations;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on StringBuilder.
    /// </summary>
    public static class StringBuilderExtensions {
        /// <summary>
        /// Appends all the elements of a string array, using the specified separator between each member.
        /// </summary>
        /// <param name="builder">The <see cref="StringBuilder"/> to append to.</param>
        /// <param name="separator">
        ///   The string to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.
        /// </param>
        /// <param name="values">A array that contains the elements to concatenate.</param>
        /// <returns>A reference to <paramref name="builder"/> after the append operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="builder"/> is <c>null</c>; or, <paramref name="values"/> is <c>null</c>
        /// </exception>
        /// <remarks>
        ///   If <paramref name="separator"/> is <c>null</c>, an empty string (<see cref="String.Empty"/>) is used instead.
        ///   If any member of <paramref name="values"/> is <c>null</c>, an empty string is used instead.
        /// </remarks>
        public static StringBuilder AppendJoin([NotNull] this StringBuilder builder, [CanBeNull] string separator, [NotNull, ItemCanBeNull] params string[] values) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (values == null) throw new ArgumentNullException(nameof(values));
            Contract.EndContractBlock();

            var length = values.Length;
            if (length == 0)
                return builder;

            builder.Append(values[0]);
            for (var i = 1; i < length; i++) {
                builder.Append(separator).Append(values[i]);
            }
            return builder;
        }

        #if No_StringBuilder_AppendJoin
        /// <summary>
        /// Appends the members of a collection, using the specified separator between each member.
        /// </summary>
        /// <typeparam name="T">The type of the members of <paramref name="values"/>.</typeparam>
        /// <param name="builder">The <see cref="StringBuilder"/> to append to.</param>
        /// <param name="separator">
        ///   The string to use as a separator. <paramref name="separator"/> is included in the returned string only if <paramref name="values"/> has more than one element.
        /// </param>
        /// <param name="values">A collection that contains the objects to concatenate.</param>
        /// <returns>A reference to <paramref name="builder"/> after the append operation has completed.</returns>
        /// <exception cref="ArgumentNullException">
        ///   <paramref name="builder"/> is <c>null</c>; or, <paramref name="values"/> is <c>null</c>
        /// </exception>
        /// <remarks>
        ///   If <paramref name="separator"/> is <c>null</c>, an empty string (<see cref="String.Empty"/>) is used instead.
        ///   If any member of <paramref name="values"/> is <c>null</c>, an empty string is used instead.
        /// </remarks>
        public static StringBuilder AppendJoin<T>([NotNull] this StringBuilder builder, [CanBeNull] string separator, [NotNull, ItemCanBeNull] IEnumerable<T> values) {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (values == null) throw new ArgumentNullException(nameof(values));
            Contract.EndContractBlock();

            var array = values as T[];
            if (array != null) {
                var length = array.Length;
                if (length == 0)
                    return builder;

                var item = array[0];
                if (item != null) {
                    // ReSharper disable once RedundantToStringCallForValueType (avoiding boxing)
                    builder.Append(item.ToString());
                }
                for (var i = 1; i < length; i++) {
                    item = array[i];
                    builder.Append(separator);
                    if (item != null) {
                        // ReSharper disable once RedundantToStringCallForValueType (avoiding boxing)
                        builder.Append(item.ToString());
                    }
                }
                return builder;
            }

            using (var enumerator = values.GetEnumerator()) {
                if (!enumerator.MoveNext())
                    return builder;

                var current = enumerator.Current;
                if (current != null) {
                    // ReSharper disable once RedundantToStringCallForValueType (avoiding boxing)
                    builder.Append(current.ToString());
                }

                while (enumerator.MoveNext()) {
                    builder.Append(separator);
                    current = enumerator.Current;
                    if (current != null) {
                        // ReSharper disable once RedundantToStringCallForValueType (avoiding boxing)
                        builder.Append(current.ToString());
                    }
                }
            }
            return builder;
        }
        #endif
    }
}
