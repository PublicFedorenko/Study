using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Intefaces;
using DataAccessLayer.Serialization;

namespace BusinessLogicLayer.Services
{
    public class XmlSerializerService<T> : IEntityService<T> where T : class
    {
        private ISerializer<T> _iSerializer;

        public XmlSerializerService(ISerializer<T> iSerializer)
        {
            _iSerializer = iSerializer;
        }

        public void Write(T item, string filePath, FileMode fileMode)
        {
            _iSerializer.Serialize(item, filePath, fileMode);
        }

        public T Read(string filePath, FileMode fileMode)
        {
            return _iSerializer.Deserialize(filePath, fileMode);
        }
    }
}
