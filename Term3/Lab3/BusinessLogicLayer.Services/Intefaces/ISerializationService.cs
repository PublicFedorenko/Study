using DataAccessLayer.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Intefaces
{
    public abstract class SerializationService<T> where T : class
    {
        private ISerializer<T> _serializer;

        public ISerializer<T> Serializer { get => _serializer; set => _serializer = value; }

        void Write(T item, string filePath, FileMode fileMode)
        {
            _serializer.Serialize(item, filePath, fileMode);
        }
        T Read(string filePath, FileMode fileMode)
        {
            return _serializer.Deserialize(filePath, fileMode);
        }
    }
}
