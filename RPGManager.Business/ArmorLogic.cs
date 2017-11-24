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
            this.AR.GetAllArmors(userid);
        }

        public bool insertArmor(Armor armor)
        {
            this.AR.insertArmor(armor);
        }

        public bool updateArmor(Armor armor)
        {
            this.AR.updateArmor(armor);

        }

        public bool deleteArmor(Armor armor)
        {
            this.AR.deleteArmor(armor);
        }

        public bool checkArmors(int userid)
        {
            this.AR.checkArmors(userid);
        }
    }
}
