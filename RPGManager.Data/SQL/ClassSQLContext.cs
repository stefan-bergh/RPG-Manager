using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using RPGManager.Domain.Models;

namespace RPGManager.Data.SQL
{
    public class ClassSQLContext : IClassContext
    {
        databaseCommands dbC = new databaseCommands();
        public List<Class> GetAllClasses(int userid)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT * FROM [Dbo].[Class] WHERE [UserAccountID] = '{0}'", userid));

            List<Class> classes = new List<Class>();
            foreach (DataRow row in dt.Rows)
            {
                classes.Add(new Class((int)row["ClassID"], (int)row["UserAccountID"], (int)row["ClassCategoryID"], row["Name"].ToString(), (int)row["StartingLevel"]));
            }
            return classes;
        }

        public bool insertClass(Class cClass)
        {
            return dbC.RunQuery(string.Format(
                "INSERT INTO [Dbo].[Class] (UserAccountID, ClassCategoryID, Name, StartingLevel) VALUES ('{0}', '{1}', '{2}', {3});",
                cClass.AccountId, cClass.ClassCategoryId, cClass.Name, cClass.StartingLevel));
        }

        public bool updateClass(Class cClass)
        {
            return dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Class] SET [ClassCategoryID] = '{1}', [Name] = '{2}', [StartingLevel] = '{3}' WHERE [ClassID] = '{0}'",
                cClass.Id, cClass.ClassCategoryId, cClass.Name, cClass.StartingLevel));
        }

        public bool deleteClass(Class cClass)
        {
            return dbC.RunQuery(string.Format(
                "DELETE FROM [Dbo].[ClassCategory] WHERE [ClassID] = '{0}'",
                cClass.Id));
        }

        public bool checkClasses(int userid)
        {
            return dbC.checkQuery(string.Format(
                "SELECT * FROM [Dbo].[Class] WHERE [UserAccountID] = '{0}'",
                userid));
        }

        public bool checkCharacterClasses(int classID)
        {
            return dbC.checkQuery(string.Format(
                "SELECT * FROM [Dbo].[Class] JOIN [Dbo].[Character] ON Class.ClassID = Character.ClassID WHERE Class.ClassID = '{0}'",
                classID));
        }
    }
}
