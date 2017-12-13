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

    public class ItemSQLContext : IItemContext
    {
        databaseCommands dbC = new databaseCommands();

        public List<Item> GetAllItems(int userid)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT * FROM Equipment RIGHT JOIN Item ON Equipment.EquipmentID = Item.EquipmentID WHERE [UserAccountID] = '{0}'", userid));

            List<Item> items = new List<Item>();
            foreach (DataRow row in dt.Rows)
            {
                items.Add(new Item()
                {
                    AccountId = (int)row["UserAccountID"],
                    EquipmentId = (int)row["EquipmentID"],
                    EquipmentType = (EquipmentTypes)row["Type"],
                    Name = row["Name"].ToString(),
                    Price = float.Parse(row["Price"].ToString()),
                    Effect = row["Effect"].ToString(),
                    ItemId = (int)row["ItemID"],
                    Repeat = (int)row["Repeat"]
                });
            }
            return items;
        }

        public bool insertItem(Item item)
        {
            try
            {
                int equipmentID = this.dbC.InsertEquipment(item.AccountId, item.Name, item.Price, Convert.ToInt32(item.EquipmentType));
                dbC.RunQuery(string.Format(
                    "INSERT INTO [Dbo].[Item] (EquipmentID, Effect, Repeat) VALUES ('{0}', '{1}', '{2}');",
                    equipmentID, item.Effect, item.Repeat));
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool updateItem(Item item)
        {
            dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Equipment] SET [Name] = '{1}', Price = '{2}', [Type] = '{3}' WHERE [EquipmentID] = '{0}'",
                item.EquipmentId, item.Name, item.Price, Convert.ToInt32(item.EquipmentType)));
            dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Item] SET Effect = '{1}', Repeat = '{2}' WHERE [EquipmentID] = '{0}'",
                item.EquipmentId, item.Effect, item.Repeat));
            return true;
        }

        public bool deleteItem(Item item)
        {
            dbC.RunQuery(string.Format("DELETE FROM [Dbo].[Item] WHERE [EquipmentID] = '{0}'", item.EquipmentId));
            dbC.RunQuery(string.Format("DELETE FROM [Dbo].[Equipment] WHERE [EquipmentID] = '{0}'", item.EquipmentId));
            return true;
        }

        public bool checkItems(int userid)
        {
            return dbC.checkQuery(
                string.Format(
                    "SELECT * FROM Equipment RIGHT JOIN Item ON Equipment.EquipmentID = Item.EquipmentID WHERE [UserAccountID] = '{0}'",
                    userid));
        }
    }
}
