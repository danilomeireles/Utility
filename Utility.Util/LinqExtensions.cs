using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility.Util;

public static class LinqExtensions
{       
    public static bool IsIn<T>(this T source, params T[] list)
    {
        if (null == source)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return list.Contains(source);
    }
   
    public static bool IsBetween<T>(this T actual, T lower, T upper) where T : IComparable<T>
    {
        return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) <= 0;
    }
   
    public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> actual)
    {
        return actual ?? [];
    }
}
