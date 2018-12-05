using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.VectorGraphicsEditor2._7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InterfaceOne();
            InputCommand(ConsoleInput());
        }

        private static void InputCommand(string command)
        {
            switch (command)
            {
                case "circle":
                    Circle circle = new Circle();
                    circle.Print();
                    break;
                case "rectangle":
                    Rectangle rectangle = new Rectangle();
                    rectangle.Print();
                    break;
                case "ring":
                    Ring ring = new Ring();
                    ring.Print();
                    break;
                case "line":
                    Line line = new Line();
                    line.Print();
                    break;
                case "round":
                    Round round = new Round();
                    round.Print();
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Incorrect input number");
                    ConsoleInput();
                    break;
            }
        }

        private static void InterfaceOne()
        {
            Console.WriteLine("\tWhat figure would you like to see?" + Environment.NewLine +
                "Print - \"circle\" and you got a circle" + Environment.NewLine +
                "Print - \"rectangle\" and you got a rectangle" + Environment.NewLine +
                "Print - \"ring\" and you got a ring" + Environment.NewLine +
                "Print - \"line\" and you got a line" + Environment.NewLine +
                "Print - \"round\" and you got a round" + Environment.NewLine +
                "\tPrint - \"exit\" to EXIT." + Environment.NewLine);
        }

        private static string ConsoleInput()
        {
            string input = Console.ReadLine();
            return input.ToLower();
        }
    }
}
