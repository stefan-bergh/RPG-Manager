using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    public class ArmorRepository : IArmorRepository
    {
        private IArmorContext AC;

        public ArmorRepository(IArmorContext context)
        {
            AC = context;
        }
    }
}
