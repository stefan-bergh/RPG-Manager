using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class ItemLogic : IItemLogic
    {
        public IItemRepository IR;

        public ItemLogic(IItemRepository Repo)
        {
            IR = Repo;
        }
    }
}
