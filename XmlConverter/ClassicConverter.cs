using Nfe.Lib;
using System.IO;
using System.Xml.Serialization;

namespace XmlConverter
{
    public static class ClassicConverter
    {
        public static nfeProcNFeInfNFeDet GetDetail(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(nfeProc));
            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                var nfe = (nfeProc)serializer.Deserialize(reader);
                return nfe.NFe.infNFe.det;
            }
        }
    }
}