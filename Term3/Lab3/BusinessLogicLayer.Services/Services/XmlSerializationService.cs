using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Intefaces;
using DataAccessLayer.Serialization;

namespace BusinessLogicLayer.Services.Services
{
    public class XmlSerializationService<T> : SerializationService<T> where T : class
    {
        public XmlSerializationService()
        {
           Serializer = new XmlSerializer<T>();
        }
    }
}
