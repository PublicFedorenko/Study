using BusinessLogicLayer.Services.Intefaces;
using DataAccessLayer.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Services
{
    public class JsonSerializationService<T> : SerializationService<T> where T : class
    {
        public JsonSerializationService()
        {
            Serializer = new JsonSerializer<T>();
        }
    }
}
