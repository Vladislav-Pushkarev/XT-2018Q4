using Epam.Task7.BLL;
using Epam.Task7.BLL.Interface;
using Epam.Task7.Common;
using Epam.Task7.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task7.PL.Console
{
    class Program
    {
        private static IUserLogic userLogic = DependencyResolver.UserLogic;
        private static readonly string GREETING = $"================\t Simple console CRUD applicatoin \t================" +
            $"{Environment.NewLine}" +
            $"\t\t\t\tControl commands: " +
            $"{Environment.NewLine}" +
            $"****   create     - Create user and set name, age, date of birth.  \t****" +
            $"{Environment.NewLine}****{Environment.NewLine}" +
            $"****   create def - Create default user.                           \t****" +
            $"{Environment.NewLine}****{Environment.NewLine}" +
            $"****   delete     - Delete user by ID.                             \t****" +
            $"{Environment.NewLine}****{Environment.NewLine}" +
            $"****   list       - Display the list of users.                     \t****" +
            $"{Environment.NewLine}****{Environment.NewLine}" +
            $"****   get        - Get and show user info by ID.                  \t****" +
            $"{Environment.NewLine}****{Environment.NewLine}" +
            $"****   exit       - Quit application.                              \t****";
    
        private static void CreateUser()
        {
            System.Console.WriteLine("\tEnter name. ****   leave blank line if you want default name");
            string name = System.Console.ReadLine();

            System.Console.WriteLine("\tEnter date of birth. Example : 20.12.2000 - Day.Month.Year");
            DateTime date = DateTime.Parse(System.Console.ReadLine());
            while (!DateValid(date))
            {
                System.Console.WriteLine("Invalid date of birth. User has not yet been born, try again.");
                date = DateTime.Parse(System.Console.ReadLine());
            }
            User user = new User();
            user.Name = name;
            user.DateOfBirth = date;
            userLogic.Add(user);
        }

        private static void CreateDefaultUser()
        {
            User user = new User
            {
                Name = "DefaultName",
                DateOfBirth = DateTime.Parse("20.12.2000"),
            };
            userLogic.Add(user);
        }

        private static bool DateValid(DateTime date)
        {
            DateTime now = DateTime.Now;

            if (date > now)
            {
                return false;
            }

            return true;
        }

        private static void DeleteUser()
        {
            System.Console.WriteLine("Enter user id");

            bool correctId = int.TryParse(System.Console.ReadLine(), out int id);
            while (!correctId)
            {
                System.Console.WriteLine("Incorrect value, try again.");
                correctId = int.TryParse(System.Console.ReadLine(), out id);
            }

            userLogic.Delete(id);
        }

        private static void GetUser()
        {
            System.Console.WriteLine("Enter user id");

            bool correctId = int.TryParse(System.Console.ReadLine(), out int id);
            while (!correctId)
            {
                System.Console.WriteLine("Incorrect value, try again.");
                correctId = int.TryParse(System.Console.ReadLine(), out id);
            }

            System.Console.WriteLine(userLogic.Get(id));
        }

        public static void ShowUsers(IUserLogic userLogic)
        {
            System.Console.WriteLine($"Id, Name, Age, Date Of Birth");
            foreach (User user in userLogic.GetAll())
            {
                System.Console.WriteLine(user);
            }
        }

        public static void Menu()
        {
            System.Console.WriteLine("Waiting for a command...");
            string command = System.Console.ReadLine().ToLower();
            switch (command)
            {
                case "create":
                    {
                        CreateUser();
                        Menu();
                        break;
                    }
                case "create def":
                    {
                        CreateDefaultUser();
                        Menu();
                        break;
                    }
                case "delete":
                    {
                        DeleteUser();
                        Menu();
                        break;
                    }
                case "get":
                    {
                        GetUser();
                        Menu();
                        break;
                    }
                case "list":
                    {
                        System.Console.WriteLine(userLogic.GetAll());
                        Menu();
                        break;
                    }
                case "exit":
                    break;
                default: 
                    {
                        System.Console.WriteLine("Invalid command! Try again");
                        Menu();
                        break;
                    }
            }
        }


        static void Main(string[] args)
        {
            System.Console.WriteLine(GREETING);
            Menu();
        }
    }
}
