using System;


namespace _1st_lab_c_sharp
{
    public class Choice
    {

        public bool Appearence()
        {
            Console.WriteLine("Вы проснулись в какой-то странной пещере.\nПещера выглядит очень страшной и опасной(возможно там водятся какие-то монстры)");
            return false;
        }
        public bool Enter()
        {
            Console.WriteLine("А ты смелый! Может это и к лучшему, что решил войти в пещеру. Кто знает, что могло быть внизу?");
            Console.WriteLine("Ты видишь развилку в пещере с двумя путями. Первый путь выглядит безопасным,\nно не на сто процентов, однако ничего странного там не виднеется");
            Console.WriteLine("Во втором туннеле ты увидел блестящий меч, который может помочь тебе выжить,\nоднако от туда доносятся очень странные пугающие звуки.");

            return true;
        }
        public bool JumpDown()
        {
            return false;
        }
        public void Death()
        {
            Console.WriteLine("К сожалению удача вас подвела и вы погибли.");
        }
        public int SafeWay()
        {
            Console.WriteLine("Вы выбрали безопасный путь. Изначально все шло спокойно, вы увидели свет в конце туннеля");
            Console.WriteLine("Прям перед выходом вы случайно наступили на лежащий сучок и услышали странный шорох");
            Console.WriteLine("Перед вами оказался огромный монстр, и от его топота путь за вами полностью завалило обломками.");
            Console.WriteLine("У вас не осталось выбора и вы обязаны побежать к рычагу чтобы попытаться открыть дверь и убежать");
            Console.WriteLine("\n Да поможет вам удача\n)");
            var rand = new Random();

            return rand.Next(2);
        }
        public int DangerWay()
        {
            Console.WriteLine("Вы пошли в туннель со странными звуками в попытках забрать меч для дальнейшей безопасности");
            Console.WriteLine("Однако вскоре вы увидели странное существо стоящее спиной к вам, которое пока вас не заметило");
            Console.WriteLine("У вас в голове возникает две идеи:");

            int n = 0;
            int b = 0;
            var rand = new Random();
            do
            {
                Console.WriteLine("1.Попытаться пробраться незаметно за спиной у этого маленького чужого, забрать меч и пойти дальше");
                Console.WriteLine("2.Попытаться оглушить существо камнем со спины, чтобы спокойно забрать меч не рискуя быть замеченным");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error\n");
                    continue;
                }

                if (n == 1)
                {
                    b = rand.Next(2);
                    if (b == 1)
                    {
                        Console.WriteLine("Вы решили, что пытаться вырубить слишком опасно и к счастью..");
                        Console.WriteLine("Оказалось, что у существа нет ушей, поэтому вы спокойно пробрались за спиной, взяли меч и устремились к выходу");
                        return 1;
                    }
                    else
                    {
                        Death();
                        return 2;
                    }
                }
                else if (n == 2)
                {
                    b = rand.Next(2);
                    if (b == 1)
                    {
                        Console.WriteLine("Вы взяли с земли первый попавшийся большой камень, подкрались со спины и..");
                        Console.WriteLine("Успешно вырубили существо, забрали меч и устремились к выходу. Теперь у вас есть чем защитить себя");
                        return 1;
                    }
                    else
                    {
                        Death();
                        return 2;
                    }
                }
                else
                {
                    Console.WriteLine("Такого выбора нет");
                }
            } while (true);

        }
        public void Sword()
        {
            Console.WriteLine("Вы мужественно приняли поединок с монстром и с легкостью одолели его отрубив голову!");
            Console.WriteLine("Заберите его голову как добычу и с продайте ее какому-то торговцу за неплохое вознаграждение:)");
        }
        public void escape()
        {
            Console.WriteLine("Вы побоялись вступать в бой с монстром и попытались пробежать к рычагу, однако монстр оказался ловким и смог слегкостью догнать вас");
        }
        public static Choice Person;

    }

    public class Class1 : Choice
    {
        public static void Main(string[] args)
        {
            Choice person = new Choice();
            Choice Appearence = new Choice();
            person.Appearence();
            int a;
            int z = 0, m = 0;
            bool b = true;
            while (true)
            {
                if (m != 0)
                {
                    do
                    {
                        Console.WriteLine("1.Сыграть заново");
                        Console.WriteLine("2.Закончить");
                        try
                        {
                            z = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Error\n");
                            continue;
                        }
                        if (z == 1)
                        {
                            Console.WriteLine();
                            break;
                        }
                        else if (z == 2)
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Такого выбора нет");
                        }
                    } while (true);
                }
                m++;
                do
                {
                    Console.WriteLine("1. Пойти в глубь темной пещеры из которой доносятся странные звуки");
                    Console.WriteLine("2. Рискнуть и спрыгнуть вниз на свет(пещера все таки страшная)");
                    try
                    {
                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Error\n");
                        continue;
                    }

                    if (a == 1)
                    {
                        b = person.Enter(); break;
                    }
                    else if (a == 2)
                    {
                        b = person.JumpDown(); break;
                    }
                    else
                    {
                        Console.WriteLine("Error\n");
                        continue;
                    }
                } while (true);

                if (!b)
                {
                    person.Death();
                    continue;
                }
                do
                {
                    Console.WriteLine("1. Пойти по возможно безопасному пути");
                    Console.WriteLine("2. Пойти по пути со страшными звуками(может быть опасно), чтобы попробовать забрать меч");
                    try
                    {

                        a = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                        Console.WriteLine("Error\n");

                        continue;
                    }
                    int c = 2;
                    if (a == 1)
                    {
                        c = person.SafeWay();
                        if (c == 1)
                        {
                            Console.WriteLine("Вам повезло! Вы опустили дверь рычагом и успели пробраться в нее.");
                            Console.WriteLine("Монстр в погоне за вами споткнулся из-за чего не успел догнать вас.");
                            Console.WriteLine("Поздравляем! Вы победили!");
                        }
                        else if (c == 0)
                        {
                            Console.WriteLine("Вы попытались пробежать до рычага и открыть дверь, и уже хотели выпрыгнуть с пещеры");
                            Console.WriteLine("Однако в последний момент монстр схватил вас за ногу и вы погиблию. Возможно следовало выбрать другой путь");
                            Console.WriteLine("К сожалению вы проиграли! Попробуйте другой способ!");
                        }
                        break;
                    }
                    else if (a == 2)
                    {
                        c = person.DangerWay();
                        if (c == 1)
                        {
                            int r;
                            Console.WriteLine("Забрав меч, вы с довольным лицом шли к видневшимуся выходу, однако прям перед ним в конце туннеля сидел огромный монстр");
                            Console.WriteLine("А за ним дверь и рычаг. Перед вами остается последний выбор:");
                            do
                            {
                                Console.WriteLine("1.Мужественно принять бой и сразиться с монстром с помощью вашего острейшего меча, однако монстр и вправду выглядит опасным");
                                Console.WriteLine("2.Попытаться пробежать к рычагу открывающему дверь и сбежать от монстра.");
                                try
                                {
                                    r = Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Console.WriteLine("Error\n");
                                    continue;
                                }

                                if (r == 1)
                                {
                                    person.Sword();
                                    Console.WriteLine("Вы победили! Поздравляем!");
                                    break;
                                }
                                else if (r == 2)
                                {
                                    person.escape();
                                    person.Death();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Такого выбора нет");
                                    continue;
                                }

                            } while (true);
                        }
                        break;
                    }
                    else if (a == 7)
                    {                             //пасхалка
                        Console.WriteLine("Вы невероятно удачлив и нашли скрытый путь, где вас ждал Морган Фриман, чтобы спасти(Блек лайвс меттер)! Вы победили!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Такого выбора нет");
                    }
                } while (true);
            }
        }
    }
}
