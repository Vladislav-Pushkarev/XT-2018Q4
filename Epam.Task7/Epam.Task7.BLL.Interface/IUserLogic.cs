using System.Collections.Generic;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL.Interface
{
    public interface IUserLogic
    {
        void Add(User user);

        bool AddAward(int userId, int awardId);

        bool Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();
    }
}
