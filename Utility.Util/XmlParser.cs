using System;
using System.IO;
using System.Xml.Serialization;

namespace Utility.Util
{
    /// <summary>
    /// Utility class for XML Deserialization
    /// </summary>
    public static class XmlParser
    {
        /// <summary>
        /// Serializes an object into an XML string
        /// </summary>
        /// <typeparam name="T">The object type</typeparam>
        /// <param name="obj">The object to serialize</param>
        /// <returns>An XML string of the provided object</returns>
        public static string Serialize<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            var serializer = new XmlSerializer(typeof(T));

            using var writer = new StringWriter();
            serializer.Serialize(writer, obj);
            return writer.ToString();
        }

        /// <summary>
        /// Deserializes an XML string into an object of the specified type
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="xmlText">the xml text to deserialize</param>
        /// <returns>An instance of the specified type</returns>
        public static T Deserialize<T>(string xmlText)
        {
            if (string.IsNullOrWhiteSpace(xmlText))
                return default;

            var serializer = new XmlSerializer(typeof(T));
            using TextReader reader = new StringReader(xmlText);
            return (T)serializer.Deserialize(reader);
        }
    }
}