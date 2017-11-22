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
    public class ArmorLogicFactory
    {
        public static IArmorLogic getArmorSQLContext()
        {
            return new ArmorLogic(new ArmorRepository(new ArmorSQLContext()));
        }
    }
}
