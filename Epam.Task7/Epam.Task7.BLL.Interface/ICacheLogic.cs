using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.BLL.Interface
{
    public interface ICacheLogic
    {
        bool Add<T>(string Key, T value);

        T Get<T>(string Key);

        bool Delete(string Key);
    }
}
