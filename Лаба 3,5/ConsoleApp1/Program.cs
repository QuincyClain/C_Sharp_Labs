using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
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
    class Character
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
        class Program: Mage
    {
        static void Main(string[] args)
        {
            Character FirstObject = new Character(18, Race.Human, "Kirill", Gender.Male);
            Character SecondObject = new Character(ref FirstObject);
            Character ThirdObject = new Character(54, Race.Ork, "Valerii", Gender.Male);
            Mage FourthObject = new Mage(250, Race.Elf, "Avallakh", Gender.Male, 70, 100);
            Console.WriteLine("First Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\n", FirstObject.Age, FirstObject.Name, FirstObject.Ggender, FirstObject.Rrace);
            Console.WriteLine("Third Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\n", ThirdObject.Age, ThirdObject.Name, ThirdObject.Ggender, ThirdObject.Rrace);
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
            FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana);
            Console.WriteLine("FirstObject == SecondObject - {0}", FirstObject == SecondObject);
            Console.WriteLine("SecondObject == ThirdObject - {0}", SecondObject == ThirdObject);
            Console.WriteLine("FirstObject == ThirdObject - {0}\n", FirstObject == ThirdObject);
            Console.WriteLine("Использование способности ChangeAge(-1 год) магом: ");
            FourthObject.ChangeAge(1);
            Console.WriteLine("Fourth Object: \nВозраст: {0}\nИмя: {1}\nПол: {2}\nРаса: {3}\nМана: {4}\nМаксимальная мана: {5}\n", FourthObject.Age, FourthObject.Name, FourthObject.Ggender,
            FourthObject.Rrace, FourthObject.Mana, FourthObject.MaxMana);
            Console.WriteLine("FirstObject ID = {0}, SecondObject ID = {1}, ThirdObject ID = {2}, FourthObject ID = {3}", FirstObject.ID, SecondObject.ID, ThirdObject.ID, FourthObject.ID);
            Console.ReadKey();
        }
    }
    class Mage : Character
    {
        protected int mana;
        protected int maxmana;
        public Mage() { }
        public Mage(int _age, Race _race, string _name, Gender _gender, int _mana, int _maxmana)
        {
            ID = ++nextID;

            age = _age;
            name = _name;
            gender = _gender;
            race = _race;
            mana = _mana;
            maxmana = _maxmana;
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

        }
        public void ChangeAge(int a)
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
            mana -= a * 20;
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

    }
    class Necromant { //воскрешение мертвых в своих поданных с использованием маны и минус 1 год, сколько раз воскрешал (счетчик) (если больше 5 раз то halfdead, если больше 10 - dead);
    }
}
     
