using System;
using System.ComponentModel;
using System.Linq;

namespace Utility.Util
{    
    public static class EnumExtensions
    {       
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