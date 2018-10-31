using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataAccessLayer.Serialization
{
    public class BinaryDataSerializer<T> : IDataSerializer<T>
    {
        private BinaryFormatter formatter;

        public BinaryDataSerializer()
        {
            formatter = new BinaryFormatter();
        }

        public void Serialize(T item, string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                formatter.Serialize(fs, item);
            }
        }

        public T Deserialize(string filePath, FileMode fileMode)
        {
            using (FileStream fs = new FileStream(filePath, fileMode))
            {
                return (T) formatter.Deserialize(fs);
            }
        }
    }
}
