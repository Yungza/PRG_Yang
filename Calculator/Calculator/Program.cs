using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Console.WriteLine("zadej typ operace: commonOperation, equation, advancedCalculator");
            string whichFunction = "advancedCalculator";
            switch (whichFunction)
            {
                case "commonOperation":
                    commonOperation();
                    break;
                case "equation":
                    equationFunction();
                    break;
                case "advancedCalculator":
                    advancedCalculator();
                    break;
            }
            void commonOperation()
            {
                string konec = "";
                double ans = 0;
                while (konec != "ne")
                {
                    konec = "";
                    string input1 = "";
                    string input2 = "";
                    string operation = "";
                    double x = 0;
                    double y = 0;
                    double result = 0;
                    while (!double.TryParse(input1, out double result1) && input1 != "ans") // kontrola jestli je to číslo
                    {
                        Console.WriteLine("zadej platné číslo x");
                        input1 = Console.ReadLine();
                    }
                    while (!double.TryParse(input2, out double result1) && input2 != "ans") // kontrola jestli je to číslo
                    {
                        Console.WriteLine("zadej platné číslo y");
                        input2 = Console.ReadLine();
                    }
                    while (operation != "+" && operation != "-" && operation != "*" && operation != "/") // kontrola jestli je to platná operace
                    {
                        Console.WriteLine("zadej operaci +;-;*;/");
                        operation = Console.ReadLine();
                    }
                    if (input1 == "ans") // použití výsledku z minulého počítání, nebo nová hodnota
                    {
                        x = ans;
                    }
                    else
                    {
                        x = Convert.ToDouble(input1);
                    }
                    if (input2 == "ans")
                    {
                        x = ans;
                    }
                    else
                    {
                        y = Convert.ToDouble(input2);
                    }

                    switch (operation)
                    {
                        case "+":
                            result = x + y;
                            break;

                        case "-":
                            result = x - y;
                            break;

                        case "*":
                            result = x * y;
                            break;

                        case "/":
                            result = x / y;
                            break;
                    }
                    Console.WriteLine(x + operation + y + "=" + result);
                    ans = result;
                    while (konec != "ano" && konec != "ne") 
                    {
                        Console.WriteLine("Chceš pokračovat? Zadej ano/ne"); 
                        konec = Console.ReadLine();
                    }

                }


            } // základní zadání kalklačky s ans
            void equationFunction()
            // zatím funguje jenom sčítání a odčítání, je tomu fuk jestli tam neznámou vůbec má lol
            {while (true)
                {
                    Console.WriteLine("Zadej jednoduchou rovnici");
                    string equation = Console.ReadLine() + "_"; // přídává se to aby to ukončilo if na pravo od =
                    int orderOfEqual = equation.IndexOf('=');
                    int lengthOfEquation = equation.Length;
                    double variable = 0;
                    string x = "0";
                    int signum = 0;
                    for (int i = 0; i < equation.Length; i++)
                    {
                        switch (equation[i])
                        {
                            case '+':
                                signum = 1;
                                break;
                            case '-':
                                signum = -1;
                                break;
                        }

                        if (i <= orderOfEqual) // pokud je to na stejné straně jako neznámá tak se musí operace otoči
                        {
                            if (Int32.TryParse(equation[i].ToString(), out int result)) 
                            {
                                x += equation[i]; // kvůli více čiferným číslům
                            }
                            else
                            {
                                variable = variable - (Int32.Parse(x) * signum); // pokud to narazí na znaménko tak započítá to číslo předtím do výsledku
                                x = "0";
                            }
                        }
                        if (i > orderOfEqual)
                        {
                            if (Int32.TryParse(equation[i].ToString(), out int result))
                            {
                                x += equation[i];
                            }
                            else
                            {
                                variable = variable + (Int32.Parse(x) * signum);
                                x = "0";
                            }

                        }
                        if (i == orderOfEqual) // pokud je poslední číslo napravo záporný tak se to neotočí
                        {
                            signum = 1;
                        }
                    }
                    Console.WriteLine("x = " + variable);
                }
                

            } // rovnice, zatím moc nefunguje lol
            void advancedCalculator() // počítání s proměnnou, není limitovaná na 2 čísla (work in progress lol)
                {
                double result = 0;
                int signum = 1;
                while (true)
                {
                    Console.WriteLine("aaaaaa");
                    string input = Console.ReadLine();
                    if (!double.TryParse(input, out double result1))
                    {
                        switch (input)
                        {
                            case "-":
                                signum = -1;
                                break;
                            case "=":
                                Console.WriteLine("výsledek je " + result);
                                break;
                            case "+":
                                signum = 1;
                                break;


                        }
                    }
                    else
                    {
                        result += double.Parse(input) * signum;
                    }


                }
            }
            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        } 

    }
}
