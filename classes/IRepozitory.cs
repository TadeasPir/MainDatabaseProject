using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DatabaseProjectPV.classes
{
    public interface IRepozitory<T> where T : IBaseClass
    {
        T GetByID(int id);
        void Update(T element);
        void Save(T element);
        void Delete(int id);
        void Import(string fileName);
    }
}
