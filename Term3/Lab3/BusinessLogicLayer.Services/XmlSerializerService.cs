using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Services.Intefaces;
using DataAccessLayer.Serialization;

namespace BusinessLogicLayer.Services
{
    public class XmlSerializerService<T> : SerializationService<T> where T : class
    {
        public XmlSerializerService()
        {
           Serializer = new XmlSerializer<T>();
        }
    }
}
