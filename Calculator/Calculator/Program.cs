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
            double ans = 0;
            while (true)
            {
                string whichFunction = "";
                while (!IfInt(whichFunction))
                {
                    Console.WriteLine("zadej typ operace: 1. Kalkulačka, 2. Photomath(pouze sčítání, odčítání), 3. Různé věci, na vytáhnutí známky kdybych měl HODNĚ špatný coding style");
                    whichFunction = Console.ReadLine();
                }
                switch (whichFunction)
                {
                    case "1":
                        Calculator();
                        break;
                    case "equation": // work in progress
                        EquationFunction();
                        break;
                    case "2":
                        Photomath();
                        break;
                    case "3":
                        string whichFunction2 = "";
                        while (!IfInt(whichFunction2))
                        {
                            Console.WriteLine("na výběr: 1. binární kalkulačka, 2. faktoriál, 3. fibonacciho posloupnost");
                            whichFunction2 = Console.ReadLine();

                        }
                        switch (whichFunction2)
                        {
                            case "1":
                                string binary = BinaryCalculator();
                                Console.WriteLine(binary);
                                break;
                            case "2":
                                string inputFactorial = "";
                                while (!IfInt(inputFactorial))
                                {
                                    Console.WriteLine("zadej přirozené číslo, jehož faktorial chceš vědět");
                                    inputFactorial = Console.ReadLine();
                                }
                                int factorial = FactorialCalculator(int.Parse(inputFactorial));
                                Console.WriteLine("faktorial čísla " + inputFactorial + " je " + factorial);
                                break;
                            case "3":
                                string inputFibonacci = "";
                                while (!IfInt(inputFibonacci))
                                {
                                    Console.WriteLine("zadej přirozené číslo jehož prvek fibonacciho posloupnosti chceš vědět");
                                    inputFibonacci = Console.ReadLine();
                                }
                                int fibonacci = FibonacciCalculator(int.Parse(inputFibonacci));
                                Console.WriteLine("pro číslo " + inputFibonacci + " je prvek fibonacciho posloupnosti " + fibonacci);
                                break;
                        }
                        break;
                }
            }
            
            void Calculator()  // základní zadání kalkulačky s ans, proměnnou x 
            {
                Console.WriteLine("pro použití minulého výsledku zadej ans při zadávání čísla");
                while (true)
                {
                    string operation = "";
                    double x = InputToNumber();
                    Console.WriteLine("první číslo: " + x);
                    double y = InputToNumber();
                    Console.WriteLine("druhé číslo: " + y);
                    double result = 0;
                    while (operation != "+" && operation != "-" && operation != "*" && operation != "/") // kontrola jestli je to platná operace
                    {
                        Console.WriteLine("zadej operaci +;-;*;/");
                        operation = Console.ReadLine();
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
                        break; // jakýkoliv input vrátí uživatle na začátek
                    }
                    
                }

            }
            string CalculatorVariable() 
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
                return variable;
            }// neznámá v kalkulačce
            double InputToNumber()
            {
                string input = "";
                while (!double.TryParse(input, out double result1) && input != "ans" && input != "x") // kontrola platného inputu
                {
                    Console.WriteLine("zadej platné číslo, ans, či proměnnou x");
                    input = Console.ReadLine();
                }
                if (input == "x") // zavedení proměnné
                {
                    input = CalculatorVariable();
                }
                else if (input =="ans") // použití minulého výsledku
                {
                    input = ans.ToString();
                }
                return double.Parse(input);
            }
            void Photomath()
            { while (true)
                {
                    Console.WriteLine("zadej příklad");
                    string input = Console.ReadLine();
                    int signum = 1;
                    string number = "0";
                    int result = 0;
                    if (input.IndexOf("x") != -1)
                    {
                        EquationFunction(); // ještě nefungujeeeeeeeeeeee
                    }
                    else if (input.IndexOf("*") != -1)
                    {
                        input = PhotomathEdit(input);
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
                
            }//nedodělaný, zatím umí jenom sčítat, odčítat
            void EquationFunction()
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
            string PhotomathEdit(string input)
            {
                List<char> listEdit = new List<char>(input);
                Console.WriteLine(listEdit[2]);
                listEdit[2] = 'y';
                input = new string(listEdit.ToArray());
                Console.WriteLine(input);
                return input;
            }// work in progress zzzz
            string BinaryCalculator()
            {
                string remainder = "";
                string input = "";
                while (!IfInt(input))
                {
                    Console.WriteLine("zadej decimární číslo, které chceš převést do binární soustavy");
                    input = Console.ReadLine();
                }
                int binary = int.Parse(input);
                while (binary > 0) // způsob jsem našel v komentáři https://www.khanacademy.org/math/algebra-home/alg-intro-to-algebra/algebra-alternate-number-bases/v/large-number-decimal-to-binary
                {
                    if (binary % 2 == 0)
                    {
                        remainder += "0";
                    }
                    else
                    {
                        remainder += "1";
                    }
                    binary = binary / 2;
                }
                remainder.Reverse();
                return remainder;

            }
            int FactorialCalculator(int n)
            {
                if (n ==1)
                {
                    return 1;
                }
                int nFactorial = n * FactorialCalculator(n-1);
                return nFactorial;

            }
            int FibonacciCalculator(int n)
            {
                if (n==0)
                {
                    return 0;
                }
                if (n==1)
                {
                    return 1;
                }
                int nFibonacci = FibonacciCalculator(n-1) + FibonacciCalculator(n-2);
                return nFibonacci;
            }
            bool IfInt(string input)
            {
                if (int.TryParse(input, out int result))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }// kontrola jestli int

        } 

    }
}
