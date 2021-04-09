using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    public class Class4
    {
        static public double Discriminant()
        {
            int x = 0;
            double D;
            double a, b = 0, c = 0;
            while (true)
            {
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }
                if (a == 0)
                {
                    Console.WriteLine("коэффициент a не может быть равен нулю");
                    continue;
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                x = 0;
                try
                {
                    b = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    x = 1;
                }
                if (x == 0)
                {
                    break;
                }
            }
            while(true)
            {
                x = 0;
                try
                {
                    c = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число!");
                    x = 1;
                }
                if (x == 0)
                {
                    break;
                }
            }
            D = (Math.Pow(b, 2) - 4 * a * c);
            return D;
        }
    }
}
