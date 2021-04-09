using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dll
{
    public class Class2
    {
        static public double Tetraedr()
        {
            double V;
            double r = 0;
            while(true)
            {
                try
                {
                    r = Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите число");
                    continue;
                }
                if (r < 0)
                {
                    Console.WriteLine("Введите положительное значение");
                    continue;
                }
                else
                {
                    break;
                }
            }
            V = (Math.Pow(r, 3) * Math.Sqrt(2)) / 12;
            return V;
        }
    }
}
