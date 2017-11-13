using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using IRepository;
using RPGManager.Domain.Models;
using RPGManager.ILogic;

namespace RPGManager.Business
{
    public class UserLogic : IUserLogic
    {
        public IUserRepository UR;

        public UserLogic(IUserRepository userRepo)
        {
            UR = userRepo;
        }

        public bool checkAccountDetails(string name, string pass)
        {
            if (UR.checkUser(name, pass))
            {
                return true;
            }
            return false;
        }

        public User getUser(string name, string pass)
        {
            return UR.getUser(name, pass);
        }
    }
}
