using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dll;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            do
            {
                Console.WriteLine("1.Посчитать гипотенузу по теореме пифагора.");
                Console.WriteLine("2.Посчитать объем тетраэдра по ребру.");
                Console.WriteLine("3.Посчитать площадь круга, зная радиус.");
                Console.WriteLine("4.Посчитать дискриминант, по коэффициентам квадратного уравнения.");
                Console.WriteLine("5.Посчитать объем циллиндра, зная радиус основания и высоту.");
                Console.WriteLine("6.Закрыть программу.");
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Введите a и b");
                        Console.WriteLine("Гипотенуза = " + Dll.Class1.pythagorus());
                        break;
                    case 2:
                        Console.WriteLine("Введите ребро тетраэдра");
                        Console.WriteLine("Объем тетраэдра = " + Dll.Class2.Tetraedr());
                        break;
                    case 3:
                        Console.WriteLine("Введите радиус");
                        Console.WriteLine("Площадь кргуа = " + Dll.Class3.Circle());
                        break;
                    case 4:
                        Console.WriteLine("Введите коэффициенты a, b и c соответсвенно");
                        Console.WriteLine("Дискриминант =" + Dll.Class4.Discriminant());
                        break;
                    case 5:
                        Console.WriteLine("Введите радиус основания(r) и высоту(h)");
                        Console.WriteLine("Объем = " + Dll.Class5.Cilindre());
                        break;
                    case 6: { break; }
                        
                    default:
                        Console.WriteLine("Ошибка");
                        break;

                }

            }
            while (a != 6);
        }
    }
}
