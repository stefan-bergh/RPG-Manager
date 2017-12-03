using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;
using RPGManager.Domain.Models;

namespace RPGManager.Business
{

    public class WeaponLogic : IWeaponLogic
    {
        public IWeaponRepository WR;

        public WeaponLogic(IWeaponRepository Repo)
        {
            WR = Repo;
        }

        public List<Weapon> GetAllWeapons(int userid)
        {
            return this.WR.GetAllWeapons(userid);
        }

        public bool insertWeapon(Weapon weapon)
        {
            return this.WR.insertWeapon(weapon);
        }

        public bool updateWeapon(Weapon weapon)
        {
            return this.WR.updateWeapon(weapon);
        }

        public bool deleteWeapon(Weapon weapon)
        {
            return this.WR.deleteWeapon(weapon);
        }

        public bool checkWeapons(int userid)
        {
            return this.WR.checkWeapons(userid);
        }
    }
}
