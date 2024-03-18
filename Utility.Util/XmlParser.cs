using System;
using System.IO;
using System.Xml.Serialization;

namespace Utility.Util;

public static class XmlParser
{
    public static string Serialize<T>(T obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj));
        }

        var serializer = new XmlSerializer(typeof(T));

        using var writer = new StringWriter();
        serializer.Serialize(writer, obj);
        return writer.ToString();
    }
   
    public static T Deserialize<T>(string xmlText)
    {
        if (string.IsNullOrWhiteSpace(xmlText))
        {
            return default;
        }

        var serializer = new XmlSerializer(typeof(T));
        using TextReader reader = new StringReader(xmlText);
        return (T)serializer.Deserialize(reader);
    }
}