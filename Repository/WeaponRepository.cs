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

    public class WeaponRepository : IWeaponRepository
    {
        private IWeaponContext WC;

        public WeaponRepository(IWeaponContext context)
        {
            WC = context;
        }

        public List<Weapon> GetAllWeapons(int userid)
        {
            this.WC.GetAllWeapons(userid);
        }

        public bool insertWeapon(Weapon weapon)
        {
            this.WC.insertWeapon(weapon);
        }

        public bool updateWeapon(Weapon weapon)
        {
            this.WC.updateWeapon(weapon);
        }

        public bool deleteWeapon(Weapon weapon)
        {
            this.WC.deleteWeapon(weapon);
        }

        public bool checkWeapons(int userid)
        {
            this.WC.checkWeapons(userid);
        }
    }
}
