using System;

namespace Utility.Util
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Checks if a DataTime is between two DateTime instances
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public static bool IsBetween(this DateTime dateTime, DateTime startDateTime, DateTime endDateTime)
        {
            return dateTime.Ticks >= startDateTime.Ticks && dateTime.Ticks <= endDateTime.Ticks;
        }

        /// <summary>
        /// Returns the age in years from the specified DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime dateTime)
        {
            var age = DateTime.Now.Year - dateTime.Year;

            if (DateTime.Now < dateTime.AddYears(age))
                age--;

            return age;
        }
    }
}