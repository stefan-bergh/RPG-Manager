using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGManager.Domain.Models;

namespace RPGManager.ILogic
{
    public interface IUserLogic
    {
        bool checkAccountDetails(string name, string pass);
        User getUser(string tbUserText, string tbPassPassword);
    }
}
