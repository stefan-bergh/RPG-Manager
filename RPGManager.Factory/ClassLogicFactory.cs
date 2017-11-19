using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using RPGManager.Business;
using RPGManager.Data.SQL;
using RPGManager.ILogic;

namespace RPGManager.Factory
{
    class ClassLogicFactory
    {
        public static IClassLogic getClassSQLContext()
        {
            return new ClassLogic(new ClassRepository(new ClassSQLContext()));
        }
    }
}
