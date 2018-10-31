using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    [Serializable]
    public class Product
    {
        private string name;
        private string id;
        private DateTime dateOfManufacture;
        private int lifetime;
        private DateTime expirationDate;

        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
        public DateTime DateOfManufacture { get => dateOfManufacture; set => dateOfManufacture = value; }
        public int Lifetime { get => lifetime; set => lifetime = value; }
        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }

        public Product() { }

        public Product(string n, string id, DateTime manufac, int life)
        {
            Name = n;
            Id = id;
            dateOfManufacture = manufac;
            Lifetime = life;
            expirationDate = dateOfManufacture.AddDays(Lifetime);
        }

        public bool IsExpired()
        {
            return ExpirationDate >= DateTime.Now.Date;
        }
    }
}
