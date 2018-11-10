using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessLogicLayer.Services.Interfaces
{
    interface ISerializerService<T> where T : class
    {
        void Serialize(T item, string filePath, FileMode fileMode);
        T Deserialize(string filePath, FileMode fileMode);
    }
}
