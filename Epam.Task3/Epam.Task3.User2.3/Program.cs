using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.User2._3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\tCreating a new User: ");
            Console.WriteLine("\tEnter your name");
            string name = Console.ReadLine();
            Console.WriteLine("\tEnter your patronymic");
            string patronymic = Console.ReadLine();
            Console.WriteLine("\tEnter your surname");
            string surname = Console.ReadLine();
            Console.WriteLine("\tEnter your birthday. Example : 01.01.2000 - Day.Month.Year");
            string birthday = Console.ReadLine();

            User user1 = new User(name, patronymic, surname, birthday);
            Console.WriteLine(user1);
        }
    }
}
