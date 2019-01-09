using System;
using System.Configuration;
using Epam.Task7.BLL;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL;
using Epam.Task7.DAL.Interface;

namespace Epam.Task7.Common
{
    public class DependencyResolver
    {
        private static IUserDao userDao;
        private static ICacheLogic cacheLogic;
        private static IUserLogic userLogic;
        private static IAwardDao awardDao;
        private static IAwardLogic awardLogic;

        public static IUserDao UserDao
        {
            get
            {
                var key = ConfigurationManager.AppSettings["DaoUserKey"];

                if (userDao == null)
                {
                    switch (key.ToLower())
                    {
                        case "memory":
                            {
                                return userDao = new UserFakeDao();
                            }

                        case "binfile":
                            {
                                return userDao = new UserBinDao();
                            }

                        default:
                            throw new ArgumentException("Cant configurate UserDao");
                    }
                }

                return userDao;
            }
        }

        public static ICacheLogic CacheLogic => cacheLogic ?? (cacheLogic = new CacheLogic());

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao, CacheLogic, AwardLogic));

        public static IAwardDao AwardDao => awardDao ?? (awardDao = new AwardBinDao());

        public static IAwardLogic AwardLogic => awardLogic ?? (awardLogic = new AwardLogic(AwardDao, CacheLogic));
    }
}