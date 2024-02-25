using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class ManufacturerDAO : IRepozitory<Manufacturer>
    {
        public void Delete(Manufacturer element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Manufacturer", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Manufacturer manufacturer = new Manufacturer
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString()
                        
                    };
                    yield return manufacturer;
                }
                reader.Close();
            }
        }

        public Manufacturer GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Manufacturer element)
        {
            throw new NotImplementedException();
        }
    }
}
