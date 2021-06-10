using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SApp01
{

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

    }

    class PersonV2 : IComparable<PersonV2>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public PersonV2(string name, int age)
        {
            Name = name;
            Age = age;
            
        }

        public int CompareTo(PersonV2 other)
        {
            return string.Compare( Name, other.Name);
        }

    }

    class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return y.Age - x.Age ;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var persons = new Person[]
            {
                new Person("Дима", 26),
                new Person("Маша", 22),
                new Person("Света", 34),
                new Person("Ваня", 31),
                new Person("Андрей", 18)
            };

            Array.Sort(persons, new AgeComparer());

            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine($"{persons[i].Name} - {persons[i].Age}");

            }

            Console.ReadLine();
            Console.WriteLine();

            var personsV2 = new PersonV2[]
            {
                new PersonV2("Маша", 26),
                new PersonV2("Даша", 22),
                new PersonV2("Петя", 34),
                new PersonV2("Ваня", 31),
                new PersonV2("Света", 18)
            };

            Array.Sort(personsV2);

            for (int i = 0; i < personsV2.Length; i++)
            {
                Console.WriteLine($"{personsV2[i].Name} - {personsV2[i].Age}");

                
            }

            Console.ReadLine();

        }
    }
}
