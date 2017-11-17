using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;
using RPGManager.Domain.Models;

namespace Repository
{
    public class CategorieRepository : ICategorieRepository
    {
        private ICategorieContext CC;

        public CategorieRepository(ICategorieContext context)
        {
            CC = context;
        }

        public List<ClassCategory> GetAllCategorys(int userid)
        {
            return CC.GetAllCategorys(userid);
        }

        public bool insertCategory(ClassCategory category)
        {
            return CC.insertCategory(category);
        }

        public bool updateCategory(ClassCategory category)
        {
            return CC.updateCategory(category);
        }

        public bool deleteCategory(ClassCategory category)
        {
            return CC.deleteCategory(category);
        }

        public bool checkCategories(int userid)
        {
            return CC.checkCategories(userid);
        }
    }
}
