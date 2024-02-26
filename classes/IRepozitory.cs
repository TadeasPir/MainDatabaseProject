using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public interface IRepozitory<T> where T : IBaseClass
    {
        T GetByID(int id);
        IEnumerable<T> GetAll();
        void Save(T element);
        void Delete(int id);
    }
}
