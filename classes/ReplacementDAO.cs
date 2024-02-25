using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class ReplacementDAO : IRepozitory<Replacement>
    {
        public void Delete(Replacement element)
        {
            throw new NotImplementedException();
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

        public void Save(Replacement element)
        {
            throw new NotImplementedException();
        }
    }
}
