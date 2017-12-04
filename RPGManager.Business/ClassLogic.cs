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
    public class ClassLogic : IClassLogic
    {
        public IClassRepository CR;

        public ClassLogic(IClassRepository Repo)
        {
            CR = Repo;
        }

        public List<Class> GetAllClasses(int userid)
        {
            return CR.GetAllClasses(userid);
        }

        public bool insertClass(Class cClass)
        {
            return CR.insertClass(cClass);
        }

        public bool updateClass(Class cClass)
        {
            return CR.updateClass(cClass);
        }

        public bool deleteClass(Class cClass)
        {
            return CR.deleteClass(cClass);
        }

        public bool checkClasses(int userid)
        {
            return CR.checkClasses(userid);
        }

        public bool checkCharacterClasses(int classID)
        {
            return this.CR.checkCharacterClasses(classID);
        }
    }
}
