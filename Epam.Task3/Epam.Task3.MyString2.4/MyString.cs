using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task3.MyString2._4
{
    public class MyString
    {
        private char[] myStr;

        public MyString(string input)
        {
            this.myStr = input.ToCharArray();
        }

         public MyString()
        {
            this.myStr = null;
        }

        public MyString(char[] inputCharArr)
        {
            this.myStr = inputCharArr;
        }

        public int Length
        {
            get
            {
                return this.myStr.Length;
            }
        }

        public static bool operator ==(MyString firstStr, MyString secondStr)
        {
            return firstStr.Equals(secondStr);
        }

        public static bool operator !=(MyString firstStr, MyString secondStr)
        {
            return !firstStr.Equals(secondStr);
        }

        public static int Compare(MyString firstStr, MyString secondStr)
        {
            int minLength = firstStr.Length <= secondStr.Length ? firstStr.Length : secondStr.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (firstStr.myStr[i] == secondStr.myStr[i])
                {
                    continue;
                }
                else
                {
                    if (firstStr.myStr[i] < secondStr.myStr[i])
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }

            if (firstStr.Length == secondStr.Length)
            {
                return 0;
            }
            else
            {
                if (firstStr.Length < secondStr.Length)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        public static MyString operator +(MyString firstStr, MyString secondStr)
        {
            int lenght = firstStr.myStr.Length + secondStr.myStr.Length;
            char[] newCharArray = new char[lenght];
            for (int i = 0; i < lenght; i++) 
            {
                for (int j = 0; j < lenght; j++) 
                {
                    newCharArray[i] = firstStr.myStr[j];
                }

                 for (int k = 0; k < lenght; k++) 
                {
                    newCharArray[i] = secondStr.myStr[k];
                }
            }

            MyString newMyString = new MyString(newCharArray);
            return newMyString;
        }

        public override bool Equals(object strObj)
        {
     ////  styleCop =(
     ////       if (this == strObj)
     ////      {
     ////           return true;
     ////       }
            if (strObj is MyString)
            {
                MyString anotherString = (MyString)strObj;
                if (this.myStr.Length == anotherString.myStr.Length)
                {
                    for (int i = 0; i < this.Length; i++)
                    {
                        if (this.myStr[i] != anotherString.myStr[i])
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return new string(this.myStr);
        }

        public int IndexOf(char ch)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this.myStr[i] == ch)
                {
                    return i;
                }
            }

            return -1;
        }

        public char[] ToCharArray()
        {
            return this.myStr;
        }
        
        public char CharAt(int index)
        {
            if (index < 0 || index >= this.myStr.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return this.myStr[index];
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
