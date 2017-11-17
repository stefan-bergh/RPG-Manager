using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class ClassLogic : IClassLogic
    {
        public IClassRepository CR;

        public ClassLogic(IClassRepository classRepo)
        {
            CR = classRepo;
        }
    }
}
