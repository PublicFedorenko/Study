using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLogicLayer.Formats;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;

namespace BusinessLogicLayer
{
       
    public class ObjectHandler<T> where T : class, new()
    {
        private readonly IDataAccessor _iDataAccessor;
        private readonly IFormat _iFormat;

        public ObjectHandler(IDataAccessor iDataAccessor, IFormat iFormat)
        {
            if (iDataAccessor == null)
                throw new ArgumentNullException("iDataAccessor in TextParser is null");
            if (iFormat == null)
                throw new ArgumentNullException("iFormat in TextParser is null");

            _iDataAccessor = iDataAccessor;
            _iFormat = iFormat;
        }
        
        public T[] Construct()
        {
            string data = _iDataAccessor.Read();  // read data from file
            string[][,] values = _iFormat.Dissassemble(data, typeof(T));  // grab array of matrices of pairs key-value

            return CreateEntities(ref values);
        }

        private static T[] CreateEntities(ref string[][,] values)
        {
            int entitiesCount = values.Length;

            /* Declare array of entities */
            T[] entities = new T[entitiesCount];
            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] = new T();
            }

            /*
             * For property in entity
             * Set value of property using value in jagged array of matrices
             * Where: values[values.Length][GetLength(0), GetLength(1)]
             */
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = 0; j < values[i].GetLength(0); j++)
                {
                    string propName = values[i][j, 0]; // grab key
                    int propIndex = GetPropertyIndex(propName, properties);  // find index of property with name "propertyName"
                    if (propIndex == -1)
                        throw new Exception("Can't find property with name " + propName);
                    var value = Convert.ChangeType(values[i][j, 1], properties[propIndex].PropertyType, CultureInfo.InvariantCulture);  // convert string type to type of property
                    properties[propIndex].SetValue(entities[i], value);
                }
            }

            return entities;
        }

        private static int GetPropertyIndex(string requiredName, PropertyInfo[] property)
        {
            int index = 0;
            while (index < property.Length)
            {
                string actualPropertyName = property[index].Name;
                if (String.Equals(requiredName, actualPropertyName.ToLower(), StringComparison.CurrentCultureIgnoreCase))
                    return index;
                index++;
            }

            return -1;
        }

        public void Deconstruct(T[] obj, FileMode fm)
        {
            string data = _iFormat.Assemble(obj);
            _iDataAccessor.Write(data, fm);
        }
    }
}
