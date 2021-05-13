using System;
using System.Collections.Generic;
using System.Text;

namespace WW
{
    using WW;
    class Mage : Character, ILvl
    {
        protected int Level;
        protected int ManaPool;
        protected int MaxManaPool;
        public Mage() { }
        public Mage(int _age, Race _race, string _name, Gender _gender, int _mana, int _maxMana, int _lvl)
        {
            ID = ++nextID;

            age = _age;
            name = _name;
            gender = _gender;
            race = _race;
            ManaPool = _mana;
            MaxManaPool = _maxMana;
            Level = _lvl;
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
                throw new Exception("Уровень не может быть меньше первого");
            }

        }
        public Mage(ref Mage x)
        {
            age = x.age;
            name = x.name;
            gender = x.gender;
            race = x.race;
            ManaPool = x.ManaPool;
            MaxManaPool = x.MaxManaPool;
            Level = x.Level;
        }

        public void LvLUp(int a)
        {
            Console.WriteLine("Маг {0} повысил уровень с {1} до {2}\n", name, Level, Level + a);
            Console.WriteLine("Максимальная мана выросла с {0} до {1}", MaxManaPool, MaxManaPool + 20 * a);
            Console.WriteLine("Мана выросла с {0} до {1}", ManaPool, ManaPool + 20 * a);
            Level += a;
            MaxManaPool += 20 * a;
            ManaPool += 20 * a;
        }
        public virtual void ChangeAge(int a)
        {
            if ((age - a) < 1)
            {
                throw new Exception("Нельзя больше уменьшить возраст");
            }
            if (ManaPool < a * 20)
            {
                throw new Exception("Не хватает маны для способности ChangeAge");
            }
            age -= a;
            ManaPool -= a * 2;
        }
        public int Mana
        {
            get
            {
                return ManaPool;
            }
            set
            {
                if (ManaPool > MaxMana)
                {
                    ManaPool = MaxMana;
                }
                else if (ManaPool < 0)
                {
                    throw new Exception("Мана не может быть меньше нуля");
                }
                else
                {
                    ManaPool = value;
                }
            }
        }
        public int MaxMana
        {
            get
            {
                return MaxManaPool;
            }
            set
            {
                if (MaxManaPool <= 0)
                {
                    throw new Exception("Максимальная мана не может быть меньше либо равна нулю");
                }
                else
                {
                    MaxManaPool = value;
                }
            }
        }
        public int Lvl
        {
            get
            {
                return Level;
            }
            set
            {
                if (Level < 1)
                {
                    throw new Exception("Минимальный уровень - 1");
                }
                else
                {
                    Level = value;
                }
            }
        }
    }
}

