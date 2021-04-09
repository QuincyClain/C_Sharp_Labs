using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    public class Class1
    {
       
        static public double pythagorus()
        {
            double a;
            double b;
            double c;
            while (true)
            {
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число");
                    continue;
                }
                if (a < 0)
                {
                    Console.WriteLine("a не может быть отрицательным, введите заново");
                    continue;
                }
                try
                {
                    b = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите число");
                    continue;
                }
                if (b < 0)
                {
                    Console.WriteLine("b не может быть отрицательным, введите заново");
                    continue;
                }
                else
                    break;
            }

            c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return c;
        }
    }
    }
