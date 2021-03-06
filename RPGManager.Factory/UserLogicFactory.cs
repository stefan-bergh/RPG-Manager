﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using RPGManager.ILogic;
using RPGManager.Business;
using RPGManager.Data.SQL;

namespace RPGManager.Factory
{
    public class UserLogicFactory
    {
        public static IUserLogic getUserSQLContext()
        {
            return new UserLogic(new UserRepository(new UserSQLContext()));
        }


    }
}
