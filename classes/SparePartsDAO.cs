using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DatabaseProjectPV.classes
{ 
    
    /// <summary>
    /// Data Access Object (DAO) for handling SpareParts entities.
    /// </summary>
    public class SparePartsDAO : IRepozitory<SpareParts>
    {

        /// <summary>
        /// Deletes a spare part with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the spare part to delete.</param>
       
        public void Delete(int id)
        {
            {
                SqlConnection conn = DatabaseSingleton.GetInstance();

                using (SqlCommand command = new SqlCommand("DELETE from SpareParts where id = @id", conn))
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
        /// Retrieves all spare parts from the database.
        /// </summary>
        /// <returns>An enumerable collection of SpareParts objects.</returns>

        public IEnumerable<SpareParts> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM SpareParts", conn))
            {

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  SpareParts part = new SpareParts
                    {
                      ID = Convert.ToInt32(reader[0].ToString()),
                      Name = reader[1].ToString(),
                      Type = reader[2].ToString(),
                      DimenX = reader[3].ToString(),
                      DimenY = reader[4].ToString(),
                      DimenZ = reader[5].ToString(),
                      Price = Convert.ToInt32(reader[6].ToString())
                  };
                    yield return part;
                }
                reader.Close();
            }
        }
        /// <summary>
        ///  NOT IMPLEMENTED
        /// Retrieves a spare part by its ID.
        /// </summary>
        /// <param name="id">The ID of the spare part to retrieve.</param>
        /// <returns>The SpareParts object with the specified ID.</returns

        public SpareParts GetByID(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Imports spare part data from an XML file into the database.
        /// </summary>
        /// <param name="fileName">The name of the XML file containing spare part data.</param>

        public void Import(string fileName)
        {

            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            XmlNodeList nodes = document.SelectNodes("/data/spareParts");
            SpareParts spareParts;


            foreach (XmlNode node in nodes)
            {

                string name = node.SelectSingleNode("name").InnerText;
                string dimenX = node.SelectSingleNode("dimenX").InnerText;
                string dimenY = node.SelectSingleNode("dimenY").InnerText;
                string dimenZ = node.SelectSingleNode("dimenZ").InnerText;
                string type = node.SelectSingleNode("type").InnerText;
                int price = int.Parse(node.SelectSingleNode("price").InnerText);

                spareParts = new SpareParts(name, type, dimenX, dimenY, dimenZ, price);
                Save(spareParts);


            }
        }
        /// <summary>
        /// Saves a new spare part to the database.
        /// </summary>
        /// <param name="spare">The SpareParts object to save.</param>

        public void Save(SpareParts spare)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT into SpareParts (type, name, dimenX, dimenY, dimenZ, price) values (@type, @name,@dimenX,@dimenY,@dimenZ,@price)", conn))
            {

                command.Parameters.Add(new SqlParameter("@type", spare.Type));
                command.Parameters.Add(new SqlParameter("@name", spare.Name));
                command.Parameters.Add(new SqlParameter("@dimenX", spare.DimenX));
                command.Parameters.Add(new SqlParameter("@dimenY", spare.DimenY));
                command.Parameters.Add(new SqlParameter("@dimenZ", spare.DimenZ));
                command.Parameters.Add(new SqlParameter("@price", spare.Price));
              

                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    spare.ID = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("added");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Incorrect parametrs");
                }

            }
        }
        /// <summary>
        /// Updates an existing spare part in the database.
        /// </summary>
        /// <param name="spare">The SpareParts object with updated information.</param>
        public void Update(SpareParts spare)
        {

            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("UPDATE into SpareParts (id,type, name, dimenX, dimenY, dimenZ, price) values (@id,@type, @name,@dimenX,@dimenY,@dimenZ,@price)", conn))
            {

                command.Parameters.Add(new SqlParameter("@id", spare.ID));
                command.Parameters.Add(new SqlParameter("@type", spare.Type));
                command.Parameters.Add(new SqlParameter("@name", spare.Name));
                command.Parameters.Add(new SqlParameter("@dimenX", spare.DimenX));
                command.Parameters.Add(new SqlParameter("@dimenY", spare.DimenY));
                command.Parameters.Add(new SqlParameter("@dimenZ", spare.DimenZ));
                command.Parameters.Add(new SqlParameter("@price", spare.Price));


                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    spare.ID = Convert.ToInt32(command.ExecuteScalar());
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
