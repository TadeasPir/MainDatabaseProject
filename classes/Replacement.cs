using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class Replacement : IBaseClass
    {
        private int id;
        private int spareParts_id;
        private int machine_id;
        private DateTime dateTime;
        public Replacement(int id, int spareParts_id, int machine_id, DateTime dateTime, int iD)
        {
            ID = id;
            SpareParts_id = spareParts_id;
            Machine_id = machine_id;
            this.dateTime = dateTime;
            ID = iD;
            DateTime = dateTime;
        }
        public Replacement( int spareParts_id, int machine_id, DateTime dateTime)
        {
            ID = 0;
            SpareParts_id = spareParts_id;
            Machine_id = machine_id;
            DateTime = dateTime;
        }

        public Replacement()
        {
            
        }


        public int ID { get => id; set => id = value; }
        public int SpareParts_id { get => spareParts_id; set => spareParts_id = value; }
        public int Machine_id { get => machine_id; set => machine_id = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }

        public override string? ToString()
        {
            return "SpareParts id:" + SpareParts_id+" machine id:"+Machine_id+" "+DateTime;
        }
    }
}
