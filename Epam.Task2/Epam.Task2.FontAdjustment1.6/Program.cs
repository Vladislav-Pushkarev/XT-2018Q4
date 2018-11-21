using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.FontAdjustment1._6
{
     class Program
    {
        [Flags]
        enum Font
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4,
        }

        public static void FontOptions ()
        {
            bool switcher = true;
            Font font = 0;
            Console.WriteLine("Параметры надписи: {0}", font);
          
           do
            {              
                Console.WriteLine("Введите:" + Environment.NewLine +
                                  "\t1: bold" + Environment.NewLine +
                                  "\t2: italic" + Environment.NewLine +
                                  "\t3: underline");
                
                if (Int32.TryParse(Console.ReadLine(), out int key))
                {

                    switch (key)
                    {
                        case 1:
                            font ^= Font.Bold;
                            break;
                        case 2:
                            font ^= Font.Italic;
                            break;
                        case 3:
                            font ^= Font.Underline;
                            break;
                        default:
                             Console.WriteLine("Incorrect value. "
                             + "Push \"Enter\" to close the programm, or enter the right value.");
                             switcher = !(Console.ReadLine() == (string.Empty));
                            break;
                    }
                    Console.WriteLine("Параметры надписи:{0}", font);
                }
                else 
                {
                      Console.WriteLine("Incorrect value. "
                             + "Push \"Enter\" to close the programm, or enter the right value.");
                             switcher = !(Console.ReadLine() == (string.Empty));
                }
            } 
            while (switcher);
            
        }

         static void Main(string[] args)
        {
            FontOptions();
        }
    }
}