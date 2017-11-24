using System.Data;
using System.Data.SqlClient;

namespace RPGManager.Data.SQL
{
    class databaseCommands
    {
        private const string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stefan\Documents\Visual Studio 2017\Projects\RPG Manager\RPGManager.Data\SQL\RPGManagerDB.mdf;Integrated Security=True";
        
        // Used to run all INSERT, UPDATE and DELETE queries.
        public bool RunQuery(string Query)
        {
            /*y
            {*/
                var query = Query;
                var conn = new SqlConnection(connectionString);
                conn.Open();
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
/*          }
            catch
            {
                return false;
            }*/
        }

        // Get query results back as table
        public DataTable getTable(string Query)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand(Query, conn);

            DataTable dt = new DataTable();

            using (var reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }

            conn.Close();

            return dt;
        }

        // Check if query returns any value
        public bool checkQuery(string Query)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();

            var cmd = new SqlCommand(Query, conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    conn.Close();
                    return true;
                }
            }

            conn.Close();
            return false;
        }


        // Specific stored procedure

        public int InsertEquipment(int userid, string name, float price, int equipmenttype)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();

            var cmd = new SqlCommand("AddEquipment", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UserID", userid);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Type", equipmenttype);

            SqlParameter outputParameter = new SqlParameter();
            outputParameter.ParameterName = "@EquipmentID";
            outputParameter.SqlDbType = SqlDbType.Int;
            outputParameter.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParameter);

            cmd.ExecuteNonQuery();

            int EquipmentID = (int)outputParameter.Value;

            return EquipmentID;
        }
    }
}
