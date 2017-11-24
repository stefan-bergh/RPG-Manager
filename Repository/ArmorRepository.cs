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

    public class ArmorRepository : IArmorRepository
    {
        private IArmorContext AC;

        public ArmorRepository(IArmorContext context)
        {
            AC = context;
        }

        public List<Armor> GetAllArmors(int userid)
        {
            this.AC.GetAllArmors(userid);
        }

        public bool insertArmor(Armor armor)
        {
            this.AC.insertArmor(armor);
        }

        public bool updateArmor(Armor armor)
        {
            this.AC.updateArmor(armor);
        }

        public bool deleteArmor(Armor armor)
        {
            this.AC.deleteArmor(armor);
        }

        public bool checkArmors(int userid)
        {
            this.AC.checkArmors(userid);
        }
    }
}
