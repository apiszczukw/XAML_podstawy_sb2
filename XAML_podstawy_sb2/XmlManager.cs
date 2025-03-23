using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XAML_podstawy_sb2
{
    public class XmlManager
    {
        public static void SerializujDoXML<T>(T obiekt, string sciezka)
        {
            var serializer = new XmlSerializer(typeof(T));

            using(var stream = new StreamWriter(sciezka))
            {
                serializer.Serialize(stream, obiekt);
            }
        }
    }
}
