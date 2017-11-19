using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    public class WeaponRepository : IWeaponRepository
    {
        private IWeaponContext WC;

        public WeaponRepository(IWeaponContext context)
        {
            WC = context;
        }
    }
}
