using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.Domain.Models;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class CategorieLogic : ICategorieLogic
    {
        public ICategorieRepository CR;

        public CategorieLogic(ICategorieRepository Repo)
        {
            CR = Repo;
        }

        public List<ClassCategory> GetAllCategorys(int userid)
        {
            return CR.GetAllCategorys(userid);
        }

        public bool insertCategory(ClassCategory category)
        {
            return CR.insertCategory(category);
        }

        public bool updateCategory(ClassCategory category)
        {
            return CR.updateCategory(category);
        }

        public bool deleteCategory(ClassCategory category)
        {
            return CR.deleteCategory(category);
        }

        public bool checkCategories(int userid)
        {
            return CR.checkCategories(userid);
        }
    }
}
