using BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Entities
{
    [Serializable]
    public class Teacher : ITeach, IEditableObject
    {
        private string firstName;
        private string lastName;
        private string internalId;
        private int workExperience;
        private string gender;
        private int idCode;

        /* IEditableObject interface */
        private Teacher backupCopy;
        private bool inEdit;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string InternalId { get => internalId; set => internalId = value; }
        public int WorkExperience { get => workExperience; set => workExperience = value; }
        public string Gender { get => gender; set => gender = value; }
        public int IdCode { get => idCode; set => idCode = value; }
        
        public Teacher() { }

        public Teacher(string firstName, string lastName, string gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
        }

        public void Teach()
        {
            WorkExperience++;
        }

        /* IEditableObject interface */
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
