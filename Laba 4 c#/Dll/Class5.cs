using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    public class Class5
    {
        static public double Cilindre()
        {
            double r;
            double h;
            double v;
            while (true)
            {
                try
                {
                    r = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите числовое значение радиуса");
                    continue;
                }
                if (r < 0)
                {
                    Console.WriteLine("Радиус не может быть отрицательным");
                    continue;
                }
                else
                {
                    break;
                }

            }
            while (true)
            {
                try
                {
                    h = Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Введите числовое значение высоты");
                    continue;
                }
                if (h < 0)
                {
                    Console.WriteLine("Высота не может быть отрицательным");
                    continue;
                }
                else
                {
                    break;
                }
            }
            v = Math.PI * Math.Pow(r, 2) * h;
            return v;
        }
    }
}
