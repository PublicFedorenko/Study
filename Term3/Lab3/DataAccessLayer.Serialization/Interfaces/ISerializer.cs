using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer.Serialization
{
    public interface ISerializer<T> where T : class
    {
        void Serialize(T item, string filePath, FileMode fileMode);
        T Deserialize(string filePath, FileMode fileMode);
    }
}
