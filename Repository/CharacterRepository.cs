using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    public class CharacterRepository : ICharacterRepository
    {
        private ICharacterContext CC;

        public CharacterRepository(ICharacterContext context)
        {
            CC = context;
        }
    }
}
