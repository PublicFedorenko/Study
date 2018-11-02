using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataAccessLayer.Serialization
{
    public class XmlSerializer<T> : ISerializer<T> where T : class
    {
        private XmlSerializer xmlSerializer;

        public XmlSerializer()
        {
            xmlSerializer = new XmlSerializer(typeof(T));
        }

        public void Serialize(T item, string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                xmlSerializer.Serialize(fs, item);
            }
        }

        public T Deserialize(string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                return (T) xmlSerializer.Deserialize(fs);
            }
        }
    }
}
