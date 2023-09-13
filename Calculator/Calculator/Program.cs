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
            string Input1 = "";
            string Input2= "";
            string operation = "";
            while (!double.TryParse(Input1,out double result)) // způsob, jak zkontrolovat zda je input double jsem si musel dohledat pomocí ChatGPT
            {
                Console.WriteLine("zadej platné číslo x");
                Input1 = Console.ReadLine();
            }
            while (!double.TryParse(Input2,out double result))
            {
                Console.WriteLine("zadej platné číslo y");
                Input2 = Console.ReadLine();
            }
            while (operation != "+" && operation!= "-")
            {   Console.WriteLine("zadej operaci +/-");
                operation = Console.ReadLine(); 
            }
            double x = Convert.ToDouble(Input1);
            double y = Convert.ToDouble(Input2);
            double Result = 0;
            if (operation == "-")
            {
                Result = x - y;
                Console.WriteLine(x + operation + y + "=" + Result);
            }
            else
            {
                Result = x + y;
                Console.WriteLine(x + operation + y + "=" + Result);
            }

                Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
