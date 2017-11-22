using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGManager.Domain.Models;

namespace IRepository
{
    public interface ICharacterRepository
    {
        List<Character> GetAllCharacters(int userid);
        bool insertCharacter(Character character);
        bool updateCharacter(Character character);
        bool deleteCharacter(Character character);

        bool checkCharacters(int userid);
    }
}
