using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace WW
{
    delegate void Fight(string delegatestring);
    class Program
    {
        public static void OnEnded(object sender, EventArgs eventArgs)
        {
            if (sender is Necromant)
            {
                Console.WriteLine("Некроманту не хватает стамины");
            }
            else if (sender is Mage)
            {
                Console.WriteLine("Магу не хватает маны");
            }
        }
        public static void NecroWin(string somestring)
        {
            Console.WriteLine(somestring);
        }
        public static void MageWin(string somestr)
        {
            Console.WriteLine(somestr);
        }
        public static void Battle(Mage A, Necromant B, Fight n, Fight m)
        {
            Console.WriteLine("Маг и Некромант сошлись в битве заклинаний");
            Console.WriteLine("Исход битвы:");
            if (A.Mana > B.Mana)
            {
                m("у Мага больше маны на => он выиграл\n");
                Console.WriteLine("Разница в мане на {0}\n", A.Mana - B.Mana);
            }
            else if (B.Mana > A.Mana)
            {
                n("у Некроманта больше маны на => он выиграл\n");
                Console.WriteLine("Разница в мане на {0}\n", B.Mana - A.Mana);
            }
        }
        static void Main(string[] args)
        {
            Character FirstObject = new Character(18, Race.Human, "Kirill", Gender.Male);
            Character SecondObject = new Character(ref FirstObject);
            Character ThirdObject = new Character(54, Race.Ork, "Valerii", Gender.Male);
            Mage FourthObject = new Mage(154, Race.Elf, "Avallakh", Gender.Male, 70, 100, 1);
            Necromant FifthObject = new Necromant(100, Race.Ork, "Guldan", Gender.Male, 80, 150, 60, 100, 1);
            Fight fightresult = NecroWin;
            Fight fightresult2 = MageWin;
            Battle(FourthObject, FifthObject, fightresult, fightresult2);
            ILvl l = FourthObject;
            ILvl l2 = FifthObject;
            var characters = new List<Mage>
            {
               FourthObject,
               FifthObject
            };
            List<Character> age = new List<Character>()
            {
                FirstObject,
                ThirdObject,
                FourthObject,
                FifthObject
            };
            DelegateRevive method = FifthObject.Revive;
            Console.WriteLine("First Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\n", FirstObject.Age, FirstObject.Name, FirstObject.Ggender, FirstObject.Rrace);
            Console.WriteLine("Third Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\n", ThirdObject.Age, ThirdObject.Name, ThirdObject.Ggender, ThirdObject.Rrace);
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nТекущий уровень: {6}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
            FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana, FourthObject.Lvl);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\nТекущий уровень: {9}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.Stamina, FifthObject.MaxStamina, FifthObject.Stat, FifthObject.Lvl);

            Console.WriteLine("FirstObject == SecondObject - {0}", FirstObject == SecondObject);
            Console.WriteLine("SecondObject == ThirdObject - {0}", SecondObject == ThirdObject);
            Console.WriteLine("FirstObject == ThirdObject - {0}\n", FirstObject == ThirdObject);

            Console.WriteLine("Использование способности ChangeAge(-1 год) магом: ");
            FourthObject.ChangeAge(1);
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
            FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana);

            Console.WriteLine("Использование способности Revive(5 душ)\n");
            FifthObject.Revive(5);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.Stamina, FifthObject.MaxStamina, FifthObject.Stat);
            Console.WriteLine("Использование способности ChangeAge(3 года)");
            FifthObject.ChangeAge(3);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.Stamina, FifthObject.MaxStamina, FifthObject.Stat);
            Console.WriteLine("Использование способности Revive (5 душ)\n");
            method(5); // вызов метода Revive через объект делегата
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.Stamina, FifthObject.MaxStamina, FifthObject.Stat);
            l2.LvLUp(5);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\nТекущий уровень: {9}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.Stamina, FifthObject.MaxStamina, FifthObject.Stat, FifthObject.Lvl);
            Console.WriteLine("FirstObject ID = {0}, SecondObject ID = {1}, ThirdObject ID = {2}, FourthObject ID = {3}\n", FirstObject.ID, SecondObject.ID, ThirdObject.ID, FourthObject.ID);
            foreach (var charr in characters)
            {
                charr.ChangeAge(3);
            }
            l.LvLUp(5);
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
           FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.Stamina, FifthObject.MaxStamina, FifthObject.Stat);
            foreach (Character x in age)
            {
                Console.WriteLine("Имя: {0}\tВозраст: {1}", x.Name, x.Age);
            }
            age.Sort();
            Console.WriteLine("\n");
            foreach (Character x in age)
            {
                Console.WriteLine("Имя: {0}\tВозраст: {1}", x.Name, x.Age);
            }
            FourthObject.LvlUpChangeAge(2, 5);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nТекущий уровень: {6}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana, FourthObject.Lvl);

            FourthObject.Ended += OnEnded;  // подписка на один и тот же метод, но с разделением у какого класса сработало
            FifthObject.Ended += OnEnded;

            FourthObject.ManaWasteForTest();
            FifthObject.StmWasteForTest();

            Console.ReadKey();
        }
    }
}

