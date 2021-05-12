using System;
using System.Collections.Generic;
using System.Text;

namespace WW
{
    enum Status
    {
        atDeathDoor,
        dead,
        alive
    }
    struct Stamina
    {
        public int maxStm;
        public int stm;
        public Status st;
    }

    class Necromant : Mage, ILvl
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
            stamina.maxStm = _MaxStm;
            stamina.st = Status.alive;
            lvl = _lvl;
            AmoutOfRevives = 0;
            if (stamina.stm < 0)
            {
                throw new Exception("Выносливость не может быть меньше нуля");
            }
            if (stamina.maxStm <= 0)
            {
                throw new Exception("Максимальная выносливость не может быть меньше либо равна нулю");
            }
            if (stamina.stm > stamina.maxStm)
            {
                stamina.stm = stamina.maxStm;
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
            stamina.maxStm = x.stamina.maxStm;
            stamina.st = x.stamina.st;
            AmoutOfRevives = x.AmoutOfRevives;
            lvl = x.lvl;
        }
        ~Necromant() { }
        void ILvl.LvLUp(int a)
        {
            Console.WriteLine("Некромант {0} повысил уровень с {1} до {2}\n", name, lvl, lvl + a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", maxmana, maxmana + 20 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", mana, mana + 20 * a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", stamina.maxStm, stamina.maxStm + 10 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", stamina.stm, stamina.stm + 10 * a);
            maxmana += 20 * a;
            mana += 20 * a;
            stamina.maxStm += 10 * a;
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
                stamina.st = Status.atDeathDoor;
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
                stamina.st = Status.atDeathDoor;
            }
            if (AmoutOfRevives >= 10)
            {
                stamina.st = Status.dead;
            }
        }
        public int Stamina
        {
            get
            {
                return stamina.stm;
            }
            set
            {
                if (stamina.stm > stamina.maxStm)
                {
                    stamina.stm = stamina.maxStm;
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
        public int MaxStamina
        {
            get
            {
                return stamina.maxStm;
            }
            set
            {
                if (stamina.maxStm <= 0)
                {
                    throw new Exception("Максимальная выносливость не может быть меньше либо равна нулю");
                }
                else
                {
                    stamina.maxStm = value;
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
