using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Intefaces
{
    public interface IEntityService<T>
    {
        IEnumerable<T> Read();
        void Write(IEnumerable<T> items);
        //TODO add clear() mb
    }
}
