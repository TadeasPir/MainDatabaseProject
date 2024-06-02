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
    /// Data Access Object (DAO) for handling Replacement entities.
    /// </summary>
    /// 
    public class ReplacementDAO : IRepozitory<Replacement>
    {
        /// <summary>
        /// Deletes a replacement with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the replacement to delete.</param>
        public void Delete(int id)
        {
            {
                SqlConnection conn = DatabaseSingleton.GetInstance();

                using (SqlCommand command = new SqlCommand("DELETE from Replacement where id = @id", conn))
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
        /// Retrieves all replacements from the database.
        /// </summary>
        /// <returns>An enumerable collection of Replacement objects.</returns>
        public IEnumerable<Replacement> GetAll()
        {

            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Replacement", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Replacement replacement = new Replacement
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Machine_id = Convert.ToInt32(reader[1].ToString()),
                        SpareParts_id = Convert.ToInt32(reader[2].ToString()),
                        DateTime = Convert.ToDateTime(reader[3].ToString())

                    };
                    yield return replacement;
                }
                reader.Close();
            }


        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// Retrieves a replacement by its ID.
        /// </summary>
        /// <param name="id">The ID of the replacement to retrieve.</param>
        /// <returns>The Replacement object with the specified ID.</returns>
        public Replacement GetByID(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Imports replacement data from an XML file into the database.
        /// </summary>
        /// <param name="fileName">The name of the XML file containing replacement data.</param>
        

        public void Import(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            XmlNodeList nodes = document.SelectNodes("/data/replacement");
            Replacement replacement;


            foreach (XmlNode node in nodes)
            {
               
                int spareParts_id = int.Parse(node.SelectSingleNode("spareParts_id").InnerText);
                int machine_id = int.Parse(node.SelectSingleNode("machine_id").InnerText);
                string date = node.SelectSingleNode("date").InnerText;

                replacement = new Replacement(spareParts_id, machine_id, Convert.ToDateTime(date));
                Save(replacement);


            }
        }
        /// <summary>
        /// Saves a new replacement to the database.
        /// </summary>
        /// <param name="replacement">The Replacement object to save.</param>

        public void Save(Replacement replacement)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT into Replacement ( machine_id, spareParts_id,date) values (@machine_id,@spareParts_id,@date)", conn))
            {

                command.Parameters.Add(new SqlParameter("@machine_id", replacement.Machine_id));
                command.Parameters.Add(new SqlParameter("@spareParts_id", replacement.SpareParts_id));
                command.Parameters.Add(new SqlParameter("@date", replacement.DateTime));

                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    replacement.ID = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("added");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Incorrect parametrs");
                }

            }
        }
        /// <summary>
        /// Updates an existing replacement in the database.
        /// </summary>
        /// <param name="replacement">The Replacement object with updated information.</param>
        public void Update(Replacement replacement)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT into Replacement (id, machine_id, spareParts_id,date) values (@id,@machine_id,@spareParts_id,@date)", conn))
            {

                command.Parameters.Add(new SqlParameter("@id", replacement.ID));
                command.Parameters.Add(new SqlParameter("@machine_id", replacement.Machine_id));
                command.Parameters.Add(new SqlParameter("@spareParts_id", replacement.SpareParts_id));
                command.Parameters.Add(new SqlParameter("@date", replacement.DateTime));



                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    replacement.ID = Convert.ToInt32(command.ExecuteScalar());
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
