using System.Data.SqlClient;

namespace RPG_Manager
{
    internal class Database
    {
        private const string connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stefan\Documents\Visual Studio 2017\Projects\RPG Manager\RPG Manager\RPGManager.mdf;Integrated Security=True"
            ;

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

        //Check login, return true is successful.
        public bool checkUser(string user, string pass)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();

            var query = string.Format("SELECT * FROM USERS WHERE Username = '{0}' AND Password = '{1}'", user, pass);
            var cmd = new SqlCommand(query, conn);

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