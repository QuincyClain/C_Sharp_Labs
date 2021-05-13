using System;
using System.Collections.Generic;
using System.Text;

namespace WW
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
    public interface ILvl
    {

        void LvLUp(int a);
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
}
