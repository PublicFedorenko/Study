using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int BirtYear { get => birthYear; set => birthYear = value; }
    }
}
