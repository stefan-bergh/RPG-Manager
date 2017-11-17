using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    public class ClassRepository : IClassRepository
    {
        private IClassContext CC;

        public ClassRepository(IClassContext context)
        {
            CC = context;
        }
    }
}
