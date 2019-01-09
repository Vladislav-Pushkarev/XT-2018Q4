using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Epam.Task7.DAL.Interface;
using Epam.Task7.Entities;

namespace Epam.Task7.DAL
{
    public class AwardBinDao : IAwardDao
    {
        private static readonly string EXTENSION = ".bin";
        private static readonly string DEFAULTPATH = Directory.GetCurrentDirectory();
        private static readonly string PATH = "AwardDao";
        private static Dictionary<int, string> awardsId = new Dictionary<int, string>();

        public AwardBinDao()
        {
            Directory.CreateDirectory(Path.Combine(DEFAULTPATH, PATH));
        }

        public void Add(Award award)
        {
            int lastId = awardsId.Any() ? awardsId.Keys.Max() : 0;
            award.Id = ++lastId;

            StringBuilder name = new StringBuilder();
            name.Append(award.Id);
            name.Append(EXTENSION);
            string fullPath = Path.Combine(DEFAULTPATH, PATH, name.ToString());

            awardsId.Add(award.Id, fullPath);

            File.Create(fullPath).Close();

            using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            {
                new BinaryFormatter().Serialize(fs, award);
            }
        }

        public bool Delete(int id)
        {
            if (awardsId.ContainsKey(id))
            {
                File.Delete(awardsId[id]);
            }

            return awardsId.Remove(id);
        }

        public Award Get(int id)
        {
            if (awardsId.ContainsKey(id))
            {
                using (FileStream fs = new FileStream(awardsId[id], FileMode.Open))
                {
                    Award award = (Award)new BinaryFormatter().Deserialize(fs);
                    return award;
                }
            }

            return null;
        }

        public IEnumerable<Award> GetAll()
        {
            List<Award> awardsList = new List<Award>();
            foreach (var pair in awardsId)
            {
                using (FileStream fs = new FileStream(pair.Value, FileMode.Open))
                {
                    Award award = (Award)new BinaryFormatter().Deserialize(fs);
                    awardsList.Add(award);
                }
            }

            return awardsList;
        }
    }
}
