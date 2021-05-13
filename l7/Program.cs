using System;
namespace l7
{
    class Program
    {
        static void Main()
        {
            try
            {
                RationalNumber ratnum1 = new RationalNumber(0, 1);
                RationalNumber ratnum2 = new RationalNumber(0, 1);
                string str = "";
                string str2 = "";
                ConsoleKeyInfo ch;
                ConsoleKeyInfo ch1;

                Console.Clear();
                Console.WriteLine("Enter N");
                ratnum1.N = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Enter M");
                ratnum1.M = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Choose string format:");
                Console.WriteLine("1");
                Console.WriteLine("2");
                ch = Console.ReadKey();
                if (ch.KeyChar == '1')
                    str = ratnum1.ToString();
                if (ch.KeyChar == '2')
                    str = ratnum1.StrFormat();
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Your rational number: ");
                    Console.WriteLine(str);
                    Console.WriteLine("");
                    Console.WriteLine("1 - Add the rational number");
                    Console.WriteLine("2 - Subtract the rational number");
                    Console.WriteLine("3 - Multiplied by the rational number");
                    Console.WriteLine("4 - Divided by the rational number");
                    Console.WriteLine("5 - To equal with rational number");
                    Console.WriteLine("6 - Change string format");
                    Console.WriteLine("7 - WhoIsStronger");
                    Console.WriteLine("0 - Exit");
                    ch1 = Console.ReadKey();
                    if (ch1.KeyChar == '1')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter N");
                        ratnum2.N = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter M");
                        ratnum2.M = int.Parse(Console.ReadLine());
                        ratnum1 = ratnum1 + ratnum2;
                        if (ch.KeyChar == '1')
                            str = ratnum1.ToString();
                        if (ch.KeyChar == '2')
                            str = ratnum1.StrFormat();
                        Console.Clear();
                        Console.WriteLine("Press any key ...");
                    }

                    if (ch1.KeyChar == '2')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter N");
                        ratnum2.N = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter M");
                        ratnum2.M = int.Parse(Console.ReadLine());
                        ratnum1 = ratnum1 - ratnum2;
                        if (ch.KeyChar == '1')
                            str = ratnum1.ToString();
                        if (ch.KeyChar == '2')
                            str = ratnum1.StrFormat();
                        Console.Clear();
                        Console.WriteLine("Press any key ...");
                    }

                    if (ch1.KeyChar == '3')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter N");
                        ratnum2.N = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter M");
                        ratnum2.M = int.Parse(Console.ReadLine());
                        ratnum1 = ratnum1 * ratnum2;
                        if (ch.KeyChar == '1')
                            str = ratnum1.ToString();
                        if (ch.KeyChar == '2')
                            str = ratnum1.StrFormat();
                        Console.Clear();
                        Console.WriteLine("Press any key ...");
                    }

                    if (ch1.KeyChar == '4')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter N");
                        ratnum2.N = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter M");
                        ratnum2.M = int.Parse(Console.ReadLine());
                        ratnum1 = ratnum1 / ratnum2;
                        if (ch.KeyChar == '1')
                            str = ratnum1.ToString();
                        if (ch.KeyChar == '2')
                            str = ratnum1.StrFormat();
                        Console.Clear();
                        Console.WriteLine("Press any key ...");
                    }

                    if (ch1.KeyChar == '5')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter rational number: ");
                        str2 = Console.ReadLine();
                        ratnum2 = ratnum2.StrToObj(str2);
                        Console.Clear();
                        if (ratnum1.Equals(ratnum2))
                            Console.WriteLine("Yes");
                        else
                            Console.WriteLine("No");
                    }
                    if (ch1.KeyChar == '6')
                    {
                        Console.Clear();
                        Console.WriteLine("Choose string format:");
                        Console.WriteLine("1");
                        Console.WriteLine("2");
                        ch = Console.ReadKey();
                        if (ch.KeyChar == '1')
                            str = ratnum1.ToString();
                        if (ch.KeyChar == '2')
                            str = ratnum1.StrFormat();
                        Console.Clear();
                        Console.WriteLine("Press any key ...");
                    }
                    if (ch1.KeyChar == '7')
                    {
                        Console.Clear();
                        Console.WriteLine("Enter N");
                        ratnum2.N = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Enter M");
                        ratnum2.M = int.Parse(Console.ReadLine());
                        if (ratnum1 > ratnum2)
                        {
                            Console.WriteLine("{0} > {1}", ratnum1, ratnum2);
                        }
                        else
                        {
                            if (ratnum2 > ratnum1)
                            {
                                Console.WriteLine("{0} < {1}", ratnum1, ratnum2);
                            }
                        }
                    }

                    if (ch1.KeyChar == '0')
                        break;
                    Console.ReadKey();
                }
            }
            catch (Exception exc)
            {
                Console.Clear();
                Console.WriteLine(exc.Message);
            }
        }
    }
}
