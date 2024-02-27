using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseProjectPV.classes
{
    public class PhoneNumberDAO : IRepozitory<PhoneNumber>
    {
      
        public void Delete(int id)
        {
            {
                SqlConnection conn = DatabaseSingleton.GetInstance();

                using (SqlCommand command = new SqlCommand("DELETE from PhoneNumber where id = @id", conn))
                {

                    command.Parameters.Add(new SqlParameter("@id", id));

                    try
                    {
                        command.ExecuteNonQuery();


                        Console.WriteLine("deleted");
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("Incorrect parametrs");
                    }

                }
            }
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

        public void Import(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            XmlNodeList nodes = document.SelectNodes("/data/PhoneNumber");
            PhoneNumber phoneNumber;


            foreach (XmlNode node in nodes)
            {

                string telphoneNumber = node.SelectSingleNode("phoneNumber").InnerText;
                int manufacturer_id = int.Parse(node.SelectSingleNode("manufacturer_id").InnerText);
               

                phoneNumber = new PhoneNumber(manufacturer_id, telphoneNumber);
                Save(phoneNumber);


            }
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

        public void Update(PhoneNumber phone)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("UPDATE into PhoneNumber (id phoneNumber, manufacturer_id) values (@id,@phoneNumber,@manufacturer_id)", conn))
            {

                command.Parameters.Add(new SqlParameter("@id", phone.ID));
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

      
    }
}
