using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
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
    }
}
