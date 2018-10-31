using BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;
using DataAccessLayer.Serialization;

namespace ConsoleProjectForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("name", "1", new DateTime(2018, 10, 07), 90);
            string filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.xml";

            XmlDataSerializer<Product> xmlProductSerializer = new XmlDataSerializer<Product>();
            xmlProductSerializer.Serialize(product, filePath, FileMode.Truncate);

            Product newProduct = xmlProductSerializer.Deserialize(filePath, FileMode.Open);

            Console.WriteLine("Name " + newProduct.Name);
            Console.WriteLine("Id " + newProduct.Id);
            Console.WriteLine("DateTime " + newProduct.DateOfManufacture.ToString());
            Console.WriteLine("Lifetime " + newProduct.Lifetime);
        }
    }
}
