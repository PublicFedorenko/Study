using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Text.RegularExpressions;

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
        public string Name { get => name;
            set
            {
                if (!Regex.IsMatch(value, @"\w+|\s+"))
                {
                    name = "Invalid characters!";
                    return;
                }
                name = value;
            }
        }
        [DataMember]
        public string Id { get => id;
            set
            {
                if (!Regex.IsMatch(value, @"\w\w\d{4}"))
                {
                    id = "Invalid characters!";
                    return;
                }
                id = value;
            }
        }
        [DataMember]
        public DateTime DateOfManufacture { get => dateOfManufacture; set => dateOfManufacture = value; }
        [DataMember]
        public int Lifetime { get => lifetime;
            set
            {
                if (value < 0 || value > 300)
                {
                    lifetime = 0;
                    return;
                }
                lifetime = value;
            }
        }
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
