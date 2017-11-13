using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGManager.Domain.Models;

namespace IRepository
{
    public interface IUserRepository
    {
        bool checkUser(string name, string pass);
        User getUser(string name, string pass);
    }
}
