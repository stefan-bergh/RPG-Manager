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
    public class ItemLogicFactory
    {
        public static IItemLogic getItemSQLContext()
        {
            return new ItemLogic(new ItemRepository(new ItemSQLContext()));
        }
    }
}
