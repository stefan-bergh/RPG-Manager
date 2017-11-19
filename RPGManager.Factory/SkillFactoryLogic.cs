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
    class SkillFactoryLogic
    {
        public static ISkillLogic getSkillSQLContext()
        {
            return new SkillLogic(new SkillRepository(new SkillSQLContext()));
        }
    }
}
