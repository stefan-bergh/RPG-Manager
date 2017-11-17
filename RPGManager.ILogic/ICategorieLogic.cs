using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGManager.Domain.Models;

namespace RPGManager.ILogic
{
    public interface ICategorieLogic
    {
        List<ClassCategory> GetAllCategorys(int userid);
        bool insertCategory(ClassCategory category);
        bool updateCategory(ClassCategory category);
        bool deleteCategory(ClassCategory category);

        bool checkCategories(int userid);

    }
}
