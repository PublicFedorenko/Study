using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Intefaces
{
    public interface IEntityService<T>
    {
        void Write(T item, string filePath, FileMode fileMode);
        T Read(string filePath, FileMode fileMode);
    }
}
