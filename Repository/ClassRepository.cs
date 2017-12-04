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
    public class ClassRepository : IClassRepository
    {
        private IClassContext CC;

        public ClassRepository(IClassContext context)
        {
            CC = context;
        }

        public List<Class> GetAllClasses(int userid)
        {
            return CC.GetAllClasses(userid);
        }

        public bool insertClass(Class cClass)
        {
            return CC.insertClass(cClass);
        }

        public bool updateClass(Class cClass)
        {
            return CC.updateClass(cClass);
        }

        public bool deleteClass(Class cClass)
        {
            return CC.deleteClass(cClass);
        }

        public bool checkClasses(int userid)
        {
            return CC.checkClasses(userid);
        }

        public bool checkCharacterClasses(int classID)
        {
            return CC.checkCharacterClasses(classID);
        }
    }
}
