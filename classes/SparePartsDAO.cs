using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProjectPV.classes
{
    public class SparePartsDAO : IRepozitory<SpareParts>
    {
     

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

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

        public SpareParts GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(SpareParts element)
        {
            throw new NotImplementedException();
        }
    }
}
