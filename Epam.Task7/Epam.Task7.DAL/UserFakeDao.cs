using Epam.Task7.Entities;
using Epam.Task7.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.DAL
{
    public class UserFakeDao : IUserDao
    {
        private static Dictionary<int, User> _repoUsers = new Dictionary<int, User>();

        public void Add(User user)
        {
            int lastId = _repoUsers.Any() ? _repoUsers.Keys.Max() : 0;
            user.Id = ++lastId;

            _repoUsers.Add(user.Id, user);
        }

        public void Delete(int id)
        {
            _repoUsers.Remove(id);
        }

        public User Get(int id)
        {
            if (_repoUsers.TryGetValue(id, out var user))
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _repoUsers.Values;
        }
    }
}
