#if !TypeInfo
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;
using PureAttribute = JetBrains.Annotations.PureAttribute;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="Type" />.
    /// </summary>
    public static class TypeExtensions {
        /// <summary>
        /// Determines whether an instance of the current type can be assigned from an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to compare with the current type.</typeparam>
        /// <param name="type">The current type.</param>
        /// <returns>
        /// <c>true</c> if <typeparamref name="T" /> and the <paramref name="type"/> represent the same type, or if
        /// <paramref name="type" /> is in the inheritance hierarchy of <typeparamref name="T" />, or if the
        /// <paramref name="type" /> is an interface that <typeparamref name="T" /> implements, or if
        /// <typeparamref name="T" /> is a generic type parameter and <paramref name="type"/> represents one of the
        /// constraints of <typeparamref name="T" />, or if <typeparamref name="T" /> represents a value type and
        /// <paramref name="type"/> represents <c>Nullable&lt;T&gt;</c>. <c>false</c> if none of these conditions are true.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsAssignableFrom<T>([NotNull] this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.EndContractBlock();

            return type.IsAssignableFrom(typeof(T));
        }

        /// <summary>
        /// Determines whether an instance of the current type can be assigned to an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to compare with the current type.</typeparam>
        /// <param name="type">The current type.</param>
        /// <returns>
        /// <c>true</c> if <typeparamref name="T" /> and the <paramref name="type"/> represent the same type, or if
        /// <typeparamref name="T" /> is in the inheritance hierarchy of <paramref name="type"/>, or if the <typeparamref name="T" />
        /// is an interface that <paramref name="type" /> implements, or if <paramref name="type" /> is a generic type
        /// parameter and <typeparamref name="T" /> represents one of the constraints of <paramref name="type"/>, or
        /// if <paramref name="type"/> represents a value type and <typeparamref name="T" /> represents
        /// <c>Nullable&lt;type&gt;</c>. <c>false</c> if none of these conditions are true.
        /// </returns>
        [Contracts.Pure] [Pure]
        public static bool IsAssignableTo<T>([NotNull] this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.EndContractBlock();

            return type.IsAssignableTo(typeof(T));
        }

        /// <summary>
        /// Determines whether an instance of the current type can be assigned to an instance of the specified type.
        /// </summary>
        /// <param name="type">The current type.</param>
        /// <param name="other">The type to compare with the current type.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="other" /> and the <paramref name="type"/> represent the same type, or if
        /// <paramref name="other" /> is in the inheritance hierarchy of <paramref name="type"/>, or if the
        /// <paramref name="other" /> is an interface that <paramref name="type"/> implements, or if
        /// <paramref name="type"/> is a generic type parameter and <paramref name="other" /> represents one of
        /// the constraints of <paramref name="type"/>, or if <paramref name="type"/> represents a value type and
        /// <paramref name="other" /> represents <c>Nullable&lt;type&gt;</c>. <c>false</c> if none of these conditions
        /// are true, or if <paramref name="other" /> is <c>null</c>.
        /// </returns>
        [ContractAnnotation("other:null=>false")]
        [Contracts.Pure] [Pure]
        public static bool IsAssignableTo([NotNull] this Type type, [CanBeNull] Type other)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.EndContractBlock();

            if (other == null)
                return false;

            return other.IsAssignableFrom(type);
        }

        [Contracts.Pure] [Pure]
        public static bool IsSameAsOrSubclassOf([NotNull] this Type type, [NotNull] Type otherType)
        {
            if (type == null)      throw new ArgumentNullException(nameof(type));
            if (otherType == null) throw new ArgumentNullException(nameof(otherType));
            Contract.EndContractBlock();

            return type == otherType || type.IsSubclassOf(otherType);
        }

        [Contracts.Pure] [Pure]
        public static bool IsSameAsOrSubclassOf<TClass>([NotNull] this Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.EndContractBlock();

            return type.IsSameAsOrSubclassOf(typeof(TClass));
        }

        [Contracts.Pure] [Pure]
        public static bool IsGenericTypeDefinedAs([NotNull] this Type type, [NotNull] Type otherType) {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.EndContractBlock();

            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == otherType;
        }

        /// <summary>
        /// Determines whether the specified interface is implemented by the specified type.
        /// </summary>
        /// <typeparam name="TInterface">The interface that might be implemented by the <paramref name="type"/>.</typeparam>
        /// <param name="type">The type for which the fact of implementation will be dermined.</param>
        /// <returns><c>true</c> if <paramref name="type"/> implements <typeparamref name="TInterface"/>; otherwise, <c>false</c>.</returns>
        [Contracts.Pure] [Pure]
        public static bool HasInterface<TInterface>([NotNull] this Type type)
            where TInterface : class
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            Contract.EndContractBlock();

            return type.HasInterface(typeof(TInterface));
        }

        /// <summary>
        /// Determines whether a given interface is implemented by a specified type.
        /// </summary>
        /// <param name="type">The type for which the fact of implementation will be dermined.</param>
        /// <param name="interfaceType">The interface that might be implemented by the <paramref name="type"/>.</param>
        /// <returns><c>true</c> if <paramref name="type"/> implements <paramref name="interfaceType"/>; otherwise, <c>false</c>.</returns>
        [Contracts.Pure] [Pure]
        public static bool HasInterface([NotNull] this Type type, [NotNull] Type interfaceType) {
            if (type == null)          throw new ArgumentNullException(nameof(type));
            if (interfaceType == null) throw new ArgumentNullException(nameof(interfaceType));
            Contract.EndContractBlock();

            return type.GetInterfaces().Contains(interfaceType);
        }
    }
}
#endif