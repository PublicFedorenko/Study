using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Entities
{
    public class Row : IComparable
    {
        private string data;
        
        public string Data { get => data; set => data = value; }

        public Row(string value)
        {
            Data = value;
        }

        public int CompareTo(object obj)
        {
            return this.Data.CompareTo(((Row)obj).Data);
        }
    }
}
