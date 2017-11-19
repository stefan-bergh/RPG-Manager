﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGManager.Domain.Models;

namespace IDataContext
{
    public interface IClassContext
    {
        List<Class> GetAllClasses(int userid);
        bool insertClass(Class cClass);
        bool updateClass(Class cClass);
        bool deleteClass(Class cClass);
        bool checkClasses(int userid);
    }
}
