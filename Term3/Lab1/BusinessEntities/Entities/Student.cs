using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BusinessEntities.Interfaces;

namespace BusinessEntities.Entities
{   [Serializable]
    public class Student : IStudy, IEditableObject
    {
        private string firstName;
        private string lastName;
        private string studentId;
        private int course;
        private int recordBookId;
        private string gender;
        private double averageGrade;
        private int idCode;

        /* IEditableObject interface */
        private Student backupCopy;
        private bool inEdit;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string StudentId { get => studentId; set => studentId = value; }
        public int Course { get => course; set => course = value; }
        public int RecordBookId { get => recordBookId; set => recordBookId = value; }
        public string Gender { get => gender; set => gender = value; }
        public double AverageGrade { get => averageGrade; set => averageGrade = value; }
        public int IdCode { get => idCode; set => idCode = value; }

        public Student() { }

        public Student(string firstName, string lastName, string studentId, int course)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentId = studentId;
            Course = course;
        }

        public void Study()
        {
            Course++;
        }

        public void BeginEdit()
        {
            if (inEdit) return;
            inEdit = true;
            backupCopy = DeepClone(this);
        }
        public void CancelEdit()
        {
            if (!inEdit) return;
            inEdit = false;

            PropertyInfo[] props = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in props)
            {
                p.SetValue(this, p.GetValue(backupCopy));
            }
        }
        public void EndEdit()
        {
            if (!inEdit) return;
            inEdit = false;
            backupCopy = null;
        }

        public static T DeepClone<T>(T obj) //TODO move to ExternalMethods class
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

    }
}
