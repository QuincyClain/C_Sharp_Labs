using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    public class Class3
    {
        static public double Circle()
        {
            double r;
            double S;
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
            S = Math.PI * Math.Pow(r, 2);
            return S;
        }
    }
}
