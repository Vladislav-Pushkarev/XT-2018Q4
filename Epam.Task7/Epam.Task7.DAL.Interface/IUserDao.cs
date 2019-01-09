using System.Collections.Generic;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.Interface
{
    public interface IUserDao
    {
        void Add(User user);

        void Update(User user);

        bool Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();
    }
}
