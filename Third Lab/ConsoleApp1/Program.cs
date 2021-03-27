using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Gender
    {
        Male,
        Female
    }
    class Person
    {
        protected int age;
        protected string name;
        protected string surname;
        protected Gender gender;
        protected static int nextID = 0;
        public int ID { get; private set; }
        public Person() { }
        public Person(int _age, string _name, string _surname, Gender _gender)
        {
            ID = ++nextID;
            age = _age;
            name = _name;
            surname = _surname;
            gender = _gender;
        }
        public Person(ref Person A)
        {
            ID = ++nextID;
            age = A.age;
            name = A.name;
            surname = A.surname;
            gender = A.gender;
        }
        ~Person()
        {
            Console.WriteLine("Сработал деструктор");
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
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
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
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
        public static bool operator ==(Person A, Person B)
        {
            return (A.age == B.age && A.name == B.name && A.surname == B.surname && A.gender == B.gender);
        }
        public static bool operator !=(Person A, Person B)
        {
            return !(A == B);
        }
    }
    class Student : Person
    {


    }

    
    class Program: Person
    {
        static void Main(string[] args)
        {
            Person FirstObject = new Person(17, "Kirill", "Yuzefovich", Gender.Male);
            Person SecondObject = new Person(ref FirstObject);
            Person ThirdObject = new Person(54, "Valerii", "Jmishenko", Gender.Male);
            Console.WriteLine("First Object: \nВозраст: {0}\nИмя: {1}\nФамилия: {2}\nПол: {3}\n", FirstObject.Age,FirstObject.Name, FirstObject.Surname, FirstObject.Ggender);
            Console.WriteLine("FirstObject == SecondObject - {0}", FirstObject == SecondObject);
            Console.WriteLine("SecondObject == ThirdObject - {0}", SecondObject == ThirdObject);
            Console.WriteLine("FirstObject == ThirdObject - {0}", FirstObject == ThirdObject);
            Console.WriteLine("FirstObject ID = {0}, SecondObject ID = {1}, ThirdObjectID = {2}", FirstObject.ID, SecondObject.ID, ThirdObject.ID);
            Console.ReadKey();
        }
    }
}
