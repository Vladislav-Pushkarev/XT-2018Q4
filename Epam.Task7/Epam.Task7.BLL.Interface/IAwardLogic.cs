using System.Collections.Generic;
using Epam.Task7.Entities;

namespace Epam.Task7.BLL.Interface
{
    public interface IAwardLogic
    {
        void Add(Award award);

        bool Delete(int id);

        Award Get(int id);

        IEnumerable<Award> GetAll();
    }
}
