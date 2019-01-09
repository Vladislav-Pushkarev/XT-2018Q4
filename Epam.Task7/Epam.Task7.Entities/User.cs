using System;
using System.Collections.Generic;

namespace Epam.Task7.Entities
{
    [Serializable]
    public class User
    {
        private HashSet<int> awards = new HashSet<int>();

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

        public HashSet<int> Awards { get => this.awards; set => this.awards = value; }

        public override string ToString()
        {
            return $"{this.Id}, {this.Name}, {this.Age}, {this.DateOfBirth.ToShortDateString()}" +
                $"{Environment.NewLine} ";
        }
    }
}
