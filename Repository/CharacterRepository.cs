using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;
using RPGManager.Domain.Models;

namespace Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private ICharacterContext CC;

        public CharacterRepository(ICharacterContext context)
        {
            CC = context;
        }

        public List<Character> GetAllCharacters(int userid)
        {
            return CC.GetAllCharacters(userid);
        }

        public bool insertCharacter(Character character)
        {
            return CC.insertCharacter(character);
        }

        public bool updateCharacter(Character character)
        {
            return CC.updateCharacter(character);
        }

        public bool deleteCharacter(Character character)
        {
            return CC.deleteCharacter(character);
        }

        public bool checkCharacters(int userid)
        {
            return CC.checkCharacters(userid);
        }
    }
}
