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
    public class CategorieSQLContext : ICategorieContext
    {
        databaseCommands dbC = new databaseCommands();
        public List<ClassCategory> GetAllCategorys(int userid)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT * FROM [Dbo].[ClassCategory] WHERE [UserAccountID] = '{0}'", userid));

            List<ClassCategory> categories = new List<ClassCategory>();
            foreach (DataRow row in dt.Rows)
            {
                categories.Add(new ClassCategory((int)row["ClassCategoryID"], (int)row["UserAccountID"], row["Name"].ToString(), row["Description"].ToString()));
            }
            return categories;
        }

        public bool insertCategory(ClassCategory category)
        {
             return dbC.RunQuery(string.Format(
                    "INSERT INTO [Dbo].[ClassCategory] (UserAccountID, Name, Description) VALUES ('{0}', '{1}', '{2}');",
                    category.AccountId, category.Name, category.Description));
            
        }

        public bool updateCategory(ClassCategory category)
        {
            return dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[ClassCategory] SET [Name] = '{1}', Description = '{2}' WHERE [UserAccountID] = '{0}'",
                category.AccountId, category.Name, category.Description));
        }

        public bool deleteCategory(ClassCategory category)
        {
            return dbC.RunQuery(string.Format(
                "DELETE FROM [Dbo].[ClassCategory] WHERE [ClassCategoryID] = '{0}'",
                category.Id));
        }

        public bool checkCategories(int userid)
        {
            return dbC.checkQuery(string.Format(
                "SELECT * FROM [Dbo].[ClassCategory] WHERE [UserAccountID] = '{0}'",
                userid));
        }
    }
}
