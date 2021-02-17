using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1st_lab_c_sharp
{

    public class choice
    {

        public bool poyavlenie()
        {
            Console.WriteLine("Вы проснулись в какой-то странной пещере. Пещера выглядит очень страшной и опасной(возможно там водятся какие-то монстры)");
            return false;
        }
        public bool poiti()
        {
            Console.WriteLine("А ты смелый! Может это и к лучшему, что решил войти в пещеру. Кто знает, что могло быть внизу?");
            Console.WriteLine("Ты видишь развилку в пещере с двумя путями. Первый путь выглядит безопасным,\nно не на сто процентов, однако ничего странного там не виднеется");
            Console.WriteLine("Во втором туннеле ты увидел блестящий меч, который может помочь тебе выжить,\nоднако от туда доносятся очень странные пугающие звуки.");
            Console.WriteLine("1. Пойти по возможно безопасному пути");
            Console.WriteLine("2. Пойти по пути со страшными звуками(может быть опасно), чтобы попробовать забрать меч");
            return true;
        }
        public bool sprignut()
        {
            return false;
        }
        public void death()
        {
            Console.WriteLine("К сожалению удача вас подвела и вы погибли.");
        }
        public static choice person;

    }

    public class Class1 : choice
    {
        public static void Main(string[] args)
        {
            choice person = new choice();
            choice poyavlenie = new choice();
            person.poyavlenie();
            int a;
            bool b = true;
            Console.WriteLine("1. Пойти в глубь темной пещеры из которой доносятся странные звуки");
            Console.WriteLine("2. Рискнуть и спрыгнуть вниз на свет(пещера все таки страшная)");
            a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1: b = person.poiti(); break;

                case 2: b = person.sprignut(); break;

                default: Console.WriteLine("Такого выбора нет"); break;
            }
            if (!b)
            {
                person.death();
            }



            Console.ReadLine();

        }


    }
}
