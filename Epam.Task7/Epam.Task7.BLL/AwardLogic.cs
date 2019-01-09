using System.Collections.Generic;
using Epam.Task7.BLL.Interface;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private const string ALLAWARDSCACHEKEY = "GetAllAwards";
        private readonly IAwardDao awardDao;
        private readonly ICacheLogic cacheLogic;

        public AwardLogic(IAwardDao awardDao, ICacheLogic cacheLogic)
        {
            this.awardDao = awardDao;
            this.cacheLogic = cacheLogic;
        }

        public void Add(Award award)
        {
            this.awardDao.Add(award);
            this.cacheLogic.Delete(ALLAWARDSCACHEKEY);
        }

        public bool Delete(int id)
        {
            string key = "award" + id;
            this.cacheLogic.Delete(key);
            return this.awardDao.Delete(id);
        }

        public Award Get(int id)
        {
            string key = "award" + id;
            Award result = this.cacheLogic.Get<Award>(key);
            if (result == null)
            {
                result = this.awardDao.Get(id);
                this.cacheLogic.Add(key, result);
                return result;
            }

            return result;
        }

        public IEnumerable<Award> GetAll()
        {
            IEnumerable<Award> result = this.cacheLogic.Get<IEnumerable<Award>>(ALLAWARDSCACHEKEY);
            if (result == null)
            {
                result = this.awardDao.GetAll();
                this.cacheLogic.Add(ALLAWARDSCACHEKEY, result);
                return result;
            }

            return result;
        }
    }
}
