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
    public class WeaponLogicFactory
    {
        public static IWeaponLogic getWeaponSQLContext()
        {
            return new WeaponLogic(new WeaponRepository(new WeaponSQLContext()));
        }
    }
}
