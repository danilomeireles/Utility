using System;
using System.Linq;

namespace Utility.Util
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Checks if a value is present in the provided list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsIn<T>(this T source, params T[] list)
        {
            if (null == source)
                throw new ArgumentNullException("source");

            return list.Contains(source);
        }

        /// <summary>
        /// Checks if a value is between the lower and the upper values. The comparison includes the lower and the upper values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual"></param>
        /// <param name="lower">Lower value</param>
        /// <param name="upper">Upper value</param>
        /// <returns></returns>
        public static bool IsBetween<T>(this T actual, T lower, T upper) where T : IComparable<T>
        {
            return actual.CompareTo(lower) >= 0 && actual.CompareTo(upper) <= 0;
        }
    }
}
