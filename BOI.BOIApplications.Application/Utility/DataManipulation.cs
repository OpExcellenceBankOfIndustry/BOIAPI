using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoMapper.Internal.ExpressionFactory;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using System.Data.SqlTypes;
using System.Text.Json;
using BOI.BOIApplications.Domain.Entities.RubikonBonitaIntegration;

namespace BOI.BOIApplications.Application.Utility
{
    public class DataManipulation
    {
        public static string SerializeXmlStringToJson<T>(string xmlString, string stringToIdentify)
        {
            try
            {
                var doc = XDocument.Parse(xmlString);

                doc.Declaration = null;

                var xmlResponseValue = doc.Descendants(stringToIdentify).First();

                string json = JsonConvert.SerializeXNode(xmlResponseValue);

                return SerializeJsonStringToObject<T>(json);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string SerializeJsonStringToObject<T>(string jsonString)
        {
            try
            {
                var fromJson = JsonConvert.DeserializeObject<T>(jsonString);

                string jsonObject = JsonConvert.SerializeObject(fromJson, Newtonsoft.Json.Formatting.Indented);

                return jsonObject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static string SerializeObjectToXml<T>(T obj)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (XmlTextWriter writer = new XmlTextWriter(sww) { Formatting = System.Xml.Formatting.Indented })
                {
                    xsSubmit.Serialize(writer, obj);

                    var doc = XDocument.Parse(sww.ToString());

                    doc.Descendants()
                            .Attributes()
                            .Where(x => x.IsNamespaceDeclaration)
                            .Remove();

                    doc.Root.Name = doc.Root.Name.LocalName.ToLower();

                    return doc.ToString();
                }
            }
        }

        public static string SerializeObjectToJson<T>(T obj)
        {

            var opt = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize<T>(obj, opt);
            return jsonString;
        }

        public static string RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return (string)xElement;
            }
            return (string)new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        public static bool IsJson(string input)
        {
            try
            {
                JObject.Parse(input);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
