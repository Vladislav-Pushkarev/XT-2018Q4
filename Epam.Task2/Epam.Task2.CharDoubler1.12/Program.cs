using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task2.CharDoubler1._12
{
    class Program
    {
        class Test
        {
            public static string CharDoubler()
            {
                Console.WriteLine("\tEnter the first sentence :");
                char[] str = Console.ReadLine().ToCharArray();
                Console.WriteLine("\tEnter the second sentence :");
                char[] ch = Console.ReadLine().ToCharArray();
                StringBuilder newStr = new StringBuilder(str.Length);
                for (int i = 0; i < str.Length; i++)
                {
                    newStr.Append(str[i]);
                    for (int j = 0; j < ch.Length; j++)
                    {
                        if (char.ToUpper(str[i]) == char.ToUpper(ch[j]))
                        {
                            newStr.Append(str[i]);
                            break;
                        }
                    }
                }
                return newStr.ToString();
            }

            static void Main(String[] args)
            {
                Console.WriteLine(CharDoubler());
            }
        }
    }
}
