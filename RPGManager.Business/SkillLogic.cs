﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class SkillLogic : ISkillLogic
    {
        public ISkillRepository SR;

        public SkillLogic(ISkillRepository Repo)
        {
            SR = Repo;
        }
    }
}
