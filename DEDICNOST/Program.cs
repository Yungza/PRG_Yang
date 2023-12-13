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

            public void MakeNoise()
            {
                Console.WriteLine("*animal noises*");
            }
        }
        class Dog : Animal
        {
            public string race;
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

            Console.ReadKey();
        }
    }
}
