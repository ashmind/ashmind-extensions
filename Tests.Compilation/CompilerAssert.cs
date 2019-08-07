using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Extensions.Tests.Compilation
{
    // The purpose of these is to see there are no unexpected compiler warnings/errors.
    // Note: project must be set to WarningAsError.

    public static class CompilerAssert
    {
        public static void Nullable(ref string? value)
        {
        }

        public static void NotNullable(object value)
        {
        }
    }
}
