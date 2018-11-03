using BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using BusinessLogicLayer.Services;
using System.Reflection;
using BusinessLogicLayer.Services.Intefaces;

namespace ConsoleProjectForTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("name", "1", new DateTime(2018, 10, 07), 90);
            Product product1 = new Product("name", "1", new DateTime(2018, 10, 07), 90);
            Product product2 = new Product("name", "1", new DateTime(2018, 10, 07), 90);
            Product[] products = new Product[] { product, product1, product2 };
            string filePath = @"C:\Progbase\Study\Term3\Lab3\Products.xml"; 

            // пример вызова
            XmlSerializerService<Product> xmlSerializerService = new XmlSerializerService<Product>();
            xmlSerializerService.Write(product, filePath, FileMode.Truncate);   
            Product newProduct = xmlSerializerService.Read(filePath, FileMode.Open);

            Console.WriteLine(newProduct.Name);
            Console.WriteLine(newProduct.Id);
            Console.WriteLine(newProduct.DateOfManufacture);
            Console.WriteLine(newProduct.Lifetime);
            Console.WriteLine(newProduct.ExpirationDate);
        }
    }
}
