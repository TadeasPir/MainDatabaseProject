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
      
        public void Delete(int id)
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

        public void Save(PhoneNumber phone)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT into PhoneNumber ( phoneNumber, manufacturer_id) values (@phoneNumber,@manufacturer_id)", conn))
            {

                command.Parameters.Add(new SqlParameter("@phoneNumber", phone.TelephoneNumber));
                command.Parameters.Add(new SqlParameter("@manufacturer_id", phone.Manufacturer_id));
                


                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    phone.ID = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("added");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Incorrect parametrs");
                }

            }
        }

        IEnumerable<PhoneNumber> IRepozitory<PhoneNumber>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
