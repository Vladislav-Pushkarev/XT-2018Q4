using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString2._4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string one = "It’s better to be safe than sorry.";
            string oneCopy = "It’s better to be safe than sorry.";
            string two = "People who live in glass houses should not throw stones.";

            MyString myOne = new MyString(one);
            MyString myOneCopy = new MyString(oneCopy);
            MyString myTwo = new MyString(two);

            Console.WriteLine("\tEquals method demonstration:");
            Console.WriteLine(myOne.Equals(myOneCopy));
            Console.WriteLine(myOne.Equals(myOne));
            Console.WriteLine(myOne.Equals(two));
            Console.WriteLine("\t== and != operators demonstration:");
            Console.WriteLine(myOne == myOneCopy);
            Console.WriteLine(myOne != myOne);
            Console.WriteLine(myOne != myTwo);

            char[] charArr = myOne.ToCharArray();
            Console.WriteLine("\tIndexOf and CharAt demonstration:");
            Console.WriteLine(myOne.IndexOf('s'));
            Console.WriteLine(myOne.CharAt(3));
            Console.WriteLine("\tCompare demonstration:");
            Console.WriteLine(MyString.Compare(myOne, myOneCopy));
            Console.WriteLine(MyString.Compare(myOne, myTwo));
            Console.WriteLine(MyString.Compare(myTwo, myOne));
        }
    }
}
