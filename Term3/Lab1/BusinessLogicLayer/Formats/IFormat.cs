using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Formats
{
    public interface IFormat
    {
        string[][,] Dissassemble(string data, Type type);
        string Assemble<T>(T[] obj);
    }
}
