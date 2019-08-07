using System;

namespace AshMind.Extensions.Tests.Compilation
{
    public static class StringExtensionsTests
    {
        [Obsolete("To be removed in v4.")]
        public static void IsNullOrEmpty_AllowsNull()
        {
            ((string?)null).IsNullOrEmpty();
        }

        [Obsolete("To be removed in v4.")]
        public static void IsNullOrWhiteSpace_AllowsNull()
        {
            ((string?)null).IsNullOrWhiteSpace();
        }

        public static void NullIfEmpty_AllowsNull()
        {
            ((string?)null).NullIfEmpty();
        }

        public static void NullIfEmpty_ReturnsNullable()
        {
            var value = "".NullIfEmpty();
            CompilerAssert.Nullable(ref value);
        }
    }
}
