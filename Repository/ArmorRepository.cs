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
            return this.AC.GetAllArmors(userid);
        }

        public bool insertArmor(Armor armor)
        {
            return this.AC.insertArmor(armor);
        }

        public bool updateArmor(Armor armor)
        {
            return this.AC.updateArmor(armor);
        }

        public bool deleteArmor(Armor armor)
        {
            return this.AC.deleteArmor(armor);
        }

        public bool checkArmors(int userid)
        {
            return this.AC.checkArmors(userid);
        }
    }
}
