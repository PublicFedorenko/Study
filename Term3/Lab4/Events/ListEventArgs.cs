using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class ListEventArgs : EventArgs
    {
        public string Message { get; }
        public int Length { get; }

        public ListEventArgs(string mess, int len)
        {

        }
    }
}
