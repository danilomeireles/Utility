using Newtonsoft.Json;
using System;

namespace Utility.Util
{
    public static class MiscExtensions
    {
        /// <summary>
        /// Convert the size into a formatted number with the correct size metric.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string ToFileSize(this long size)
        {
            if (size < 1024)            
                return size.ToString("F0") + " bytes";             
            
            if (size < Math.Pow(1024, 2)) 
                return (size / 1024).ToString("F0") + "KB";
            
            if (size < Math.Pow(1024, 3)) 
                return (size / Math.Pow(1024, 2)).ToString("F0") + "MB";
            
            if (size < Math.Pow(1024, 4)) 
                return (size / Math.Pow(1024, 3)).ToString("F0") + "GB";
            
            if (size < Math.Pow(1024, 5)) 
                return (size / Math.Pow(1024, 4)).ToString("F0") + "TB";
            
            if (size < Math.Pow(1024, 6)) 
                return (size / Math.Pow(1024, 5)).ToString("F0") + "PB";
            
            return (size / Math.Pow(1024, 6)).ToString("F0") + "EB";
        }

        /// <summary>
        /// Serializes an object to JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T instance)
        {
            return JsonConvert.SerializeObject(instance, Formatting.Indented);
        }

        /// <summary>
        /// Deserializes a JSON string to the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T To<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
