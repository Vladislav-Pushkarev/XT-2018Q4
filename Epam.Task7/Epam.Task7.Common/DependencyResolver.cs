using Epam.Task7.BLL;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL;
using Epam.Task7.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Common
{
    public class DependencyResolver
    {
        private static IUserDao _userDao;

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (_userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                return _userDao = new UserFakeDao();
                            }
                        case "txtfile":
                            {
                                return _userDao = new UserFakeDao(); // поменять
                            }
                        default:
                            throw new ArgumentException("Cant configurate UserDao");
                    }
                }
                return _userDao;

            }
        }

        private static ICacheLogic _cacheLogic;

        public static ICacheLogic CacheLogic => _cacheLogic ?? (_cacheLogic = new CacheLogic());

        private static IUserLogic _userLogic;

        public static IUserLogic UserLogic => _userLogic ?? (_userLogic = new UserLogic(UserDao, CacheLogic));



    }
}
