using System;
using System.Collections.Generic;
using System.Text;

namespace WW
{
    using WW;
    class Mage : Character, ILvl
    {

        protected int lvl;
        protected int mana;
        protected int maxmana;
        public Mage() { }
        public Mage(int _age, Race _race, string _name, Gender _gender, int _mana, int _maxMana, int _lvl)
        {
            ID = ++nextID;

            age = _age;
            name = _name;
            gender = _gender;
            race = _race;
            mana = _mana;
            maxmana = _maxMana;
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
        public int Lvl
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
}

