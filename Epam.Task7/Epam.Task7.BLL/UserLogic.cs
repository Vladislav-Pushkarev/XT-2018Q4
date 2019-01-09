﻿using System.Collections.Generic;
using System.Text;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL
{
    public class UserLogic : IUserLogic
    {
        private const string ALLUSERSCACHEKEY = "GetAllUsers";
        private readonly IUserDao userDao;
        private readonly ICacheLogic cacheLogic;
        private readonly IAwardLogic awardLogic;

        public UserLogic(IUserDao userDao, ICacheLogic cacheLogic, IAwardLogic awardLogic)
        {
            this.userDao = userDao;
            this.cacheLogic = cacheLogic;
            this.awardLogic = awardLogic;
        }

        public void Add(User user)
        {
            this.userDao.Add(user);
            this.cacheLogic.Delete(ALLUSERSCACHEKEY);
        }

        public bool AddAward(int userId, int awardId)
        {
            User user = this.Get(userId);
            Award award = this.awardLogic.Get(awardId);
            if (this.awardLogic.Get(awardId) != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(user.Awards);
                sb.Append('|');
                sb.Append(award);
                user.Awards = sb.ToString();
                this.userDao.Update(user);
                this.cacheLogic.Delete(ALLUSERSCACHEKEY);
                string key = "user" + userId;
                this.cacheLogic.Delete(key);
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            string key = "user" + id;
            this.cacheLogic.Delete(key);
            return this.userDao.Delete(id);
        }

        public User Get(int id)
        {
            string key = "user" + id;
            User result = this.cacheLogic.Get<User>(key);
            if (result == null)
            {
                result = this.userDao.Get(id);
                this.cacheLogic.Add(key, result);
                return result;
            }

            return result;
        }

        public IEnumerable<User> GetAll()
        {
            IEnumerable<User> result = this.cacheLogic.Get<IEnumerable<User>>(ALLUSERSCACHEKEY);
            if (result == null)
            {
                result = this.userDao.GetAll();
                this.cacheLogic.Add(ALLUSERSCACHEKEY, result);
                return result;
            }

            return result;
        }
    }
}