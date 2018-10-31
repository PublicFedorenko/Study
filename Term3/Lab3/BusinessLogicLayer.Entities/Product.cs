using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

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

        [DataMember]
        public string Name { get => name; set => name = value; }
        [DataMember]
        public string Id { get => id; set => id = value; }
        [DataMember]
        public DateTime DateOfManufacture { get => dateOfManufacture; set => dateOfManufacture = value; }
        [DataMember]
        public int Lifetime { get => lifetime; set => lifetime = value; }
        [DataMember]
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
