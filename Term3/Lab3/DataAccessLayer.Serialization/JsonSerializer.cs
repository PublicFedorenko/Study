using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace DataAccessLayer.Serialization
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        private DataContractJsonSerializer jsonSerializer;

        public JsonSerializer()
        {
            jsonSerializer = new DataContractJsonSerializer(typeof(T));
        }

        public void Serialize(T item, string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                jsonSerializer.WriteObject(fs, item);
            }
        }

        public T Deserialize(string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                return (T) jsonSerializer.ReadObject(fs);
            }
        }
    }
}
