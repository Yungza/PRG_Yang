using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        class Human
        {
            public int age;
            public int heigth;
            public int weight;
            public string name;
            public string skinColor;
            public Human partner;

            public Human(int age, int heigth, int weight, string name)
            {
                this.age = age;
                this.heigth = heigth;
                this.weight = weight;
                this.name = name;
            }

            public Human()
            {

            }
            public void IntroduceHuman()
            {
                Console.WriteLine($"jmenuju se {name}, je mi {age}, měřím {heigth} a vážím {weight}");
            }
            public Human(int age)
            {
                this.age = age;
            }// zbytek ručně nebo vůbec
            public Human(string name)
            {
                this.name = name;
            }
            public float BodyMassIndex()
            {
                float heigthBMI = heigth / 100f;
                float BMI = weight / (heigthBMI*heigthBMI);
                return BMI;
            }
            public static Human MakeChild(Human human1, Human human2)
            {
                if(human1.partner == human2 && human2.partner == human1)
                {
                    Human child = new Human();
                    child.age = 0;
                    child.heigth = (human1.heigth + human2.heigth)/2;
                    child.weight = (human1.weight + human2.weight)/2;
                    child.name = human1.name + " " + human2.name;
                    child.partner = null;
                    return child;
                }
                else
                {
                    Console.WriteLine("někdo zahýbá ig");
                    return new Human("bastard");
                }
            }
            public Human MakeChildWith(Human human2)
            {
                if (partner == human2)
                {
                    Human child = new Human();
                    child.age = 0;
                    child.heigth = (heigth + human2.heigth) / 2;
                    child.weight = (weight + human2.weight) / 2;
                    child.name = name + " " + human2.name;
                    child.partner = null;
                    return child;
                }
                else
                {
                    Console.WriteLine("někdo podvádí haaa");
                    return new Human("bastard");
                }
            }
        }
        static void Main(string[] args)
        {
            Human human1 = new Human();
            human1.age = 32;
            human1.heigth = 180;
            human1.weight = 80;
            human1.name = "Lojza";
            human1.IntroduceHuman();

            Human human2 = new Human(18, 10, 999, "Filip");
            human2.skinColor = "růžová";
            human2.IntroduceHuman();
            Console.WriteLine($"{human2.name} má {human2.skinColor} pleť");
            float bmi = human2.BodyMassIndex();
            Console.WriteLine($"{human2.name} má BMI {bmi}");
            
            human1.partner = human2;
            human2.partner = human1;
            Human newChild = Human.MakeChild( human1, human2);
            newChild.IntroduceHuman();

            Human newerChild = human2.MakeChildWith(human1);
            newerChild.IntroduceHuman();
            Console.WriteLine(newerChild.BodyMassIndex());
            Console.ReadKey();
        }
    }
}
