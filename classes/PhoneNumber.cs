using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class PhoneNumber : IBaseClass
    {
        private int id;
        private string telephoneNumber;
        private int manufacturer_id;

        public PhoneNumber(int id, int manufacturer_id, string telephoneNumber)
        {
            ID = id;
            Manufacturer_id = manufacturer_id;
            TelephoneNumber = telephoneNumber;
        }
        public PhoneNumber( int manufacturer_id, string telephoneNumber)
        {
            ID = 0;
            Manufacturer_id = manufacturer_id;
            TelephoneNumber = telephoneNumber;
        }
        public PhoneNumber()
        {
        }

        public int ID { get => id; set => id = value; }
       
        public int Manufacturer_id { get => manufacturer_id; set => manufacturer_id = value; }
        public string TelephoneNumber { get => telephoneNumber; set => telephoneNumber = value; }

        public override string? ToString()
        {
            return TelephoneNumber+" Manufacturer id"+Manufacturer_id;
        }
    }
}
