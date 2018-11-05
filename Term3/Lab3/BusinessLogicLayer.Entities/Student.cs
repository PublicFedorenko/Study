using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Student
    {
        private string id;
        private string firstName;
        private string lastName;
        private int birthYear;
        private string groupId;

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
        public string FirstName { get => firstName;
            set
            {
                if (!Regex.IsMatch(value, @"\w+|\s+"))
                {
                    firstName = "Invalid characters!";
                    return;
                }
                firstName = value;
            }
        }
        public string LastName { get => lastName;
            set
            {
                if (!Regex.IsMatch(value, @"\w+|\s+"))
                {
                    lastName = "Invalid characters!";
                    return;
                }
                lastName = value;
            }
        }
        public int BirtYear { get => birthYear;
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                {
                    birthYear = -1;
                    return;
                }
                birthYear = value;
            }
        }
    }
}
