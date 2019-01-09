using System;
using System.Text;
using Epam.Task7.BLL.Interface;
using Epam.Task7.Common;
using Epam.Task7.Entities;

namespace Epam.Task7.PL.Console
{
    public class Program
    {
        private static readonly string GREETING = $"================\t Simple console CRUD applicatoin \t================" +
            $"{Environment.NewLine}" +
            $"\t\t\t\tControl commands: " +
            $"{Environment.NewLine}" +
            $"***   create      - Create USER and set name, age, date of birth.  \t***" +
            $"{Environment.NewLine}***{Environment.NewLine}" +
            $"***   create def  - Create default USER.                           \t***" +
            $"{Environment.NewLine}***{Environment.NewLine}" +
            $"***   delete      - Delete USER by ID.                             \t***" +
            $"{Environment.NewLine}***{Environment.NewLine}" +
            $"***   list        - Display the list of USERS.                     \t***" +
            $"{Environment.NewLine}***{Environment.NewLine}" +
            $"***   get         - Get and show USER info by ID.                  \t***" +
            $"{Environment.NewLine}***{Environment.NewLine}" +
            $"###   createA     - Create AWARD and set name.                     \t###" +
            $"{Environment.NewLine}###{Environment.NewLine}" +
            $"###   deleteA     - Delete AWARD by ID.                            \t###" +
            $"{Environment.NewLine}###{Environment.NewLine}" +
            $"###   listA       - Display the list of AWARDS.                    \t###" +
            $"{Environment.NewLine}###{Environment.NewLine}" +
            $"###   getA        - Get and show AWARD info by ID.                 \t###" +
            $"{Environment.NewLine}###{Environment.NewLine}" +
            $"###   addA        - Add an AWARD to specified USER.                \t###" +
            $"{Environment.NewLine}---{Environment.NewLine}" +
            $"---   q           - QUIT application.                              \t---" +
            $"{Environment.NewLine}--------------------------------------------------------------------------------";

        private static IUserLogic userLogic = DependencyResolver.UserLogic;

        private static IAwardLogic awardLogic = DependencyResolver.AwardLogic;

        public static void MainMenu()
        {
            System.Console.WriteLine("\tWaiting for a command...");
            string command = System.Console.ReadLine().ToLower();
            switch (command)
            {
                case "create":
                    {
                        CreateUser();
                        MainMenu();
                        break;
                    }

                case "create def":
                    {
                        CreateDefaultUser();
                        MainMenu();
                        break;
                    }

                case "delete":
                    {
                        DeleteUser();
                        MainMenu();
                        break;
                    }

                case "get":
                    {
                        GetUser();
                        MainMenu();
                        break;
                    }

                case "list":
                    {
                        UserList();
                        MainMenu();
                        break;
                    }

                case "createa":
                    {
                        CreateAward();
                        MainMenu();
                        break;
                    }

                case "deletea":
                    {
                        DeleteAward();
                        MainMenu();
                        break;
                    }

                case "geta":
                    {
                        GetAward();
                        MainMenu();
                        break;
                    }

                case "lista":
                    {
                        AwardList();
                        MainMenu();
                        break;
                    }

                case "adda":
                    {
                        AddAward();
                        MainMenu();
                        break;
                    }

                case "q":
                    {
                        break;
                    }

                default:
                    {
                        System.Console.WriteLine("\tInvalid command! Try again");
                        MainMenu();
                        break;
                    }
            }
        }

        public static void Main(string[] args)
        {
            System.Console.WriteLine(GREETING);
            MainMenu();
        }

        private static void CreateUser()
        {
            System.Console.WriteLine("\tEnter name. \t***leave blank line if you want default name***");
            string name = System.Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "DefaultUserName";
            }

            System.Console.WriteLine("\tEnter date of birth. Example : 20.12.2000 - Day.Month.Year");
            string date = System.Console.ReadLine();
            while (!DateValid(date))
            {
                System.Console.WriteLine("Invalid date of birth. Try again.");
                date = System.Console.ReadLine();
            }

            DateTime validDate = DateTime.Parse(date);
            User user = new User();
            user.Name = name;
            user.DateOfBirth = validDate;
            userLogic.Add(user);
            System.Console.WriteLine("\tUser successfully added.");
        }

        private static void CreateAward()
        {
            System.Console.WriteLine("\tEnter name. \t***leave blank line if you want default name***");
            string name = System.Console.ReadLine();

            Award award = new Award();
            award.Name = name;
            awardLogic.Add(award);
            System.Console.WriteLine("\tAward successfully created.");
        }

        private static void CreateDefaultUser()
        {
            User user = new User
            {
                Name = "DefaultName",
                DateOfBirth = DateTime.Parse("20.12.2000"),
            };
            userLogic.Add(user);
            System.Console.WriteLine("\tUser successfully added.");
        }

        private static bool DateValid(string dt)
        {
            try
            {
                DateTime date = DateTime.Parse(dt);
                DateTime now = DateTime.Now;

                if (date > now)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
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

            if (userLogic.Delete(id))
            {
                System.Console.WriteLine($"\tUser was successfully deleted.");
            }
        }

        private static void DeleteAward()
        {
            System.Console.WriteLine("Enter id");

            bool correctId = int.TryParse(System.Console.ReadLine(), out int id);
            while (!correctId)
            {
                System.Console.WriteLine("Incorrect value, try again.");
                correctId = int.TryParse(System.Console.ReadLine(), out id);
            }

            if (awardLogic.Delete(id))
            {
                System.Console.WriteLine($"\tAward was successfully deleted.");
            }
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

            var user = userLogic.Get(id);
            if (user == null)
            {
                System.Console.WriteLine("\tNo such user exists");
                return;
            }

            System.Console.WriteLine("\tUser-ID, Name, Age, Date of birth.");
            System.Console.WriteLine(user);
            System.Console.WriteLine(userLogic.ShowAward(id)); 
        }

        private static void AddAward()
        {
            System.Console.WriteLine("Enter USER id");

            bool correctUserId = int.TryParse(System.Console.ReadLine(), out int userId);
             while (!correctUserId)
            {
                System.Console.WriteLine("Incorrect value, try again.");
                correctUserId = int.TryParse(System.Console.ReadLine(), out userId);
            }

            System.Console.WriteLine("Enter AWARD id");

            bool correctAwardId = int.TryParse(System.Console.ReadLine(), out int awardId);
            while (!correctAwardId)
            {
                System.Console.WriteLine("Incorrect value, try again.");
                correctAwardId = int.TryParse(System.Console.ReadLine(), out awardId);
            }

            if (userLogic.AddAward(userId, awardId))
            {
                System.Console.WriteLine("Award successfully added.");
                return;
            }

            System.Console.WriteLine("Failed.");
        }

        private static void GetAward()
        {
            System.Console.WriteLine("Enter id");

            bool correctId = int.TryParse(System.Console.ReadLine(), out int id);
            while (!correctId)
            {
                System.Console.WriteLine("Incorrect value, try again.");
                correctId = int.TryParse(System.Console.ReadLine(), out id);
            }

            Award award = awardLogic.Get(id);
            if (award == null)
            {
                System.Console.WriteLine("\tNo such user exists");
                return;
            }

            System.Console.WriteLine("\tAward name:");
            System.Console.WriteLine(awardLogic.Get(id));
        }

        private static void UserList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var userPair in userLogic.GetAll())
            {
                sb.Append(userPair);
                sb.Append(Environment.NewLine);
                sb.Append(userLogic.ShowAward(userPair.Id));
                sb.Append(Environment.NewLine);
                sb.Append("------------------------------------------");
                sb.Append(Environment.NewLine);
            }

            if (sb.Length == 0)
            {
                System.Console.WriteLine("You have not added users yet.");
                return;
            }

            System.Console.WriteLine("\tUser-ID, Name, Age, Date of birth, Awards");
            System.Console.WriteLine(sb.ToString());
        }

        private static void AwardList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entity in awardLogic.GetAll())
            {
                sb.Append(entity);
                sb.Append(Environment.NewLine);
            }

            if (sb.Length == 0)
            {
                System.Console.WriteLine("You have not added awards yet.");
                return;
            }

            System.Console.WriteLine("\tAward-ID, Name");
            System.Console.WriteLine(sb.ToString());
        }
    }
}
