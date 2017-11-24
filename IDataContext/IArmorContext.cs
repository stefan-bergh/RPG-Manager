using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataContext
{
    using RPGManager.Domain.Models;

    public interface IArmorContext
    {
        List<Armor> GetAllArmors(int userid);
        bool insertArmor(Armor armor);
        bool updateArmor(Armor armor);
        bool deleteArmor(Armor armor);
        bool checkArmors(int userid);
    }
}
