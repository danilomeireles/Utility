using System;

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
    }
}
