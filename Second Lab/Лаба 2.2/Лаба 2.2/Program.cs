using System;

namespace Лаба_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string[] words = str.Split(' ');

            foreach (string st in words)

                //Console.WriteLine("{0}\n", st);

            Array.Reverse(words);
            Console.WriteLine("В обратном порядке:");

            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
