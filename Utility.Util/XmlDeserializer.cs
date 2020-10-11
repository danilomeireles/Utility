using System.IO;
using System.Xml.Serialization;

namespace Utility.Util
{
    /// <summary>
    /// Utility class for XML Deserialization
    /// </summary>
    public static class XmlDeserializer
    {
        /// <summary>
        /// Deserializes a XML string
        /// </summary>
        /// <typeparam name="T">The destination type</typeparam>
        /// <param name="xmlText">the xml text to deserialize</param>
        /// <returns>An instance of the destination type</returns>
        public static T Deserialize<T>(string xmlText)
        {
            if (string.IsNullOrWhiteSpace(xmlText))            
                return default;           

            var serializer = new XmlSerializer(typeof(T));
            T result;

            using (TextReader reader = new StringReader(xmlText))
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}
