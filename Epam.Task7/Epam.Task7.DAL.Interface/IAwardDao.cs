using System.Collections.Generic;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL.Interface
{
    public interface IAwardDao
    {
        void Add(Award award);

        bool Delete(int id);

        Award Get(int id);

        IEnumerable<Award> GetAll();
    }
}
