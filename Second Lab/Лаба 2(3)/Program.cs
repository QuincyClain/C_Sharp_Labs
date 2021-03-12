using System;
namespace data
{
    class Program
    {
        static void Calculate(string str)
        {
            int[] amount = new int[10];
            for (int i = 0; i < 10; i++) { 
                amount[i] = 0;
            }
            for (int i = 0; i < str.Length; i++) { 
                if (str[i] >= '0' && str[i] <= '9') { 
                    amount[str[i] - 48] += 1;
                }
            }
            for (int i = 0; i < 10; i++) { 
                Console.WriteLine($"Number {i}:" + amount[i]);
            }
        }
        static void Main(string[] args)
        {
            string FirstDate = DateTime.Now.ToString("d");
            Console.WriteLine(FirstDate);
            Calculate(FirstDate);
            string SecondDate = DateTime.Now.ToString("F");
            Console.WriteLine(SecondDate);
            Calculate(SecondDate);
            Console.ReadKey();
        }
    }
}
