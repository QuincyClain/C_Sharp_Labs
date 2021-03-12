using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_2_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int i1 = 0, i2 = 0, z = 0;
            char r;
            StringBuilder someString = new StringBuilder(str);
            i2 = str.Length - 1; // становится на последний символ строки
            while (i2 > i1)
            {
                r = someString[i1];
                someString[i1] = someString[i2];            //полностью в обратном порядке строку(включая буквы);
                someString[i2] = r;
                i2--;
                i1++;                     
            }
            i2 = 0;
            i1 = 0;
            for (int i = 0; i < str.Length; i++)
            {
                while (someString[z] == ' ')
                {
                    i2 = z - 1; // до пробела 
                    while (i2 > i1)
                    {
                        r = someString[i1];
                        someString[i1] = someString[i2];
                        someString[i2] = r;
                        i2--; 
                        i1++;                  
                    }
                    z++; //переход на первый символ след слова
                    i1 = z; //начало след слова
                }
                while (someString[z] !=' ' && z<(str.Length - 1))
                {
                    z++;
                }
            }
            i2 = z;
            while (i2 > i1)   //реверс последнего слова в строке
            {
                r = someString[i1];
                someString[i1] = someString[i2];
                someString[i2] = r;
                i2--;
                i1++;
            }
            str = someString.ToString();
            for (int i =0; i < str.Length; i++)
            {
                Console.Write(str[i]);
            }
            Console.ReadKey();
        }
    }
}
