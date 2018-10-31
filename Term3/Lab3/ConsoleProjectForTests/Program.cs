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
            Product product1 = new Product("name", "1", new DateTime(2018, 10, 07), 90);
            Product product2 = new Product("name", "1", new DateTime(2018, 10, 07), 90);
            Product[] products = new Product[] { product, product1, product2 };
            string filePath = @"C:\Progbase\Study\Term3\Lab3\ConsoleProjectForTests\Products.dat";



            BinaryDataSerializer<Product[]> binarySerializer = new BinaryDataSerializer<Product[]>();
            binarySerializer.Serialize(products, filePath, FileMode.Truncate);



            Product[] newProducts = binarySerializer.Deserialize(filePath, FileMode.Open);
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
