using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using RPGManager.Domain.Models;

namespace RPGManager.Data.SQL
{
    public class UserSQLContext : IUserContext
    {
        databaseCommands dbC = new databaseCommands();
        public bool checkUser(string name, string pass)
        {
            return dbC.checkQuery(string.Format(
                "SELECT * FROM [Dbo].[UserAccount] WHERE [Name] = '{0}' AND [Password] = '{1}'",
                name, pass));
        }

        public User getUser(string name, string pass)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT * FROM [Dbo].[UserAccount] WHERE [Name] = '{0}' AND [Password] = '{1}'", name, pass));

            User user = null;
            if (dt.Rows[0]["RefUserAccountID"] == DBNull.Value)
                user = new User((int)dt.Rows[0]["UserAccountID"], (string)dt.Rows[0]["Name"], (string)dt.Rows[0]["Password"], (string)dt.Rows[0]["Mail"]);
            else
                user = new User((int)dt.Rows[0]["UserAccountID"], (string)dt.Rows[0]["Name"], (string)dt.Rows[0]["Password"], (string)dt.Rows[0]["Mail"], (int)dt.Rows[0]["RefUserAccountID"]);


            return user;
        }
    }
}
