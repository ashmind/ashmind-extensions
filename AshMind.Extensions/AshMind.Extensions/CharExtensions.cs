using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AshMind.Extensions
{
    public static class CharExtensions
    {
        public static char ToLower(this char c, CultureInfo culture)
        {
            return Char.ToLower(c, culture);
        }

        public static char ToLowerInvariant(this char c)
        {
            return Char.ToLowerInvariant(c);
        }

        public static char ToUpper(this char c, CultureInfo culture)
        {
            return Char.ToUpper(c, culture);
        }

        public static char ToUpperInvariant(this char c)
        {
            return Char.ToUpperInvariant(c);
        }
    }
}
