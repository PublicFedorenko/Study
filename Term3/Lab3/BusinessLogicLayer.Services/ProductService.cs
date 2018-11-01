using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Entities;
using BusinessLogicLayer.Services.Intefaces;
using DataAccessLayer.Serialization;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IEntityService<Product>
    {
        private ISerializer<Product> _serializer;

        public ProductService(object serializer)
        {
            _serializer = (ISerializer<Product>) serializer;
        }

        public IEnumerable<Product> Read()
        {
            return new List<Product>();
        }

        public void Write(IEnumerable<Product> items)
        {

        }
    }
}
