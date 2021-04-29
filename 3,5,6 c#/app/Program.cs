using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ILVL
    {

        void LvLUp(int a);
    }

    enum Status
    {
        at_deaths_door,
        dead,
        alive
    }
    struct Stamina
    {
        public int MaxStm;
        public int stm;
        public Status st;
    }
    enum Race
    {
        Elf,
        Ork,
        Gnum,
        Human
    }
    enum Gender
    {
        Male,
        Female
    }
    class Character : IComparable<Character>
    {
        protected int age;
        protected Race race;
        protected string name;
        protected Gender gender;
        protected static int nextID = 0;
        public int ID { get; protected set; }
        public Character() { }
        public Character(int _age, Race _race, string _name, Gender _gender)
        {
            ID = ++nextID;
            age = _age;
            name = _name;
            gender = _gender;
            race = _race;
        }
        public Character(ref Character A)
        {
            ID = ++nextID;
            age = A.age;
            name = A.name;
            gender = A.gender;
        }
        ~Character()
        {
            Console.WriteLine("Удалено");
        }
        public int CompareTo(Character obj)
        {
            
            if (age > obj.age)
            {
                return 1;
            }
            if (age == obj.age)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age < 0)
                {
                    throw new Exception("Возраст меньше нуля");
                }
                else
                {
                    age = value;
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name.Length == 0)
                {
                    throw new Exception("Пустая строка");
                }
                if (name == null)
                {
                    throw new Exception("Нулевой указатель на строку");
                }
                else
                {
                    name = value;
                }
            }
        }
        public Gender Ggender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public Race Rrace
        {
            get
            {
                return race;
            }
            set
            {
                race = value;
            }
        }
        public static bool operator ==(Character A, Character B)
        {
            return (A.age == B.age && A.name == B.name && A.gender == B.gender);
        }
        public static bool operator !=(Character A, Character B)
        {
            return !(A == B);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        
            Character FirstObject = new Character(18, Race.Human, "Kirill", Gender.Male);
            Character SecondObject = new Character(ref FirstObject);
            Character ThirdObject = new Character(54, Race.Ork, "Valerii", Gender.Male);
            Mage FourthObject = new Mage(154, Race.Elf, "Avallakh", Gender.Male, 70, 100, 1);
            Necromant FifthObject = new Necromant(100, Race.Ork, "Guldan", Gender.Male, 80, 150, 60, 100, 1);
            List<Character> level = new List<Character>()
            {
                FourthObject,
                FifthObject
            };
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

            Console.WriteLine("First Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\n", FirstObject.Age, FirstObject.Name, FirstObject.Ggender, FirstObject.Rrace);
            Console.WriteLine("Third Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\n", ThirdObject.Age, ThirdObject.Name, ThirdObject.Ggender, ThirdObject.Rrace);
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nТекущий уровень: {6}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
            FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana, FourthObject.LVL);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\nТекущий уровень: {9}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.STAMINA, FifthObject.MAXSTAMINA, FifthObject.STATUS, FifthObject.LVL);

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
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.STAMINA, FifthObject.MAXSTAMINA, FifthObject.STATUS);
            Console.WriteLine("Использование способности ChangeAge(3 года)");
            FifthObject.ChangeAge(3);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.STAMINA, FifthObject.MAXSTAMINA, FifthObject.STATUS);
            Console.WriteLine("Использование способности Revive (6 душ)\n");
            FifthObject.Revive(6);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.STAMINA, FifthObject.MAXSTAMINA, FifthObject.STATUS);
            FifthObject.LvLUp(5);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\nТекущий уровень: {9}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.STAMINA, FifthObject.MAXSTAMINA, FifthObject.STATUS, FifthObject.LVL);
            Console.WriteLine("FirstObject ID = {0}, SecondObject ID = {1}, ThirdObject ID = {2}, FourthObject ID = {3}\n", FirstObject.ID, SecondObject.ID, ThirdObject.ID, FourthObject.ID);
            foreach (var charr in characters)
            {
                charr.ChangeAge(3);
            }
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
           FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana);
            Console.WriteLine("FifthObject: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\nВыносливость: {6}\nМаксимальная выносливость: {7}\nСостояние: {8}\n", FifthObject.Age, FifthObject.Name, FifthObject.Ggender,
            FifthObject.Rrace, FifthObject.Mana, FifthObject.MaxMana, FifthObject.STAMINA, FifthObject.MAXSTAMINA, FifthObject.STATUS);
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
            
            Console.ReadKey();
        }
    }
    class Mage : Character, ILVL
    {

        protected int lvl;
        protected int mana;
        protected int maxmana;
        public Mage() { }
        public Mage(int _age, Race _race, string _name, Gender _gender, int _mana, int _maxmana, int _lvl)
        {
            ID = ++nextID;

            age = _age;
            name = _name;
            gender = _gender;
            race = _race;
            mana = _mana;
            maxmana = _maxmana;
            lvl = _lvl;
            if (age < 1)
            {
                throw new Exception("Возраст меньше допустимого");
            }
            if (name.Length == 0)
            {
                throw new Exception("Пустая строка");
            }
            if (name == null)
            {
                throw new Exception("Нулевой указатель на строку");
            }
            if (mana > MaxMana)
            {
                mana = MaxMana;
            }
            else if (mana < 0)
            {
                throw new Exception("Мана не может быть меньше нуля");
            }
            if (maxmana <= 0)
            {
                throw new Exception("Максимальная мана не может быть меньше либо равна нулю");
            }
            if (lvl < 1)
            {
                throw new Exception("Уровень не может быть меньше первого");
            }

        }
        public Mage(ref Mage x)
        {
            age = x.age;
            name = x.name;
            gender = x.gender;
            race = x.race;
            mana = x.mana;
            maxmana = x.maxmana;
            lvl = x.lvl;
        }
        public void LvLUp(int a)
        {
            Console.WriteLine("Маг {0} повысил уровень с {1} до {2}\n", name, lvl, lvl + a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", maxmana, maxmana + 20 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", mana, mana + 20 * a);
            lvl += a;
            maxmana += 20 * a;
            mana += 20 * a;
        }
        public virtual void ChangeAge(int a)
        {
            if ((age - a) < 1)
            {
                throw new Exception("Нельзя больше уменьшить возраст");
            }
            if (mana < a * 20)
            {
                throw new Exception("Не хватает маны для способности ChangeAge");
            }
            age -= a;
            mana -= a * 2;
        }
        public int Mana
        {
            get
            {
                return mana;
            }
            set
            {
                if (mana > MaxMana)
                {
                    mana = MaxMana;
                }
                else if (mana < 0)
                {
                    throw new Exception("Мана не может быть меньше нуля");
                }
                else
                {
                    mana = value;
                }
            }
        }
        public int MaxMana
        {
            get
            {
                return maxmana;
            }
            set
            {
                if (maxmana <= 0)
                {
                    throw new Exception("Максимальная мана не может быть меньше либо равна нулю");
                }
                else
                {
                    maxmana = value;
                }
            }
        }
        public int LVL
        {
            get
            {
                return lvl;
            }
            set
            {
                if (lvl < 1)
                {
                    throw new Exception("Минимальный уровень - 1");
                }
                else
                {
                    lvl = value;
                }
            }
        }
    }
    class Necromant : Mage, ILVL
    {
        Stamina stamina;
        int AmoutOfRevives = 0;
        public Necromant() { }
        public Necromant(int _age, Race _race, string _name, Gender _gender, int _mana, int _maxmana, int _stm, int _MaxStm, int _lvl)
        {
            ID = ++nextID;

            age = _age;
            name = _name;
            gender = _gender;
            race = _race;
            mana = _mana;
            maxmana = _maxmana;
            stamina.stm = _stm;
            stamina.MaxStm = _MaxStm;
            stamina.st = Status.alive;
            lvl = _lvl;
            AmoutOfRevives = 0;
            if (stamina.stm < 0)
            {
                throw new Exception("Выносливость не может быть меньше нуля");
            }
            if (stamina.MaxStm <= 0)
            {
                throw new Exception("Максимальная выносливость не может быть меньше либо равна нулю");
            }
            if (stamina.stm > stamina.MaxStm)
            {
                stamina.stm = stamina.MaxStm;
            }
            if (age < 1)
            {
                throw new Exception("Возраст меньше допустимого");
            }
            if (name.Length == 0)
            {
                throw new Exception("Пустая строка");
            }
            if (name == null)
            {
                throw new Exception("Нулевой указатель на строку");
            }
            if (mana > MaxMana)
            {
                mana = MaxMana;
            }
            else if (mana < 0)
            {
                throw new Exception("Мана не может быть меньше нуля");
            }
            if (maxmana <= 0)
            {
                throw new Exception("Максимальная мана не может быть меньше либо равна нулю");
            }
            if (lvl < 1)
            {
                throw new Exception("Минимальный уровень - 1");
            }

        }

        public Necromant(ref Necromant x)
        {
            age = x.age;
            name = x.name;
            gender = x.gender;
            race = x.race;
            mana = x.mana;
            maxmana = x.maxmana;
            stamina.stm = x.stamina.stm;
            stamina.MaxStm = x.stamina.MaxStm;
            stamina.st = x.stamina.st;
            AmoutOfRevives = x.AmoutOfRevives;
            lvl = x.lvl;
        }
        ~Necromant() { }
        void ILVL.LvLUp(int a)
        {
            Console.WriteLine("Некромант {0} повысил уровень с {1} до {2}\n", name, lvl, lvl + a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", maxmana, maxmana + 20 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", mana, mana + 20 * a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", stamina.MaxStm, stamina.MaxStm + 10 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", stamina.stm, stamina.stm + 10 * a);
            maxmana += 20 * a;
            mana += 20 * a;
            stamina.MaxStm += 10 * a;
            stamina.stm = +10 * a;

            lvl += a;
        }
        public override void ChangeAge(int a)
        {
            if ((age - a) < 1)
            {
                throw new Exception("Нельзя больше уменьшить возраст");
            }
            if (mana < a * 10)
            {
                throw new Exception("Не хватает маны для способности ChangeAge");
            }
            age -= a;
            mana -= a * 10;
            if (AmoutOfRevives > 0)
            {
                AmoutOfRevives--;
            }
            if (AmoutOfRevives < 10)
            {
                stamina.st = Status.at_deaths_door;
            }
            if (AmoutOfRevives < 5)
            {
                stamina.st = Status.alive;
            }
        }
        public void Revive(int b)
        {
            if (stamina.stm < b * 5)
            {
                throw new Exception("Не хватает выносливости для способности Revive");
            }
            age += b * 5;
            stamina.stm -= b * 5;
            AmoutOfRevives += b;
            Console.WriteLine("Некромант возродил {0} мертвых душ", b);
            if (AmoutOfRevives >= 5)
            {
                stamina.st = Status.at_deaths_door;
            }
            if (AmoutOfRevives >= 10)
            {
                stamina.st = Status.dead;
            }
        }
        public int STAMINA
        {
            get
            {
                return stamina.stm;
            }
            set
            {
                if (stamina.stm > stamina.MaxStm)
                {
                    stamina.stm = stamina.MaxStm;
                }
                else if (stamina.stm < 0)
                {
                    throw new Exception("Стамина не может быть меньше нуля");
                }
                else
                {
                    stamina.stm = value;
                }
            }
        }
        public int MAXSTAMINA
        {
            get
            {
                return stamina.MaxStm;
            }
            set
            {
                if (stamina.MaxStm <= 0)
                {
                    throw new Exception("Максимальная выносливость не может быть меньше либо равна нулю");
                }
                else
                {
                    stamina.MaxStm = value;
                }
            }
        }
        public Status STATUS
        {
            get
            {
                return stamina.st;
            }
        }

        //воскрешение мертвых в своих поданных с использованием маны и минус 1 год, сколько раз воскрешал (счетчик) (если больше 5 раз то halfdead, если больше 10 - dead);
    }
}
