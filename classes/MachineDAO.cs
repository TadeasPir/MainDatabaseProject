using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    internal class MachineDAO : IRepozitory<Machine>
    {
        public void Delete(Machine element)
        {
            throw new NotImplementedException();
        }

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

        public Machine GetByID(int id)
        {
            throw new NotImplementedException();
        }

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
                }
                catch (Exception ex)
                {
                
                    Console.WriteLine("Incorrect parametrs");
                }

            }
        }
    }
}
