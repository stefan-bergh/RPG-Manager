using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Manager
{
    class Database
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Stefan\Documents\Visual Studio 2017\Projects\RPG Manager\RPG Manager\RPGManager.mdf;Integrated Security=True";

        public Database()
        {

        }

        // Used to run all INSERT, UPDATE and DELETE queries.
        public void RunQuery(string Query)
        {
            string query = Query;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Check login, return true is successful.
        public bool checkUser(string user, string pass)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string query = string.Format("SELECT * FROM USERS WHERE Username = '{0}' AND Password = '{1}'", user, pass);
            SqlCommand cmd = new SqlCommand(query, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
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
