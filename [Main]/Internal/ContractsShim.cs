#if No_Contracts
// ReSharper disable once CheckNamespace
namespace System.Diagnostics.Contracts {
    internal class PureAttribute : Attribute {}
    internal static class Contract {
        [Conditional("_DO_NOT_COMPILE_")]
        public static void EndContractBlock() {}
    }
}
#endif