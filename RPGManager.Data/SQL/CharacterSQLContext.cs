using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using RPGManager.Data.SQL;
using RPGManager.Domain.Models;

namespace RPGManager.Data
{
    public class CharacterSQLContext : ICharacterContext
    {
        databaseCommands dbC = new databaseCommands();
        public List<Character> GetAllCharacters(int userid)
        {
            DataTable dt =
                dbC.getTable(string.Format(
                    "SELECT * FROM [Dbo].[Character] WHERE [UserAccountID] = '{0}'", userid));

            List<Character> characters = new List<Character>();
            foreach (DataRow row in dt.Rows)
            {
                characters.Add(new Character((int)row["CharacterID"], (int)row["UserAccountID"], row["Name"].ToString(), (int)row["StartingLevel"], (int)row["ClassID"]));
            }
            return characters;
        }

        public bool insertCharacter(Character character)
        {
            return dbC.RunQuery(string.Format(
                "INSERT INTO [Dbo].[Character] (UserAccountID, Name, StartingLevel, ClassID) VALUES ('{0}', '{1}', '{2}', {3});",
                character.AccountId, character.Name, character.StartingLevel, character.ClassId));
        }

        public bool updateCharacter(Character character)
        {
            return dbC.RunQuery(string.Format(
                "UPDATE [Dbo].[Character] SET [Name] = '{1}', [StartingLevel] = '{2}', [ClassID] = '{3}' WHERE [CharacterID] = '{0}'",
                character.Id, character.Name, character.StartingLevel, character.ClassId));
        }

        public bool deleteCharacter(Character character)
        {
            return dbC.RunQuery(string.Format(
                "DELETE FROM [Dbo].[Character] WHERE [CharacterID] = '{0}'",
                character.Id));
        }

        public bool checkCharacters(int userid)
        {
            return dbC.checkQuery(string.Format(
                "SELECT * FROM [Dbo].[Character] WHERE [UserAccountID] = '{0}'",
                userid));
        }
    }
}
