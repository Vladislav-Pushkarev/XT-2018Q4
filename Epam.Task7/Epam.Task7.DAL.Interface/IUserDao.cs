﻿using Epam.Task7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);

        void Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();
    }
}
