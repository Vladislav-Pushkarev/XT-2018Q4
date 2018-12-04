using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Employee2._5
{
    public class Employee : User
    {
        private int experience;
        private DateTime employmentDate;
        private string position;

        public Employee(string name, string patronymic, string surname, string birthday, string position, string employmentDate) : base(name, patronymic, surname, birthday)
        {
            this.Position = position;
            this.employmentDate = DateTime.Parse(employmentDate);
            this.experience = User.AgeSet(this.employmentDate);
        }

        public string Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (User.FullNameCheck(value))
                {
                    this.position = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value. Only letters and dashes are allowed.");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("User Id - {0} " + Environment.NewLine + "{1}   {2}   {3} " + Environment.NewLine + "Age - {4}, Birthday - {5}" + Environment.NewLine + "Position - {6}, Employment date - {7}, {8} - years experience", this.Id, this.Name, this.Patronymic, this.Surname, this.Age, this.Birthday, this.position, this.employmentDate, this.experience);
        }
    }
}
