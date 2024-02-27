using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseProjectPV.classes
{

    /// <summary>
    /// Represents a manufacturer entity.
    /// </summary>
    public class Manufacturer : IBaseClass
    {
        private int id;
        private string name;

        public Manufacturer(int iD, string name)
        {
            ID = iD;
            Name = name;

        }
        public Manufacturer( string name)
        {
            ID = 0;
            Name = name;
        }

        public Manufacturer()
        {
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public override string? ToString()
        {
            return name;
        }
    }
}
