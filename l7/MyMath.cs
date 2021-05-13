using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l7
{
    class MyMath
    {
        public static int GreatestCommonDivisor(int number1, int number2)
        {
            if (number2 != 0)
            {
                return GreatestCommonDivisor(number2, number1 % number2);
            }
            else
            {
                return number1;
            }
        }
        public static int LeastCommonMultiple(int number1, int number2)
        {
            return number1 / GreatestCommonDivisor(number1, number2) * number2;
        }
    }
}
