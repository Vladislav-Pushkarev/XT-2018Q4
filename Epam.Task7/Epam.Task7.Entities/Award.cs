using System;

namespace Epam.Task7.Entities
{
    [Serializable]
    public class Award
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{this.Id}, {this.Name}";
        }
    }
}
