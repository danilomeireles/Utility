﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Utility.Util
{   
    public static class StringExtensions
    {        
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
       
        public static string Reverse(this string input)
        {
            if (input == null)
                return null;

            var array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }
        
        public static IEnumerable<string> SplitCamelCase(this string source)
        {
            const string pattern = @"[A-Z][a-z]*|[a-z]+|\d+";

            var matches = Regex.Matches(source, pattern);

            foreach (Match match in matches)
                yield return match.Value;
        }
        
        public static string RemoveLastCharacter(this string source)
        {
            return source[0..^1];
        }
       
        public static string RemoveLast(this string source, int number)
        {
            return source.Substring(0, source.Length - number);
        }
        
        public static string RemoveFirstCharacter(this string source)
        {
            return source.Substring(1);
        }
       
        public static string RemoveFirst(this string source, int number)
        {
            return source[number..];
        }
        
        public static bool ContainsDigit(this string source)
        {
            return source.Any(char.IsDigit);
        }
       
        public static bool AreAllDigits(this string source)
        {
            return source.All(char.IsDigit);
        }
       
        public static bool IsInt(this string source)
        {
            return int.TryParse(source, out _);
        }
        
        public static bool IsLong(this string source)
        {
            return long.TryParse(source, out _);
        }
       
        public static bool ContainsOnlyLettersOrNumbers(this string source)
        {
            return source.All(char.IsLetterOrDigit);
        }
       
        public static string Concat(this IEnumerable<string> strings, string separator)
        {
            return string.Join(separator, strings);
        }
       
        public static string ToSnakeCase(this string text)
        {
            var result = Regex.Replace(text, "[A-Z]", "_$0")
                .ToLower()
                .TrimStart('_')
                .Replace(" ", "_");

            while (result.Contains("__"))
            {
                result = result.Replace("__", "_");
            }

            return result;
        }
        
        public static bool IsBase64String(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            var bytes = new Span<byte>(new byte[text.Length]);
            return Convert.TryFromBase64String(text, bytes , out _);
        }
    }
}