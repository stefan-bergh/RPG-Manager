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

    public class ArmorLogic : IArmorLogic
    {
        public IArmorRepository AR;

        public ArmorLogic(IArmorRepository Repo)
        {
            AR = Repo;
        }

        public List<Armor> GetAllArmors(int userid)
        {
            return this.AR.GetAllArmors(userid);
        }

        public bool insertArmor(Armor armor)
        {
            return this.AR.insertArmor(armor);
        }

        public bool updateArmor(Armor armor)
        {
            return this.AR.updateArmor(armor);

        }

        public bool deleteArmor(Armor armor)
        {
            return this.AR.deleteArmor(armor);
        }

        public bool checkArmors(int userid)
        {
            return this.AR.checkArmors(userid);
        }
    }
}
