using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utility.Util
{
    /// <summary>
    /// String extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string into an enum
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="value">String value to convert</param>
        /// <param name="ignoreCase">Ignore case</param>
        /// <returns>The the corresponding enum</returns>
        public static T EnumParse<T>(this string value, bool ignoreCase = false)
        {
            if (value == null)            
                throw new ArgumentNullException(nameof(value));            

            value = value.Trim();

            if (value.Length == 0)            
                throw new ArgumentException("Empty string.", nameof(value));            

            var type = typeof(T);

            if (!type.IsEnum)            
                throw new ArgumentException("Type provided must be an Enum.", nameof(T));            

            return (T)Enum.Parse(type, value, ignoreCase);
        }

        /// <summary>
        /// Reverses a string
        /// </summary>
        /// <param name="input">The string to reverse</param>
        /// <returns>The reversed String</returns>
        public static string Reverse(this string input)
        {
            if (input == null)
                return null;

            var array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        /// <summary>
        /// Split any string using camel case pattern
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitCamelCase(this string source)
        {
            const string pattern = @"[A-Z][a-z]*|[a-z]+|\d+";
            
            var matches = Regex.Matches(source, pattern);
            
            foreach (Match match in matches)            
                yield return match.Value;            
        }

        /// <summary>
        /// Removes the last character from the string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveLastCharacter(this string source)
        {
            return source[0..^1];
        }

        /// <summary>
        /// Removes the last N characters from the string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string RemoveLast(this string source, int number)
        {
            return source.Substring(0, source.Length - number);
        }

        /// <summary>
        /// Removes the first character from the string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveFirstCharacter(this string source)
        {
            return source.Substring(1);
        }

        /// <summary>
        /// Removes the first N characters from the string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string RemoveFirst(this string source, int number)
        {
            return source.Substring(number);
        }

        /// <summary>
        /// Checks if the string contains a decimal digit
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool ContainsDigit(this string source)
        {
            return source.Any(char.IsDigit);
        }

        /// <summary>
        /// Checks if all the characters in the string are decimal digits
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool AreAllDigits(this string source)
        {
            return source.All(char.IsDigit);
        }

        /// <summary>
        /// Check if the string can be converted to int
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsInt(this string source)
        {
            return int.TryParse(source, out _);
        }

        /// <summary>
        /// Check if the string can be converted to long
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsLong(this string source)
        {
            return long.TryParse(source, out _);
        }
    }
}
