using BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;
using DataAccessLayer.Serialization;
using BusinessLogicLayer.Services;

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

            ProductService productHandler = new ProductService(new JsonSerializer<Product>());
            List<Product> items = (List<Product>) productHandler.Read();
            productHandler.Write(items);


            string filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.xml";
            XmlSerializer<Product[]> xmlSerializer = new XmlSerializer<Product[]>();
            xmlSerializer.Serialize(products, filePath, FileMode.Truncate);

            filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.json";
            JsonSerializer<Product[]> jsonSerializer = new JsonSerializer<Product[]>();
            jsonSerializer.Serialize(products, filePath, FileMode.Truncate);

            filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.soap";
            SoapSerializer<Product[]> soapSerializer = new SoapSerializer<Product[]>();
            soapSerializer.Serialize(products, filePath, FileMode.Truncate);

            filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.dat";
            BinarySerializer<Product[]> binarySerializer = new BinarySerializer<Product[]>();
            binarySerializer.Serialize(products, filePath, FileMode.Truncate);



            filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.json";
            Product[] newProducts = jsonSerializer.Deserialize(filePath, FileMode.Open);
            foreach (Product pr in newProducts)
            {
                Console.WriteLine("Name " + pr.Name);
                Console.WriteLine("Id " + pr.Id);
                Console.WriteLine("DateTime " + pr.DateOfManufacture.ToString());
                Console.WriteLine("Lifetime " + pr.Lifetime);
            }
        }
    }
}
