using System.Collections.Generic;
using Epam.Task7.BLL.Interface;

namespace Epam.Task7.BLL
{
    public class CacheLogic : ICacheLogic
    {
        private readonly Dictionary<string, object> data = new Dictionary<string, object>();

        public bool Add<T>(string key, T value)
        {
            if (this.data.ContainsKey(key))
            {
                return false;
            }

            this.data.Add(key, value);
            return true;
        }

        public T Get<T>(string key)
        {
            if (!this.data.ContainsKey(key))
            {
                return default(T);
            }

            return (T)this.data[key];
        }

        public bool Delete(string key)
        {
            return this.data.Remove(key);
        }
    }
}
