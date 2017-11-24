using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataContext
{
    using RPGManager.Domain.Models;

    public interface IItemContext
    {
        List<Item> GetAllItems(int userid);
        bool insertItem(Item item);
        bool updateItem(Item item);
        bool deleteItem(Item item);
        bool checkItems(int userid);
    }
}
