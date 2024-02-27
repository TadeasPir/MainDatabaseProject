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
    /// <summary>
    /// Data Access Object (DAO) for handling PhoneNumber entities.
    /// </summary>
    public class PhoneNumberDAO : IRepozitory<PhoneNumber>
    {
        

        /// <summary>
        /// Deletes a phone number with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the phone number to delete.</param>

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
        /// <summary>
        /// Retrieves all phone numbers from the database.
        /// </summary>
        /// <returns>An enumerable collection of PhoneNumber objects.</returns>

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
        /// <summary>
        /// NOT IMPLEMENTED
        /// Retrieves a phone number by its ID.
        /// </summary>
        /// <param name="id">The ID of the phone number to retrieve.</param>
        /// <returns>The PhoneNumber object with the specified ID.</returns>

        public PhoneNumber GetByID(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Imports phone number data from an XML file into the database.
        /// </summary>
        /// <param name="fileName">The name of the XML file containing phone number data.</param>

        public void Import(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            XmlNodeList nodes = document.SelectNodes("/data/phoneNumber");
            PhoneNumber phoneNumber;


            foreach (XmlNode node in nodes)
            {

                string telphoneNumber = node.SelectSingleNode("phoneNumber").InnerText;
                int manufacturer_id = int.Parse(node.SelectSingleNode("manufacturer_id").InnerText);
               

                phoneNumber = new PhoneNumber(manufacturer_id, telphoneNumber);
                Save(phoneNumber);


            }
        }
        /// <summary>
        /// Saves a new phone number to the database.
        /// </summary>
        /// <param name="phone">The PhoneNumber object to save.</param>

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
        /// <summary>
        /// Updates an existing phone number in the database.
        /// </summary>
        /// <param name="phone">The PhoneNumber object with updated information.</param>

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
