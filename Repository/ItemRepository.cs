using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    public class ItemRepository : IItemRepository
    {
        private IItemContext IC;

        public ItemRepository(IItemContext context)
        {
            IC = context;
        }
    }
}
