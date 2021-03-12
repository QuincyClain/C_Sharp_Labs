using System;

namespace Лаба_2
{
    class Program
    {
        static void Main(string[] args)
        {

            Random Rand = new Random();
            Random Rnd = new Random();
            int value = Rand.Next(1, 5);
            char[] Str = new char[value];
            char[] Str1 = "qwertyuiopasdfghjklzxcvbnm".ToCharArray() ;
            for (int i = 0; i < value; i++)
            {
                Str[i] = Str1[Rnd.Next(0, 25)];
            }

            Console.WriteLine(Str);
            Console.ReadKey();
        }

    }
}
