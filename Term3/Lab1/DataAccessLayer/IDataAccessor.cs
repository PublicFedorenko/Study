using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDataAccessor
    {
        string Read();
        void Write(string data, FileMode fileMode);
        void Clear();
    }

}
