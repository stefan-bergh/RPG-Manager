using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using RPGManager.Business;
using RPGManager.Data;
using RPGManager.ILogic;

namespace RPGManager.Factory
{
    class CharacterLogicFactory
    {
        public static ICharacterLogic getCharacterSQLContext()
        {
            return new CharacterLogic(new CharacterRepository(new CharacterSQLContext()));
        }
    }
}
