using System;
using System.Collections.Generic;
using System.Linq;

#if !Contracts
// ReSharper disable once CheckNamespace
namespace System.Diagnostics.Contracts {
    [Conditional("JUST_A_SHIM")]
    internal class PureAttribute : Attribute {}

    public static class Contract {
        [Conditional("JUST_A_SHIM")]
        public static void EndContractBlock() {
        }
    }
}
#endif