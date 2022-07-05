using System;
using System.ComponentModel;
using System.Linq;

namespace Utility.Util
{
    /// <summary>
    /// Enum extension methods
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the enum item description from the Description attribute
        /// </summary>
        /// <param name="enumItem"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetEnumDescription<TEnum>(this TEnum enumItem)
        {
            if (enumItem == null)
                throw new ArgumentNullException(nameof(enumItem));

            return enumItem.GetType()
                .GetField(enumItem.ToString()!)
                ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()?.Description ?? string.Empty;
        }
    }
}