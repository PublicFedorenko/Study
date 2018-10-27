using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace BusinessLogicLayer.Formats
{
    public class Finn : IFormat
    {
        /*
         * Fields for dissassembling
         */
        // TODO Add .+ to regex (data type)
        private readonly string _regExpression = @"(?x)\s* { \s* 
                                            (""(?<keys>\w+)"" \s* : \s* ""(?<values>(\w|\.)+)"" ,? \s*)+ 
                                            };\s*";
        /*
         * Fields for assembling
         */
        private enum TypeParts { DataType, Key, Value }
        private readonly string _openingPart = "" + TypeParts.DataType + " {\n";
        private readonly string _keyValuePartWithSplitter = "  \"" + TypeParts.Key + "\": \"" + TypeParts.Value + "\",\n";
        private readonly string _keyValuePart = "  \"" + TypeParts.Key + "\": \"" + TypeParts.Value + "\"\n";
        private readonly string _closingPart = "};\n";

        /* Dissassembling data into array of matrices which contain pairs key-value */
        public string[][,] Dissassemble(string data, Type objType)
        {
            string typeName = objType.Name;  // name of class
            Regex objRegex = new Regex(typeName + _regExpression);  // add name of class to RegExpression
            MatchCollection matches = objRegex.Matches(data);

            /* Create jagged multidimensional array */
            int objectsCount = matches.Count;
            string[][,] arrayOfMatrices = new string[objectsCount][,];

            /* Allocate memory for pairs key-value in each array */
            for (int i = 0; i < objectsCount; i++)
            {
                int quantityOfPairs = matches[i].Groups["keys"].Captures.Count;  // quantity of pairs key-value
                arrayOfMatrices[i] = new string[quantityOfPairs, 2];  // allocating memory for each pair key-value
            }

            /* Fill matrices with values from matches */
            for (int i = 0; i < arrayOfMatrices.Length; i++)
            {
                for (int j = 0; j < arrayOfMatrices[i].GetLength(0); j++)
                {
                    arrayOfMatrices[i][j, 0] = matches[i].Groups["keys"].Captures[j].Value;
                    arrayOfMatrices[i][j, 1] = matches[i].Groups["values"].Captures[j].Value;
                }
            }

            return arrayOfMatrices;
        }

        /* Asembling objects into formated data */
        public string Assemble<T>(T[] obj)
        {
            string formatedData = String.Empty;

            for (int i = 0; i < obj.Length; i++)  // for each object
            {
                string[,] definedProperties = FindDefinedProperties(obj[i]);  // defined fields == (any value type or not null reference type)
                if (definedProperties.GetLength(0) > 1)
                {
                    /* Opening part */
                    formatedData += _openingPart.Replace(TypeParts.DataType.ToString(), typeof(T).Name);
                    /* Middle part */
                    for (int j = 0; j < definedProperties.GetLength(0) - 1; j++)
                    {
                        formatedData += _keyValuePartWithSplitter.Replace(TypeParts.Key.ToString(), definedProperties[j, 0])
                                                                 .Replace(TypeParts.Value.ToString(), definedProperties[j, 1]);
                    }
                    formatedData += _keyValuePart.Replace(TypeParts.Key.ToString(), definedProperties[definedProperties.GetLength(0) - 1, 0])
                                                 .Replace(TypeParts.Value.ToString(), definedProperties[definedProperties.GetLength(0) - 1, 1]);
                    /* Closing part */
                    formatedData += _closingPart;
                }
                else if (definedProperties.GetLength(0) == 1)
                {
                    /* Opening part */
                    formatedData = _openingPart.Replace(TypeParts.DataType.ToString(), typeof(T).Name);
                    /* Middle part */
                    for (int j = 0; j < definedProperties.GetLength(0) - 1; j++)
                    {
                        formatedData += _keyValuePartWithSplitter.Replace(TypeParts.Key.ToString(), definedProperties[j, 0])
                                                                 .Replace(TypeParts.Value.ToString(), definedProperties[j, 1]);
                    }
                    formatedData += _keyValuePart.Replace(TypeParts.Key.ToString(), definedProperties[definedProperties.GetLength(0) - 1, 0])
                                                 .Replace(TypeParts.Value.ToString(), definedProperties[definedProperties.GetLength(0) - 1, 1]);
                    /* Closing part */
                    formatedData += _closingPart;
                }
            }

            return formatedData;
        }

        private static string[,] FindDefinedProperties<T>(T obj)
        {
            int count = 0;
            PropertyInfo[] props = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            /* Calculate size of array */
            for (int i = 0; i < props.Length; i++)  // for each field
            {
                if (props[i].PropertyType.IsValueType || (props[i].GetValue(obj) != null)) //TODO test IsValueType
                    count++;
            }

            string[,] definedProps = new string[count, 2];
            /* Fill array with pairs key-value */
            for (int i = 0, index = 0; i < props.Length; i++)  // for each field
            {
                if (props[i].PropertyType.IsValueType || (props[i].GetValue(obj) != null)) //TODO test IsValueType
                {
                    definedProps[index, 0] = props[i].Name.ToLower();  // key
                    definedProps[index++, 1] = props[i].GetValue(obj).ToString();  // value
                }
            }

            return definedProps;
        }
    }
}
