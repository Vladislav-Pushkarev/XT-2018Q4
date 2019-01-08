using Epam.Task7.Entities;
using Epam.Task7.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Task7.DAL.Interface;
using Epam.Task7.BLL.Interface;

namespace Epam.Task7.BLL
{
    public class UserLogic : IUserLogic
    {
        private const string ALL_USERS_CACHE_KEY = "GetAllUsers";
        private readonly IUserDao _userDao;
        private readonly ICacheLogic _cacheLogic;

        private static int AgeSet(DateTime date)
        {
            DateTime now = DateTime.Now;

            int a = (((now.Year * 100) + now.Month) * 100) + now.Day;
            int b = (((date.Year * 100) + date.Month) * 100) + date.Day;

            int age = (a - b) / 10000;

            return age;
        }

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic)
        {
            _userDao = userDao;
            _cacheLogic = cacheLogic;
        }

        public void Add(User user)
        {
            int age = AgeSet(user.DateOfBirth);
            user.Age = age;
            _userDao.Add(user);
            _cacheLogic.Delete(ALL_USERS_CACHE_KEY);
        }

        public void Delete(int id)
        {
            _userDao.Delete(id);
            string key = id.ToString();
            _cacheLogic.Delete(key);
        }

        public User Get(int id)
        {
            string key = id.ToString();
            User result = _cacheLogic.Get<User>(key);
            if (result == null)
            {
                result = _userDao.Get(id);
                _cacheLogic.Add(key, result);
                Console.WriteLine("Dao");
                return result;
            }
            Console.WriteLine("Cache");
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable <User> result = _cacheLogic.Get<IEnumerable<User>>(ALL_USERS_CACHE_KEY);
            if (result == null)
            {
                result = _userDao.GetAll();
                _cacheLogic.Add(ALL_USERS_CACHE_KEY, result);
                Console.WriteLine("Dao");
                return result;
            }
            Console.WriteLine("Cache");
            return result;
        }
    }
}
