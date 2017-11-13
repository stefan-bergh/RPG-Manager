using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGManager.Domain.Models;

namespace IDataContext
{
    public interface IUserContext
    {
        bool checkUser(string name, string pass);
        User getUser(string name, string pass);
    }
}
