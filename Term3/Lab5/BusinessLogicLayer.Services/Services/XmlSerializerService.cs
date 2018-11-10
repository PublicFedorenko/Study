using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BusinessLogicLayer.Services.Services
{
    public class XmlSerializerService<T> : ISerializerService<T> where T : class
    {
        private XmlSerializer<T> xmlSerializer;

        public XmlSerializerService()
        {
            xmlSerializer = new XmlSerializer<T>();
        }

        public void Serialize(T item, string filePath, FileMode fileMode)
        {
            xmlSerializer.Serialize(item, filePath, fileMode);
        }

        public T Deserialize(string filePath, FileMode fileMode)
        {
            return xmlSerializer.Deserialize(filePath, fileMode);
        } 
    }
}
