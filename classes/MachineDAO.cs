using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DatabaseProjectPV.classes
{
    /// <summary>
    /// Data Access Object (DAO) for handling Machine entities.
    /// </summary>
    /// 
    internal class MachineDAO : IRepozitory<Machine>
    {

        /// <summary>
        /// Deletes a machine with the specified ID from the database.
        /// </summary>
        /// <param name="id">The ID of the machine to delete.</param>
        public void Delete(int x)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("DELETE from Machine where id = @id", conn))
            {

                command.Parameters.Add(new SqlParameter("@id", x));

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

        /// <summary>
        /// Retrieves all machines from the database.
        /// </summary>
        /// <returns>An enumerable collection of Machine objects.</returns>
        public IEnumerable<Machine> GetAll()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("SELECT * FROM Machine", conn))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Machine machine = new Machine
                    {
                        ID = Convert.ToInt32(reader[0].ToString()),
                        Name = reader[1].ToString(),
                        Type = reader[2].ToString(),
                        DimenX = reader[3].ToString(),
                        DimenY = reader[4].ToString(),
                        DimenZ = reader[5].ToString(),
                        Price = Convert.ToInt32(reader[6].ToString()),
                        Weight = (float)Convert.ToDecimal(reader[7].ToString()),
                        Manufacturer_id = Convert.ToInt32(reader[8].ToString()),
                        IsNew = Convert.ToBoolean(reader[9].ToString()),

                    };
                    yield return machine;
                }
                reader.Close();
            }

        }

        /// <summary>
        /// NOT IMPLEMENTED
        /// Retrieves a machine by its ID.
        /// </summary>
        /// <param name="id">The ID of the machine to retrieve.</param>
        /// <returns>The Machine object with the specified ID.</returns>

        public Machine GetByID(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Imports machine data from an XML file into the database.
        /// </summary>
        /// <param name="fileName">The name of the XML file containing machine data.</param>

        public void Import(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            XmlNodeList nodes = document.SelectNodes("/data/machine");
            Machine machine;


            foreach (XmlNode node in nodes)
            {

                string name = node.SelectSingleNode("name").InnerText;
                string dimenX = node.SelectSingleNode("dimenX").InnerText;
                string dimenY = node.SelectSingleNode("dimenY").InnerText;
                string dimenZ = node.SelectSingleNode("dimenZ").InnerText;
                string type = node.SelectSingleNode("type").InnerText;
                int price = int.Parse(node.SelectSingleNode("price").InnerText);
                float weight = float.Parse(node.SelectSingleNode("value").InnerText);
                int manufacturer_id = int.Parse(node.SelectSingleNode("manufacturer_id").InnerText);
                bool isNew = bool.Parse(node.SelectSingleNode("manufacturer_id").InnerText);

                machine = new Machine(name, type, dimenX, dimenY, dimenZ, price, weight,manufacturer_id,isNew);
                Save(machine);


            }
        }
        /// <summary>
        /// Saves a new machine to the database.
        /// </summary>
        /// <param name="machine">The Machine object to save.</param>

        public void Save(Machine machine)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("INSERT into Machine (type, name, dimenX, dimenY, dimenZ, price, value, manufacturer_id, isNew) values (@type, @name,@dimenX,@dimenY,@dimenZ,@price,@value,@manufacturer_id,@isNew)", conn))
            {
                
                command.Parameters.Add(new SqlParameter("@type", machine.Type));               
                command.Parameters.Add(new SqlParameter("@name", machine.Name));               
                command.Parameters.Add(new SqlParameter("@dimenX", machine.DimenX));               
                command.Parameters.Add(new SqlParameter("@dimenY", machine.DimenY));               
                command.Parameters.Add(new SqlParameter("@dimenZ", machine.DimenZ));               
                command.Parameters.Add(new SqlParameter("@price", machine.Price));
                command.Parameters.Add(new SqlParameter("@value", machine.Weight));
                command.Parameters.Add(new SqlParameter("@manufacturer_id", machine.Manufacturer_id));
                command.Parameters.Add(new SqlParameter("@isNew", machine.IsNew));

                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    machine.ID = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine("added");
                }
                catch (Exception ex)
                {
                
                    Console.WriteLine("Incorrect parametrs");
                }

            }
        }
        /// <summary>
        /// Updates an existing machine in the database.
        /// </summary>
        /// <param name="machine">The Machine object with updated information.</param>

        public void Update(Machine machine)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            using (SqlCommand command = new SqlCommand("UPDATE into Machine (id,type, name, dimenX, dimenY, dimenZ, price, value, manufacturer_id, isNew) values (@id,@type, @name,@dimenX,@dimenY,@dimenZ,@price,@value,@manufacturer_id,@isNew)", conn))
            {

                command.Parameters.Add(new SqlParameter("@id", machine.Type));
                command.Parameters.Add(new SqlParameter("@type", machine.Type));
                command.Parameters.Add(new SqlParameter("@name", machine.Name));
                command.Parameters.Add(new SqlParameter("@dimenX", machine.DimenX));
                command.Parameters.Add(new SqlParameter("@dimenY", machine.DimenY));
                command.Parameters.Add(new SqlParameter("@dimenZ", machine.DimenZ));
                command.Parameters.Add(new SqlParameter("@price", machine.Price));
                command.Parameters.Add(new SqlParameter("@value", machine.Weight));
                command.Parameters.Add(new SqlParameter("@manufacturer_id", machine.Manufacturer_id));
                command.Parameters.Add(new SqlParameter("@isNew", machine.IsNew));

                try
                {
                    command.ExecuteNonQuery();
                    command.CommandText = "Select @@Identity";
                    machine.ID = Convert.ToInt32(command.ExecuteScalar());
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
