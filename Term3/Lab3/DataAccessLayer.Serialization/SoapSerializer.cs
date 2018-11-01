using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace DataAccessLayer.Serialization
{
    public class SoapSerializer<T> : ISerializer<T> where T : class
    {
        SoapFormatter soapFormatter;

        public SoapSerializer()
        {
            soapFormatter = new SoapFormatter();
        }

        public void Serialize(T item, string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                soapFormatter.Serialize(fs, item);
            }
        }

        public T Deserialize(string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                return (T) soapFormatter.Deserialize(fs);
            }
        }
    }
}
