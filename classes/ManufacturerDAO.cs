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
    }
}
