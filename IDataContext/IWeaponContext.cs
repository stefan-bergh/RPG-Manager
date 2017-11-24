using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataContext
{
    using RPGManager.Domain.Models;

    public interface IWeaponContext
    {
        List<Weapon> GetAllWeapons(int userid);
        bool insertWeapon(Weapon weapon);
        bool updateWeapon(Weapon weapon);
        bool deleteWeapon(Weapon weapon);
        bool checkWeapons(int userid);
    }
}
