using System.Collections.Generic;
using System.Linq;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class UserFakeDao : IUserDao
    {
        private static Dictionary<int, User> repoUsers = new Dictionary<int, User>();

        public void Add(User user)
        {
            int lastId = repoUsers.Any() ? repoUsers.Keys.Max() : 0;
            user.Id = ++lastId;

            repoUsers.Add(user.Id, user);
        }

        public void Update(User user)
        {
            repoUsers[user.Id] = user;
        }

        public bool Delete(int id)
        {
            return repoUsers.Remove(id);
        }

        public User Get(int id)
        {
            if (repoUsers.TryGetValue(id, out var user))
            {
                return user;
            }

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return repoUsers.Values;
        }
    }
}
