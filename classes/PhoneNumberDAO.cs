using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class PhoneNumberDAO : IRepozitory<PhoneNumber>
    {
        public void Delete(PhoneNumber element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PhoneNumber> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM PhoneNumber", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PhoneNumber pn = new PhoneNumber
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        TelephoneNumber = reader[1].ToString(),
                        Manufacturer_id = Convert.ToInt32(reader[2].ToString())

                    };
                    yield return pn;
                }
                reader.Close();
            }
        }

        public PhoneNumber GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(PhoneNumber element)
        {
            throw new NotImplementedException();
        }

        IEnumerable<PhoneNumber> IRepozitory<PhoneNumber>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
