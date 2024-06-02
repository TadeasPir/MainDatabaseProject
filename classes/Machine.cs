using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DatabaseProjectPV.classes
{
    /// <summary>
    /// Represents a machine table in database.
    /// </summary>


    public class Machine : IBaseClass
    {
        private int id;
        private string name;
        private string type;
        private string dimenX;
        private string dimenY;
        private string dimenZ;
        private float weight;
        private int price;
        private int manufacturer_id;
        private bool isNew;
        

        public Machine()
        {
        }
        public Machine(int id, string name, string type, string dimenX, string dimenY, string dimenZ, int price, float weight, int manufacturer_id, bool isNew)
        {
            ID = id;
            Name = name;
            Type = type;
            DimenX = dimenX;
            DimenY = dimenY;
            DimenZ = dimenZ;
            Price = price;
            Manufacturer_id = manufacturer_id;
            IsNew = isNew;
            Weight = weight;
        }

        public Machine(string name, string type, string dimenX, string dimenY, string dimenZ, int price,float weight, int manufacturer_id, bool isNew)
        {
            ID = 0;
            Name = name;
            Type = type;
            DimenX = dimenX;
            DimenY = dimenY;
            DimenZ = dimenZ;
            Price = price;
            Manufacturer_id = manufacturer_id;
            IsNew = isNew;
            Weight = weight;
        }

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public string DimenX { get => dimenX; set => dimenX = value; }
        public string DimenY { get => dimenY; set => dimenY = value; }
        public string DimenZ { get => dimenZ; set => dimenZ = value; }
        public int Price { get => price; set => price = value; }
        public int Manufacturer_id { get => manufacturer_id; set => manufacturer_id = value; }
        public bool IsNew { get => isNew; set => isNew = value; }
        public float Weight { get => weight; set => weight = value; }

        public override string? ToString()
        {
            return Name + " " + Type + " " + DimenX + "m " + DimenY + "m " + DimenZ + "m " + Price + " Manufacturer id"+ Manufacturer_id+" is new:" +IsNew+" "+Weight+"T";
        }
    }
}
