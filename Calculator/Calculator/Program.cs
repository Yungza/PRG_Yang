using System;
using System.Collections.Generic;
using System.IO.Pipes;
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
            Console.WriteLine("zadej typ operace: commonOperation; equation");
            string whichFunction = Console.ReadLine();
            switch (whichFunction)
            {
                case "commonOperation":
                    commonOperation();
                    break;
                case "equation":
                    equationFunction();
                    break;
            }
            void commonOperation()
            {
                string konec = "";
                double ans = 0;
                while (konec != "ne")
                {
                    konec = "";
                    string Input1 = "";
                    string Input2 = "";
                    string operation = "";
                    double x = 0;
                    double y = 0;
                    double Result = 0;
                    while (!double.TryParse(Input1, out double result) && Input1 != "ans") // kontrola jestli je to číslo
                    {
                        Console.WriteLine("zadej platné číslo x");
                        Input1 = Console.ReadLine();
                    }
                    while (!double.TryParse(Input2, out double result) && Input2 != "ans") // kontrola jestli je to číslo
                    {
                        Console.WriteLine("zadej platné číslo y");
                        Input2 = Console.ReadLine();
                    }
                    while (operation != "+" && operation != "-" && operation != "*" && operation != "/") // kontrola jestli je to platná operace
                    {
                        Console.WriteLine("zadej operaci +;-;*;/");
                        operation = Console.ReadLine();
                    }
                    if (Input1 == "ans")
                    {
                        x = ans;
                    }
                    else
                    {
                        x = Convert.ToDouble(Input1);
                    }
                    if (Input2 == "ans")
                    {
                        x = ans;
                    }
                    else
                    {
                        y = Convert.ToDouble(Input2);
                    }

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
                    ans = Result;

                    while (konec != "ano" && konec != "ne")
                    {
                        Console.WriteLine("Chceš pokračovat? Zadej ano/ne");
                        konec = Console.ReadLine();
                    }

                }


            }
            void equationFunction()
            {
                Console.WriteLine("Zadej jednoduchou rovnici");
                string equation = Console.ReadLine();
                int orderOfEqual = equation.IndexOf('=');
                int lengthOfEquation = equation.Length;
                int variable = 0;
                for (int i = 0; i < equation.Length; i++)
                {
                    if (i < orderOfEqual)
                    {
                        if (Int32.TryParse(equation[i].ToString(), out int result))
                        {
                            variable = variable - Int32.Parse(equation[i].ToString());
                        }
                    }
                    else if (i > orderOfEqual)
                    {
                        if (Int32.TryParse(equation[i].ToString(), out int result))
                        {
                            variable = variable + Int32.Parse(equation[i].ToString());
                        }
                    }
                }
                Console.WriteLine("x = "+ variable);

            }
            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        } 

    }
}
