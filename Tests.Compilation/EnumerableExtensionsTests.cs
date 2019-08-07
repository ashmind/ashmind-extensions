using AshMind.Extensions;
using System.Collections.Generic;

namespace AshMind.Extensions.Tests.Compilation
{
    public static class EnumerableExtensionsTests
    {
        public static void EmptyIfNull_AllowsNull()
        {
            var enumerable = (IEnumerable<string>?)null;
            enumerable.EmptyIfNull();
        }

        public static void EmptyIfNull_ReturnsNotNullable()
        {
            CompilerAssert.NotNullable(new string[0].EmptyIfNull());
        }

        public static void Except_AllowsNullItem()
        {
            CompilerAssert.NotNullable(new string?[0].Except(null));
        }
    }
}
