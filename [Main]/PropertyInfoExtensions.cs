#if No_Property_SetValue_NoIndex
using System;
using System.Diagnostics.Contracts;
using System.Reflection;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;
using PureAttribute = JetBrains.Annotations.PureAttribute;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="PropertyInfo" />.
    /// </summary>
    public static class PropertyInfoExtensions {
        public static void SetValue([NotNull] this PropertyInfo property, [CanBeNull] object obj, [CanBeNull] object value) {
            if (property == null) throw new ArgumentNullException("property");
            Contract.EndContractBlock();

            property.SetValue(obj, value, null);
        }

        [Contracts.Pure] [Pure] [CanBeNull]
        public static object GetValue([NotNull] this PropertyInfo property, [CanBeNull] object obj) {
            if (property == null) throw new ArgumentNullException("property");
            Contract.EndContractBlock();

            return property.GetValue(obj, null);
        }
    }
}
#endif
