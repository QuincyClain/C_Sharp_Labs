using System;
using System.Collections.Generic;
using System.Text;

namespace WW
{
    delegate void DelegateRevive(int b);
    
    enum Status
    {
        atDeathDoor,
        dead,
        alive
    }
    struct Stamina
    {
        public int MaxStm;
        public int Stm;
        public Status st;
    }
    
    class Necromant : Mage, ILvl
    {
        public event EventHandler Ended;
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
            ManaPool = _mana;
            MaxManaPool = _maxmana;
            stamina.Stm = _stm;
            stamina.MaxStm = _MaxStm;
            stamina.st = Status.alive;
            Level = _lvl;
            AmoutOfRevives = 0;
            if (stamina.Stm < 0)
            {
                throw new Exception("Выносливость не может быть меньше нуля");
            }
            if (stamina.MaxStm <= 0)
            {
                throw new Exception("Максимальная выносливость не может быть меньше либо равна нулю");
            }
            if (stamina.Stm > stamina.MaxStm)
            {
                stamina.Stm = stamina.MaxStm;
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
            if (ManaPool > MaxMana)
            {
                ManaPool = MaxMana;
            }
            else if (ManaPool < 0)
            {
                throw new Exception("Мана не может быть меньше нуля");
            }
            if (MaxManaPool <= 0)
            {
                throw new Exception("Максимальная мана не может быть меньше либо равна нулю");
            }
            if (Level < 1)
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
            ManaPool = x.ManaPool;
            MaxManaPool = x.MaxManaPool;
            stamina.Stm = x.stamina.Stm;
            stamina.MaxStm = x.stamina.MaxStm;
            stamina.st = x.stamina.st;
            AmoutOfRevives = x.AmoutOfRevives;
            Level = x.Level;
        }
        ~Necromant() { }
        void ILvl.LvLUp(int a)
        {
            Console.WriteLine("Некромант {0} повысил уровень с {1} до {2}\n", name, Level, Level + a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", MaxManaPool, MaxManaPool + 20 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", ManaPool, ManaPool + 20 * a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", stamina.MaxStm, stamina.MaxStm + 10 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", stamina.Stm, stamina.Stm + 10 * a);
            MaxManaPool += 20 * a;
            ManaPool += 20 * a;
            stamina.MaxStm += 10 * a;
            stamina.Stm = +10 * a;

            Level += a;
        }
        public override void ChangeAge(int a)
        {
            if ((age - a) < 1)
            {
                throw new Exception("Нельзя больше уменьшить возраст");
            }
            if (ManaPool < a * 10)
            {
                throw new Exception("Не хватает маны для способности ChangeAge");
            }
            age -= a;
            ManaPool -= a * 10;
            if (AmoutOfRevives > 0)
            {
                AmoutOfRevives--;
            }
            if (AmoutOfRevives < 10)
            {
                stamina.st = Status.atDeathDoor;
            }
            if (AmoutOfRevives < 5)
            {
                stamina.st = Status.alive;
            }
        }
        public void Revive(int b)
        {
            if (stamina.Stm < b * 5)
            {
                throw new Exception("Не хватает выносливости для способности Revive");
            }
            age += b * 5;
            stamina.Stm -= b * 5;
            AmoutOfRevives += b;
            Console.WriteLine("Некромант возродил {0} мертвых душ", b);
            if (AmoutOfRevives >= 5)
            {
                stamina.st = Status.atDeathDoor;
            }
            if (AmoutOfRevives >= 10)
            {
                stamina.st = Status.dead;
            }
        }
        public void StmWasteForTest()
        {
            Stamina -= 250;
            if (Stamina < 0)
            {
                if (Ended != null)
                {
                    Ended(this, new EventArgs());
                }
            }
        }

        public int Stamina
        {
            get
            {
                return stamina.Stm;
            }
            set
            {
                if (stamina.Stm > stamina.MaxStm)
                {
                    stamina.Stm = stamina.MaxStm;
                }
                else if (stamina.Stm < 0)
                {
                    throw new Exception("Стамина не может быть меньше нуля");
                }
                else
                {
                    stamina.Stm = value;
                }
            }
        }
        public int MaxStamina
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
        public Status Stat
        {
            get
            {
                return stamina.st;
            }
        }

        //воскрешение мертвых в своих поданных с использованием маны и минус 1 год, сколько раз воскрешал (счетчик) (если больше 5 раз то halfdead, если больше 10 - dead);
    }
}
