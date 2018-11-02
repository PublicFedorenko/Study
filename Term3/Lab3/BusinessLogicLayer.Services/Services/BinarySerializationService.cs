using BusinessLogicLayer.Services.Intefaces;
using DataAccessLayer.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Services
{
    class BinarySerializationService<T> : SerializationService<T> where T : class 
    {
        public BinarySerializationService()
        {
            Serializer = new BinarySerializer<T>();
        }
    }
}
