using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseProjectPV.classes
{
    /// <summary>
 /// Data Access Object (DAO) for handling Manufacturer entities.
 /// </summary>
    public class ManufacturerDAO : IRepozitory<Manufacturer>
    {
        /// <summary>
        /// Deletes a manufacturer with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the manufacturer to delete.</param>
        public void Delete(int id)
        {
            {
                SqlConnection conn = DatabaseSingleton.GetInstance();

                using (SqlCommand command = new SqlCommand("DELETE from Manufacturer where id = @id", conn))
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
        /// Retrieves all manufacturers from the database.
        /// </summary>
        /// <returns>An enumerable collection of Manufacturer objects.</returns>

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
        /// <summary>
        /// NOT IMPLEMETED
        /// Retrieves a manufacturer by its ID.
        /// </summary>
        /// <param name="id">The ID of the manufacturer to retrieve.</param>
        /// <returns>The Manufacturer object with the specified ID.</returns>

        public Manufacturer GetByID(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Imports manufacturer data from an XML file into the database.
        /// </summary>
        /// <param name="fileName">The name of the XML file containing manufacturer data.</param>
        
        public void Import(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName); 
            XmlNodeList nodes = document.SelectNodes("/data/manufacturer");
            Manufacturer manufacturer;
           

            foreach (XmlNode node in nodes) 
            {
           
                string name  = node.SelectSingleNode("name").InnerText;


                manufacturer = new Manufacturer(name);
                Save(manufacturer);


            }


        }
        /// <summary>
        /// Saves a new manufacturer to the database.
        /// </summary>
        /// <param name="manufacturer">The Manufacturer object to save.</param>

        public void Save(Manufacturer  manufacturer)
        {

            SqlConnection conn = DatabaseSingleton.GetInstance();
            using (SqlCommand command = new SqlCommand("INSERT into Manufacturer ( name) values (@name)", conn))
            {

                command.Parameters.Add(new SqlParameter("@name", manufacturer.Name));
                



                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    manufacturer.ID = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("added");
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Incorrect parametrs");
                }

            }
        }

        /// <summary>
        /// Updates an existing manufacturer in the database.
        /// </summary>
        /// <param name="manufacturer">The Manufacturer object with updated information.</param>
        
        public void Update(Manufacturer manufacturer)
        {

            SqlConnection conn = DatabaseSingleton.GetInstance();
            using (SqlCommand command = new SqlCommand("INSERT into Manufacturer (id, name) values (@id,@name)", conn))
            {

                command.Parameters.Add(new SqlParameter("@id", manufacturer.ID));
                command.Parameters.Add(new SqlParameter("@name", manufacturer.Name));




                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    manufacturer.ID = Convert.ToInt32(command.ExecuteScalar());
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
