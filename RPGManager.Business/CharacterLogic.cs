using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.Domain.Models;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class CharacterLogic : ICharacterLogic
    {
        public ICharacterRepository CR;

        public CharacterLogic(ICharacterRepository Repo)
        {
            CR = Repo;
        }

        public List<Character> GetAllCharacters(int userid)
        {
            return CR.GetAllCharacters(userid);
        }

        public bool insertCharacter(Character character)
        {
            return CR.insertCharacter(character);
        }

        public bool updateCharacter(Character character)
        {
            return CR.updateCharacter(character);
        }

        public bool deleteCharacter(Character character)
        {
            return CR.deleteCharacter(character);
        }

        public bool checkCharacters(int userid)
        {
            return CR.checkCharacters(userid);
        }
    }
}
