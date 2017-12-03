using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    using RPGManager.Domain.Models;

    public class ItemLogic : IItemLogic
    {
        public IItemRepository IR;

        public ItemLogic(IItemRepository Repo)
        {
            IR = Repo;
        }

        public List<Item> GetAllItems(int userid)
        {
            return this.IR.GetAllItems(userid);
        }

        public bool insertItem(Item item)
        {
            return this.IR.insertItem(item);
        }

        public bool updateItem(Item item)
        {
            return this.IR.updateItem(item);
        }

        public bool deleteItem(Item item)
        {
            return this.IR.deleteItem(item);
        }

        public bool checkItems(int userid)
        {
            return this.IR.checkItems(userid);
        }
    }
}
