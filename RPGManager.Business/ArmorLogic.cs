using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class ArmorLogic : IArmorLogic
    {
        public IArmorRepository AR;

        public ArmorLogic(IArmorRepository Repo)
        {
            AR = Repo;
        }
    }
}
