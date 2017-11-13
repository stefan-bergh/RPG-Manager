using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataContext;
using IRepository;
using RPGManager.Domain.Models;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private IUserContext UC;

        public UserRepository(IUserContext context)
        {
            UC = context;
        }

        public bool checkUser(string name, string pass)
        {
            if (UC.checkUser(name, pass))
            {
                return true;
            }
            return false;
        }

        public User getUser(string name, string pass)
        {
            return UC.getUser(name, pass);
        }
    }
}
