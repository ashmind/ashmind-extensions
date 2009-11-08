using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on Char.
    /// </summary>
    public static class CharExtensions {
        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a Unicode letter.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a letter; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsLetter(char)" />
        public static bool IsLetter(this char c) {
            return Char.IsLetter(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a decimal digit.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a decimal digit; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsDigit(char)" />
        public static bool IsDigit(this char c) {
            return Char.IsDigit(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a letter or a decimal digit.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a letter or a decimal digit; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsLetterOrDigit(char)" />
        public static bool IsLetterOrDigit(this char c) {
            return Char.IsLetterOrDigit(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a number.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a number; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsNumber(char)" />
        public static bool IsNumber(this char c) {
            return Char.IsNumber(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a symbol character.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a symbol character; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsSymbol(char)" />
        public static bool IsSymbol(this char c) {
            return Char.IsSymbol(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a control character.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a control character; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsControl(char)" />
        public static bool IsControl(this char c) {
            return Char.IsControl(c);
        }
              
        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a punctuation mark.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a punctuation mark; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsPunctuation(char)" />
        public static bool IsPunctuation(this char c) {
            return Char.IsPunctuation(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a separator character.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a separator character; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsSeparator(char)" />
        public static bool IsSeparator(this char c) {
            return Char.IsSeparator(c);
        }

        /// <summary>
        /// Indicates whether the specified character has a surrogate code point.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is a high surrogate or a low surrogate; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsSurrogate(char)" />
        /// <seealso cref="CharExtensions.IsHighSurrogate(char)" />
        /// <seealso cref="CharExtensions.IsLowSurrogate(char)" /> 
        public static bool IsSurrogate(this char c) {
            return Char.IsSurrogate(c);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="Char"/> object is a high surrogate.
        /// </summary>
        /// <param name="c">A character.</param>
        /// <returns>
        /// <c>true</c> if the numeric value of the <paramref name="c" /> parameter ranges from U+D800 through U+DBFF; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsHighSurrogate(char)" />
        public static bool IsHighSurrogate(this char c) {
            return Char.IsHighSurrogate(c);
        }

        /// <summary>
        /// Indicates whether the specified <see cref="Char"/> object is a low surrogate.
        /// </summary>
        /// <param name="c">A character.</param>
        /// <returns>
        /// <c>true</c> if the numeric value of the <paramref name="c" /> parameter ranges from U+DC00 through U+DFFF; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsLowSurrogate(char)" />
        public static bool IsLowSurrogate(this char c) {
            return Char.IsLowSurrogate(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as white space.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is white space; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsWhiteSpace(char)" />
        public static bool IsWhiteSpace(this char c) {
            return Char.IsWhiteSpace(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a lowercase letter.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is lowercase letter; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsLower(char)" />
        public static bool IsLower(this char c) {
            return Char.IsLower(c);
        }

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as a uppercase letter.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        /// <c>true</c> if <paramref name="c" /> is uppercase letter; otherwise, <c>false</c>.
        /// </returns>
        /// <seealso cref="Char.IsUpper(char)" />
        public static bool IsUpper(this char c) {
            return Char.IsUpper(c);
        }

        /// <summary>
        ///   Converts the value of a Unicode character to its lowercase equivalent.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        ///   The lowercase equivalent of <paramref name="c" />, or the unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        /// <seealso cref="Char.ToLower(char)" />
        public static char ToLower(this char c) {
            return Char.ToLower(c);
        }
       
        /// <summary>
        ///   Converts the value of a specified Unicode character to its lowercase equivalent using specified culture-specific formatting information.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <param name="culture">
        ///   A <see cref="CultureInfo" /> object that supplies culture-specific casing rules, or a null reference (<c>Nothing</c> in Visual Basic).
        /// </param>
        /// <returns>
        ///   The lowercase equivalent of <paramref name="c" />, modified according to <paramref name="culture" />, or the unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        /// <seealso cref="Char.ToLower(char, CultureInfo)" />
        public static char ToLower(this char c, CultureInfo culture) {
            return Char.ToLower(c, culture);
        }

        /// <summary>
        ///   Converts the value of a Unicode character to its lowercase equivalent using the casing rules of the invariant culture.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        ///   The lowercase equivalent of <paramref name="c" />, or the unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        /// <seealso cref="Char.ToLowerInvariant(char)" />
        public static char ToLowerInvariant(this char c) {
            return Char.ToLowerInvariant(c);
        }

        /// <summary>
        ///   Converts the value of a Unicode character to its uppercase equivalent.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        ///   The uppercase equivalent of <paramref name="c" />, or the unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        /// <seealso cref="Char.ToUpper(char)" />
        public static char ToUpper(this char c) {
            return Char.ToUpper(c);
        }

        /// <summary>
        ///   Converts the value of a specified Unicode character to its uppercase equivalent using specified culture-specific formatting information.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <param name="culture">
        ///   A <see cref="CultureInfo" /> object that supplies culture-specific casing rules, or a null reference (<c>Nothing</c> in Visual Basic).
        /// </param>
        /// <returns>
        ///   The uppercase equivalent of <paramref name="c" />, modified according to <paramref name="culture" />, or the unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        /// <seealso cref="Char.ToUpper(char, CultureInfo)" />
        public static char ToUpper(this char c, CultureInfo culture) {
            return Char.ToUpper(c, culture);
        }

        /// <summary>
        ///   Converts the value of a Unicode character to its uppercase equivalent using the casing rules of the invariant culture.
        /// </summary>
        /// <param name="c">A Unicode character.</param>
        /// <returns>
        ///   The uppercase equivalent of <paramref name="c" />, or the unchanged value of <paramref name="c" />, if <paramref name="c" /> is already lowercase or not alphabetic.
        /// </returns>
        /// <seealso cref="Char.ToUpperInvariant(char)" />
        public static char ToUpperInvariant(this char c) {
            return Char.ToUpperInvariant(c);
        }
    }
}
