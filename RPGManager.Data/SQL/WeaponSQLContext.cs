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

    public class WeaponSQLContext : IWeaponContext
    {
        databaseCommands dbC = new databaseCommands();

        public List<Weapon> GetAllWeapons(int userid)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT * FROM Equipment RIGHT JOIN Weapon ON Equipment.EquipmentID = Weapon.EquipmentID WHERE [UserAccountID] = '{0}'", userid));

            List<Weapon> weapons = new List<Weapon>();
            foreach (DataRow row in dt.Rows)
            {
                weapons.Add(new Weapon()
                {
                    AccountId = (int)row["UserAccountID"],
                    WeaponId = (int)row["WeaponID"],
                    Damage = (int)row["Damage"],
                    EquipmentId = (int)row["EquipmentID"],
                    EquipmentType = (EquipmentTypes)row["Type"],
                    Name = row["Name"].ToString(),
                    Price = (float)row["Price"]
                });
            }
            return weapons;
        }

        public bool insertWeapon(Weapon weapon)
        {
            try
            {
                int equipmentID = this.dbC.InsertEquipment(weapon.AccountId, weapon.Name, weapon.Price, Convert.ToInt32(weapon.EquipmentType));
                dbC.RunQuery(string.Format(
                    "INSERT INTO [Dbo].[Weapon] (EquipmentID, Damage) VALUES ('{0}', '{1}');",
                    equipmentID, weapon.Damage));
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool updateWeapon(Weapon weapon)
        {
            dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Equipment] SET [Name] = '{1}', Price = '{2}', [Type] = '{3}' WHERE [EquipmentID] = '{0}'",
                weapon.EquipmentId, weapon.Name, weapon.Price, Convert.ToInt32(weapon.EquipmentType)));
            dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Weapon] SET Damage = '{1}' WHERE [EquipmentID] = '{0}'",
                weapon.EquipmentId, weapon.Damage));
            return true;
        }

        public bool deleteWeapon(Weapon weapon)
        {
            dbC.RunQuery(string.Format("DELETE FROM [Dbo].[Weapon] WHERE [EquipmentID] = '{0}'", weapon.EquipmentId));
            dbC.RunQuery(string.Format("DELETE FROM [Dbo].[Equipment] WHERE [EquipmentID] = '{0}'", weapon.EquipmentId));
            return true;
        }

        public bool checkWeapons(int userid)
        {
            return dbC.checkQuery(
                string.Format(
                    "SELECT * FROM Equipment RIGHT JOIN Weapon ON Equipment.EquipmentID = Weapon.EquipmentID WHERE [UserAccountID] = '{0}'",
                    userid));
        }
    }
}
