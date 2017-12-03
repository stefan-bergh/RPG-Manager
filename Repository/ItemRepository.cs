using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    using RPGManager.Domain.Models;

    public class ItemRepository : IItemRepository
    {
        private IItemContext IC;

        public ItemRepository(IItemContext context)
        {
            IC = context;
        }

        public List<Item> GetAllItems(int userid)
        {
            return this.IC.GetAllItems(userid);
        }

        public bool insertItem(Item item)
        {
            return this.IC.insertItem(item);
        }

        public bool updateItem(Item item)
        {
            return this.IC.updateItem(item);
        }

        public bool deleteItem(Item item)
        {
            return this.IC.deleteItem(item);
        }

        public bool checkItems(int userid)
        {
            return this.IC.checkItems(userid);
        }
    }
}
