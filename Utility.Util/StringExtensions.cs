using System;
using System.Collections.Generic;
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
                throw new ArgumentException("Must specify valid information for parsing in the string.", nameof(value));            

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
    }
}
