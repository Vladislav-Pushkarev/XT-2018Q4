using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Employee2._5
{
    public class User
    {
        private static int id;
        private string name;
        private string patronymic;
        private string surname;
        private int age;
        private DateTime birthday;

        public User(string name, string patronymic, string surname, string birthday)
        {
            this.Name = name;
            this.Patronymic = patronymic;
            this.Surname = surname;
            this.Birthday = DateTime.Parse(birthday);
            this.age = AgeSet(this.birthday);
            id++;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (FullNameCheck(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value. Only letters and dashes are allowed.");
                }
            }
        }

        public string Patronymic
        {
            get
            {
                return this.patronymic;
            }

            set
            {
                if (FullNameCheck(value))
                {
                    this.patronymic = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value. Only letters and dashes are allowed.");
                }
            }
        }

        public string Surname
        {
            get
            {
                return this.surname;
            }

            set
            {
                if (FullNameCheck(value))
                {
                    this.surname = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value. Only letters and dashes are allowed.");
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this.birthday;
            }

            set
            {
                if (DateCheck(value))
                {
                    this.birthday = value;
                }
                else
                {
                    throw new ArgumentException("Are you from the future or you just misprint in your birth date?");
                }
            }
        }

        public int Age { get; }

        public int Id { get; }


        public override string ToString()
        {
            return string.Format("User Id - {0} " + Environment.NewLine + "{1}   {2}   {3} " + Environment.NewLine + "Age - {4}, Birthday - {5}", id, this.name, this.patronymic, this.surname, this.age, this.birthday);
        }

        protected static int AgeSet(DateTime date)
        {
            DateTime now = DateTime.Now;

            int a = (((now.Year * 100) + now.Month) * 100) + now.Day;
            int b = (((date.Year * 100) + date.Month) * 100) + date.Day;

            int age = (a - b) / 10000;

            return age;
        }

        protected static bool FullNameCheck(string name)
        {
            if (!string.IsNullOrEmpty(name) && name.Length > 1)
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!char.IsLetter(name[i]) || name[i] == '-')
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        private static bool DateCheck(DateTime date)
        {
            DateTime now = DateTime.Now;

            if (date > now)
            {
                return false;
            }

            return true;
        }
    }
}
