using Newtonsoft.Json;
using System.Xml;

namespace XmlConverter
{
    public static class NewConverter
    {
        public static TObject GetDetail<TObject>(string xml)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);

            var obj = JsonConvert.SerializeXmlNode(doc);

            return JsonConvert.DeserializeObject<TObject>(obj);
        }

        public static TRoot GetDetail<TRoot>(string xml, string tag)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var xmlNode = doc.GetElementsByTagName(tag)[0];

            var obj = JsonConvert.SerializeXmlNode(xmlNode);

            return JsonConvert.DeserializeObject<TRoot>(obj);
        }
    }
}