using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
            string variable = "0";
            Console.WriteLine("zadej typ operace: commonOperation, photomath");
            string whichFunction = "photomath";
            switch (whichFunction)
            {
                case "commonOperation":
                    commonOperation();
                    break;
                case "equation":
                    equationFunction();
                    break;
                case "photomath":
                    photomath();
                    break;
            }
            void commonOperation()  // základní zadání kalkulačky s ans, proměnnou x 
            {
                Console.WriteLine("pro použití minulého výsledku zadej ans při zadávání čísla");
                double ans = 0;
                while (true)
                {
                    string input1 = "";
                    string input2 = "";
                    string operation = "";
                    double x = 0;
                    double y = 0;
                    double result = 0;
                    while (!double.TryParse(input1, out double result1) && input1 != "ans" && input1 != "x") // kontrola jestli je to platný input
                    {
                        Console.WriteLine("zadej platné číslo x");
                        input1 = Console.ReadLine();
                        if (input1=="x")
                        {
                            input1 = calculatorVariable();
                        }
                    }
                    while (!double.TryParse(input2, out double result1) && input2 != "ans"&& input2 != "x") // kontrola jestli je to číslo/ans
                    {
                        Console.WriteLine("zadej platné číslo y");
                        input2 = Console.ReadLine();
                        if (input2 == "x")
                        {
                            input2 = calculatorVariable();
                        }
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
                        y = ans;
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
                    Console.WriteLine("pro ukončení programu napiš libovolný text, v opačném případě zmáčkni pouze enter");
                    if (Console.ReadLine()!= "")
                    {
                        break;
                    }
                    
                }

                string calculatorVariable() // počítání s proměnnou
                {
                    string input = "";
                    if (variable == "0")
                    {
                        while (!double.TryParse(input, out double result1))
                        {
                            Console.WriteLine("Zadej hodnotu neznámé");
                            input = Console.ReadLine();
                        }
                        variable = input;
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                    return variable;
                }
            }
            void photomath() // lze zadat celý příklad
            { while (true)
                {
                    Console.WriteLine("zadej příklad");
                    string input = Console.ReadLine();
                    int signum = 1;
                    string number = "0";
                    int result = 0;
                    if (input.IndexOf("x") != -1)
                    {
                        equationFunction(); // ještě nefungujeeeeeeeeeeee
                    }
                    else if (input.IndexOf("*") != -1)
                    {
                        input = photomathEdit(input);
                    }
                    else
                    {
                        input = "_" + input + "_";
                        for (int i = 1; i < input.Length; i++)
                        {
                            switch (input[i - 1])
                            {
                                case '+':
                                    signum = signum * 1;
                                    break;
                                case '-':
                                    signum = signum * -1;
                                    break;
                            }
                            if (int.TryParse(input[i].ToString(), out int result1))
                            {
                                number += input[i];
                            }
                            else
                            {
                                result = result + int.Parse(number) * signum;
                                number = "0";
                                signum = 1;
                            }
                        }
                    }
                    Console.WriteLine(result);
                    Console.WriteLine("pro ukončení programu napiš libovolný text, v opačném případě zmáčkni pouze enter");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                
            }
            void equationFunction()
            // zatím funguje jenom sčítání a odčítání, je tomu fuk jestli tam neznámou vůbec má lol
            {
                while (true)
                {
                    Console.WriteLine("Zadej jednoduchou rovnici");
                    string equation = Console.ReadLine() + "_"; // přídává se to aby to ukončilo if na pravo od =
                    int orderOfEqual = equation.IndexOf('=');
                    int lengthOfEquation = equation.Length;
                    double variableX = 0;
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
                                variableX = variableX - (Int32.Parse(x) * signum); // pokud to narazí na znaménko tak započítá to číslo předtím do výsledku
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
                                variableX = variableX + (Int32.Parse(x) * signum);
                                x = "0";
                            }

                        }
                        if (i == orderOfEqual) // krajní hodnota
                        {
                            signum = 1;
                        }
                    }
                    Console.WriteLine("x = " + variableX);
                }


            } // rovnice, zatím moc nefunguje lol
            string photomathEdit(string input)
            {
                List<char> listEdit = new List<char>(input);
                Console.WriteLine(listEdit[2]);
                listEdit[2] = 'y';
                input = new string(listEdit.ToArray());
                Console.WriteLine(input);
                return input;
            }

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        } 

    }
}
