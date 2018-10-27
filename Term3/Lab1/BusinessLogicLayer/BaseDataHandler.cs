using BusinessLogicLayer.Formats;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BaseDataHandler
    {
        public enum AccessType { Text, Binary}
        internal dynamic GetFormat(string filePath)
        {
            string fileType = Regex.Match(filePath, @"\.\w+").Value;
            if (fileType == "." + Char.ToLower(typeof(Finn).Name[0]) + (typeof(Finn).Name).Substring(1))
                return new Finn();
            if (fileType == "." + Char.ToLower(typeof(Jake).Name[0]) + (typeof(Jake).Name).Substring(1))
                return new Jake();

            throw new ArgumentException("Unsupported format.");
        }
    }
}
