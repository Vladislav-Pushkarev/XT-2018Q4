using Epam.Task7.BLL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.BLL
{
    public class CacheLogic : ICacheLogic
    {
        private readonly Dictionary<string, object> _data = new Dictionary<string, object>();

        public bool Add<T>(string Key, T value)
        {
            if (_data.ContainsKey(Key))
            {
                return false;
            }

            _data.Add(Key, value);
            return true;
        }

        public T Get<T>(string Key)
        {
            if (!_data.ContainsKey(Key))
            {
                return default(T);
            }

            return (T)_data[Key];
        }

        public bool Delete(string Key)
        {
            return _data.Remove(Key);
        }
    }
}
