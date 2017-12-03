using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;

namespace RPGManager.Data.SQL
{
    using System.Data;

    using RPGManager.Domain.Enums;
    using RPGManager.Domain.Models;

    public class ArmorSQLContext : IArmorContext
    {
        databaseCommands dbC = new databaseCommands();

        public List<Armor> GetAllArmors(int userid)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT Equipment.*, Armor.ArmorID, Armor.ArmorType, Armor.Defense FROM Equipment RIGHT JOIN Armor ON Equipment.EquipmentID = Armor.EquipmentID WHERE [UserAccountID] = '{0}'", userid));

            List<Armor> armors = new List<Armor>();
            foreach (DataRow row in dt.Rows)
            {
                armors.Add(new Armor()
                               {
                                   AccountId = (int)row["UserAccountID"],
                                   ArmorId = (int)row["ArmorID"],
                                   ArmorType = (ArmorTypes)row["ArmorType"],
                                   Defense = (int)row["Defense"],
                                   EquipmentId = (int)row["EquipmentID"],
                                   EquipmentType = (EquipmentTypes)row["Type"],
                                   Name = row["Name"].ToString(),
                                   Price = float.Parse(row["Price"].ToString())
                               });
            }
            return armors;
        }

        public bool insertArmor(Armor armor)
        {
            try
            {
                int equipmentID = this.dbC.InsertEquipment(armor.AccountId, armor.Name, armor.Price, Convert.ToInt32(armor.EquipmentType));
                dbC.RunQuery(string.Format(
                    "INSERT INTO [Dbo].[Armor] (EquipmentID, Defense, ArmorType) VALUES ('{0}', '{1}', '{2}');",
                    equipmentID, armor.Defense, Convert.ToInt32(armor.ArmorType)));
                return true;
            }
            catch
            {
                return false;
            }
        }
    

        public bool updateArmor(Armor armor)
        {
            dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Equipment] SET [Name] = '{1}', Price = '{2}', [Type] = '{3}' WHERE [EquipmentID] = '{0}'",
                armor.EquipmentId, armor.Name, armor.Price, Convert.ToInt32(armor.EquipmentType)));
            dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Armor] SET Defense = '{1}', ArmorType = '{2}' WHERE [EquipmentID] = '{0}'",
                armor.EquipmentId, armor.Defense, Convert.ToInt32(armor.ArmorType)));
            return true;
        }

        public bool deleteArmor(Armor armor)
        {
            dbC.RunQuery(string.Format("DELETE FROM [Dbo].[Armor] WHERE [EquipmentID] = '{0}'", armor.EquipmentId));
            dbC.RunQuery(string.Format("DELETE FROM [Dbo].[Equipment] WHERE [EquipmentID] = '{0}'", armor.EquipmentId));
            return true;
        }

        public bool checkArmors(int userid)
        {
            return dbC.checkQuery(
                string.Format(
                    "SELECT * FROM Equipment RIGHT JOIN Armor ON Equipment.EquipmentID = Armor.EquipmentID WHERE[UserAccountID] = '{0}'",
                    userid));
        }
    }
}
