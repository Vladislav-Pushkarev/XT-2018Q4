using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.Entities
{
    [Serializable]
    public class User
    {
        public string Awards { get; set; }

        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;

                int a = (((now.Year * 100) + now.Month) * 100) + now.Day;
                int b = (((this.DateOfBirth.Year * 100) + this.DateOfBirth.Month) * 100) + this.DateOfBirth.Day;

                int age = (a - b) / 10000;

                return age;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{this.Id}, {this.Name}, {this.Age}, {this.DateOfBirth.ToShortDateString()}" +
                $"{Environment.NewLine} " +
                $"{Awards}";
        }
    }
}
