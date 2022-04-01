using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Xml.Serialization;
using ACR.Foundation.Personify.PersonifyService;
using Newtonsoft.Json;

namespace ACR.Foundation.Personify.Extensions
{
  public static class ObjectExtensions
  {
    /// <summary>
    /// To the serialized byte array ut f8.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <returns></returns>
    public static byte[] ToSerializedByteArrayUTF8(this object obj, SourceFormatEnum format)
    {
      if (obj == null)
        return null;

      using (MemoryStream ms = new MemoryStream())
      {
        if (format == SourceFormatEnum.XML)
        {
          XmlSerializer serializer = new XmlSerializer(obj.GetType());
          serializer.Serialize(ms, obj);
        }

        if (format == SourceFormatEnum.JSON)
        {
          DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
          serializer.WriteObject(ms, obj);
        }

        return ms.ToArray();
      }
    }

    public static T ToBusinessEntity<T>(this string text, SourceFormatEnum format)
    {
      if (string.IsNullOrEmpty(text))
      {
        return default(T);
      }
      object obj = null;
      //FYI: Changed this to UTF-16 for membership directory search, not sure if other calls will need UTF-8

      if (format == SourceFormatEnum.XML)
      {
        using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(text)))
        {
          XmlSerializer serializer = new XmlSerializer(typeof(T));
          obj = serializer.Deserialize(ms);
        }
      }

      if (format == SourceFormatEnum.JSON)
      {
        obj = JsonConvert.DeserializeObject<T>(text);
        //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        //obj = serializer.ReadObject(ms);
      }

      return (T)obj;
    }


  }
}