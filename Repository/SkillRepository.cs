﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;

namespace Repository
{
    public class SkillRepository : ISkillRepository
    {
        private ISkillContext SC;

        public SkillRepository(ISkillContext context)
        {
            SC = context;
        }
    }
}
