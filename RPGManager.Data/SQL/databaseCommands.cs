using System.Data;
using System.Data.SqlClient;

namespace RPGManager.Data.SQL
{
    class databaseCommands
    {
        private const string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stefan\Documents\Visual Studio 2017\Projects\RPG Manager\RPGManager.Data\SQL\RPGManagerDB.mdf;Integrated Security=True";
        
        // Used to run all INSERT, UPDATE and DELETE queries.
        public void RunQuery(string Query)
        {
            var query = Query;
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
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
    }
}
