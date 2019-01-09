using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class UserBinDao : IUserDao
    {
        private static readonly string EXTENSION = ".bin";
        private static readonly string DEFAULTPATH = Directory.GetCurrentDirectory();
        private static readonly string PATH = "UserDao";
        private static Dictionary<int, string> usersId = new Dictionary<int, string>();

        public UserBinDao()
        {
            Directory.CreateDirectory(Path.Combine(DEFAULTPATH, PATH));
        }

        public void Add(User user)
        {
            int lastId = usersId.Any() ? usersId.Keys.Max() : 0;
            user.Id = ++lastId;

            StringBuilder name = new StringBuilder();
            name.Append(user.Id);
            name.Append(EXTENSION);
            string fullPath = Path.Combine(DEFAULTPATH, PATH, name.ToString());

            usersId.Add(user.Id, fullPath);

            File.Create(fullPath).Close();
        
            using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            {
                new BinaryFormatter().Serialize(fs, user);
            }
        }

        public void Update(User user)
        {
            StringBuilder name = new StringBuilder();
            name.Append(user.Id);
            name.Append(EXTENSION);
            string fullPath = Path.Combine(DEFAULTPATH, PATH, name.ToString());

            File.Create(fullPath).Close();

            using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            {
                new BinaryFormatter().Serialize(fs, user);
            }
        }

        public bool Delete(int id)
        {
            if (usersId.ContainsKey(id))
            {
                File.Delete(usersId[id]);
            }

            return usersId.Remove(id);
        }

        public User Get(int id)
        {
            if (usersId.ContainsKey(id))
            {
                using (FileStream fs = new FileStream(usersId[id], FileMode.Open))
                {
                    User user = (User)new BinaryFormatter().Deserialize(fs);
                    return user;
                }
            }

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> userList = new List<User>();
            foreach (var pair in usersId)
            {
                using (FileStream fs = new FileStream(pair.Value, FileMode.Open))
                {
                    User user = (User)new BinaryFormatter().Deserialize(fs);
                    userList.Add(user);
                }
            }

            return userList;
        }
    }
}
