using System;

namespace Utility.Util
{
    public static class DateTimeExtensions
    {        
        public static bool IsBetween(this DateTime dateTime, DateTime startDateTime, DateTime endDateTime)
        {
            return dateTime.Ticks >= startDateTime.Ticks && dateTime.Ticks <= endDateTime.Ticks;
        }
       
        public static int CalculateAge(this DateTime dateTime)
        {
            var age = DateTime.Now.Year - dateTime.Year;

            if (DateTime.Now < dateTime.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}