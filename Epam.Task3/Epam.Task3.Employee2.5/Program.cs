using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.Employee2._5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\tCreating a new Employee: ");
            Console.WriteLine("\tEnter your name");
            string name = Console.ReadLine();
            Console.WriteLine("\tEnter your patronymic");
            string patronymic = Console.ReadLine();
            Console.WriteLine("\tEnter your surname");
            string surname = Console.ReadLine();
            Console.WriteLine("\tEnter your birthday. Example : 01.01.2000 - Day.Month.Year");
            string birthday = Console.ReadLine();
            Console.WriteLine("\tEnter your position");
            string position = Console.ReadLine();
            Console.WriteLine("\tEnter your employmentDate. Example : 01.01.2000 - Day.Month.Year");
            string employmentDate = Console.ReadLine();

            Employee employee1 = new Employee(name, patronymic, surname, birthday, position, employmentDate);
            Console.WriteLine(employee1);
        }
    }
}
