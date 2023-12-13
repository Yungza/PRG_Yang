using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEDICNOST
{
    internal class Program
    {
        class Animal
        {
            public string name;
            public string maxAge;

            public virtual void MakeNoise()
            {
                Console.WriteLine("*animal noises*");
            }
        }
        class Dog : Animal
        {
            public string race;
            public override void MakeNoise()
            {
                Console.WriteLine("woof woof");
            }
        }
        class Cat : Animal
        {
            public string furColor;
            public override void MakeNoise()
            {
                Console.WriteLine("meow meow");
            }
        }
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.MakeNoise();

            Dog dog = new Dog();
            dog.name = "Filip";
            dog.maxAge = "12";
            dog.race = "běloch";

            Console.WriteLine($"{dog.name} is {dog.maxAge} y/o and is {dog.race}");
            dog.MakeNoise();

            Cat cat = new Cat();
            cat.name = "Micka";
            cat.maxAge = "12";
            cat.furColor = "brown";
            Console.WriteLine($"{cat.name} is {cat.maxAge} y/o and is {cat.furColor}");
            cat.MakeNoise();

            Console.ReadKey();
        }
    }
}
