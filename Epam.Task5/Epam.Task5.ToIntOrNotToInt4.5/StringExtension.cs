using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task5.ToIntOrNotToInt4._5
{
    public static class StringExtension
    {
        public static bool ToInt(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            bool exp = false;
            bool com = false;
            bool minus = false;

            int i = 0;
            int length = str.Length;
            List<char> integer = new List<char>();
            List<char> decim = new List<char>();
            List<char> pwr = new List<char>();
            char firstChar = str[0];

            if (firstChar == '+')
            {
                i++;
            }

            if (length == 1)
            {
                return false;
            }

            if (!char.IsDigit(str[i]) && str[i] == '0')
            {
                return false;
            }

            for (; i < length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    if (exp)
                    {
                        pwr.Add(str[i]);
                        continue;
                    }

                    if (com)
                    {
                        decim.Add(str[i]);
                        continue;
                    }

                    if (!com && !exp)
                    {
                        integer.Add(str[i]);
                    }
                }
                else if (str[i] == ',')
                {
                    if (com)
                    {
                        return false;
                    }

                    com = true;
                    if (i == length - 1 || !char.IsDigit(str[i + 1]))
                    {
                        return false;
                    }
                }
                else if (char.ToLower(str[i]) == 'e')
                {
                    if (exp)
                    {
                        return false;
                    }

                    exp = true;
                    if (i + 1 < length - 1)
                    {
                        i++;

                        if (str[i] == '-' || str[i] == '+')
                        {
                            if (str[i] == '-')
                            {
                                minus = true;
                            }
                        }
                        else
                        {
                            i--;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            int power = 0;
            i = 0;

            foreach (char ch in pwr)
            {
                power = (power * 10) + ((int)char.GetNumericValue(ch));
            }

            if (minus)
            {
                power = power * -1;
            }

            if ((power + integer.Count) > decim.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
