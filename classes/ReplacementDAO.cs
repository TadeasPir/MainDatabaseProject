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
    public class ReplacementDAO : IRepozitory<Replacement>
    {

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

        public Replacement GetByID(int id)
        {
            throw new NotImplementedException();
        }

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
