using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class WeaponLogic : IWeaponLogic
    {
        public IWeaponRepository WR;

        public WeaponLogic(IWeaponRepository Repo)
        {
            WR = Repo;
        }
    }
}
