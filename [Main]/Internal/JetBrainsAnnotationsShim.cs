using System;
using System.Diagnostics;
// ReSharper disable UnusedParameter.Local

#if !JETBRAINS_ANNOTATIONS
// ReSharper disable once CheckNamespace
namespace JetBrains.Annotations {
    internal class CanBeNullAttribute : Attribute {}
    internal class NotNullAttribute : Attribute {}
    internal class ItemCanBeNullAttribute : Attribute {}
    internal class InstantHandleAttribute : Attribute {}
    internal class ContractAnnotationAttribute : Attribute {
        public ContractAnnotationAttribute([NotNull] string fdt) {}
    }
    internal class PureAttribute : Attribute {}
}
#endif