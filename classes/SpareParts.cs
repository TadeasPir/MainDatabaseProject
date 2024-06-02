using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseProjectPV.classes
{

    /// <summary>
    /// Represents a spare parts entry in the database.
    /// </summary>
    /// 
    public class SpareParts : IBaseClass
    {
        private int id;
        private string name;
        private string type;
        private string dimenX;
        private string dimenY;
        private string dimenZ;
        private int price;
        public SpareParts() { }

        public SpareParts(int iD, string name, string type, string dimenX, string dimenY, string dimenZ, int price)
        {
            ID = iD;
            Name = name;
            Type = type;
            DimenX = dimenX;
            DimenY = dimenY;
            DimenZ = dimenZ;
            Price = price;
        }
        public SpareParts( string name, string type, string dimenX, string dimenY, string dimenZ, int price)
        {
            Name = name;
            Type = type;
            DimenX = dimenX;
            DimenY = dimenY;
            DimenZ = dimenZ;
            Price = price;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string DimenX { get => dimenX; set => dimenX = value; }
        public string DimenY { get => dimenY; set => dimenY = value; }
        public string DimenZ { get => dimenZ; set => dimenZ = value; }
        public int Price { get => price; set => price = value; }

        public override string? ToString()
        {
            return Name+ " "+Type+" "+DimenX+"m "+DimenY+"m "+DimenZ+"m "+Price;
        }
    }
}
