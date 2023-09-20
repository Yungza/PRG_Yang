using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string konec = "";
            while (konec != "ne")
            {
                konec = "";
                string Input1 = "";
                string Input2= "";
                string operation = "";
                while (!double.TryParse(Input1,out double result)) // kontrola jestli je to číslo
                {
                    Console.WriteLine("zadej platné číslo x");
                    Input1 = Console.ReadLine();
                }
                while (!double.TryParse(Input2,out double result))
                {
                    Console.WriteLine("zadej platné číslo y");
                    Input2 = Console.ReadLine();
                }
                while (operation != "+" && operation!= "-" && operation != "*" && operation != "/") // kontrola jestli je to platná operace
                {   Console.WriteLine("zadej operaci +;-;*;/");
                    operation = Console.ReadLine(); 
                }
                double x = Convert.ToDouble(Input1);
                double y = Convert.ToDouble(Input2);
                double Result = 0;
                switch (operation)
                {
                    case "+":
                        Result = x + y;
                        break;

                    case "-":
                        Result = x - y;
                        break;

                    case "*":
                        Result = x * y;
                        break;

                    case "/":
                        Result = x / y;
                    break;
                }
                Console.WriteLine(x + operation + y + "=" + Result);
                while (konec!= "ano"&& konec!= "ne")
                {
                    Console.WriteLine("Chceš pokračovat? Zadej ano/ne");
                    konec= Console.ReadLine();
                }
                 
               
            }
            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
