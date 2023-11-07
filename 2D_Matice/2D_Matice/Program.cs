using System;
using System.Reflection;

namespace _2D_Matice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] initialArray = new int[InputInt("počtu řádků"), InputInt("počtu sloupců")];
            int[,] workArray = initialArray;
            FillArray(initialArray);
            PrintArray(workArray);
            while (true)
            {
                Console.WriteLine("operace k dispozici:");
                Console.WriteLine("0. resetování matice");
                Console.WriteLine("1. prohazování");
                Console.WriteLine("2. operace");
                Console.WriteLine("3. sčítání/odčítání dvou matic");
                Console.WriteLine("4. transpozice matice");
                Console.WriteLine("5. násobení matice");
                string input = LimitInput(0, 5, "operace").ToString();
                string input2 = "";
                switch (input)
                {
                    case "0":
                        workArray = initialArray;
                        PrintArray(workArray);
                        break;
                    case "1":
                        Console.WriteLine("k dispozici:");
                        Console.WriteLine("1. prohazování náhodných prvků");
                        Console.WriteLine("2. prohazování řádků");
                        Console.WriteLine("3. prohazování sloupců");
                        Console.WriteLine("4. prohazování pořadí prvků na hlavní dagonále");
                        Console.WriteLine("5. prohazování pořadí prvků na vedlejší diagonále");
                        input2 = LimitInput(1, 5, "specifikované operace").ToString();
                        switch (input2)
                        {
                            case "1":
                                ElementSwap(workArray);
                                break;
                            case "2":
                                RowSwap(workArray);
                                break;
                            case "3":
                                ColSwap(workArray);
                                break;
                            case "4":
                                MainDiagSwap(workArray);
                                break;
                            case "5":
                                NotMainDiagSwap(workArray);
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("k dispozici:");
                        Console.WriteLine("1. násobení celé matice číslem");
                        Console.WriteLine("2. násobení konkrétního řádku");
                        Console.WriteLine("3. násobení konkrétního sloupce");
                        input2 = LimitInput(1, 3, "specifikované operace").ToString();
                        switch (input2)
                        {
                            case "1":
                                MatrixMultiplication(InputInt("čísla, kterým chceš vynásobit matici"), workArray);
                                break;
                            case "2":
                                RowMultiplication(LimitInput(0, workArray.GetLength(0)-1, "řádku, který chceš chceš násobit"), InputInt("čísla, kterým chceš násobit"), workArray);
                                break;
                            case "3":
                                ColMultiplication(LimitInput(0, workArray.GetLength(1) - 1, "sloupce, který chceš chceš násobit"), InputInt("čísla, kterým chceš násobit"), workArray);
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("1. sčítání");
                        Console.WriteLine("2. odčítání");
                        input2 = LimitInput(1, 2, "specifikované operace").ToString();
                        switch(input2)
                        {
                            case "1":
                                MatrixAddition(workArray);
                                break;
                            case "2":
                                MatrixSubstraction(workArray);
                                break;
                        }
                        break;
                    case "4":
                        workArray = MatrixTransposition(workArray);
                        break;
                    case "5":
                        MatrixTheFinalAssignment(workArray);
                        break;
                }
            }
        }
        static int InputInt(string variableName)
        {
            string input = "";
            while (!int.TryParse(input, out int result))
            {
                Console.WriteLine($"zadej platnou hodnotu {variableName}");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }//navrací int input
        static int LimitInput(int lower, int upper, string message)
        {
            int input = 100;
            while (lower > input || input > upper)
            {
                Console.WriteLine($"zadej číslo v rozmezí {lower}-{upper}");
                input = InputInt(message);
            }
            return input;
        }//limitovaný input
        static void FillArray(int[,] array)
        {
            Random rnd = new Random();
            int lastNumber = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = lastNumber + rnd.Next(1, 10);
                    lastNumber = array[i, j];
                }
            }
        }// naplní matici rostoucími čísly
        static void PrintArray(int[,] array)
        {
            int space;
            int max = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                    }
                }
            }
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
            Console.WriteLine("aktuální matice:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    space = max.ToString().Length - array[i, j].ToString().Length;
                    Console.Write(array[i, j] + " ");
                    for (int k = 0; k < space; k++)
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("_ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ _ ");
        }//vypíše každý prvek matice
        static void ElementSwap(int[,] array)
        {
            Random rnd = new Random();
            int xFirst = rnd.Next(0, array.GetLength(0));
            int xSecond = rnd.Next(0, array.GetLength(0));
            int yFirst = rnd.Next(0, array.GetLength(1));
            int ySecond = rnd.Next(0, array.GetLength(1));
            int remember = array[xSecond, ySecond];
            Console.WriteLine($"budu měnit prvek se souřadnicemi x = {yFirst}, y = {xFirst} s prvkem: {ySecond}, {xSecond}");
            array[xSecond, ySecond] = array[xFirst, yFirst];
            array[xFirst, yFirst] = remember;
            PrintArray(array);
        }//prohazování náhodných prvků
        static void RowSwap(int[,] array)
        {
            Console.WriteLine($"zadej dva řádky jenž chceš prohodit");
            int firstRow = LimitInput(0, array.GetLength(0) - 1, "prvního řádku");
            int secondRow = LimitInput(0, array.GetLength(0) - 1, "druhého řádku");
            int[] remember = new int[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                remember[i] = array[firstRow, i];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[firstRow, i] = array[secondRow, i];
                array[secondRow, i] = remember[i];
            }
            PrintArray(array);
        }//prohazování řádků
        static void ColSwap(int[,] array)
        {
            Console.WriteLine($"zadej dva sloupce jenž chceš prohodit");
            int firstColumm = LimitInput(0, array.GetLength(1) - 1, "prvního řádku");
            int secondColumn = LimitInput(0, array.GetLength(1) - 1, "druhého řádku");
            int[] remember = new int[array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                remember[i] = array[i, firstColumm];
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, firstColumm] = array[i, secondColumn];
                array[i, secondColumn] = remember[i];
            }
            PrintArray(array);
        }//prohazování sloupců
        static void MainDiagSwap(int[,] array)
        {
            int remember;
            if (array.GetLength(0) <= array.GetLength(1))
            {
                for (int i = 0; i < (array.GetLength(0) - 1) / 2 + 1; i++)
                {
                    remember = array[i, i];
                    array[i, i] = array[array.GetLength(0) - i - 1, array.GetLength(0) - i - 1];
                    array[array.GetLength(0) - i - 1, array.GetLength(0) - i - 1] = remember;
                }
                PrintArray(array);
            }
            else
            {
                for (int i = 0; i < (array.GetLength(1) - 1) / 2 + 1; i++)
                {
                    remember = array[i, i];
                    array[i, i] = array[array.GetLength(1) - i - 1, array.GetLength(1) - i - 1];
                    array[array.GetLength(1) - i - 1, array.GetLength(1) - i - 1] = remember;
                }
                PrintArray(array);
            }
        }//hlavní diagonála
        static void NotMainDiagSwap(int[,] array)
        {// tohle bylo giga pain vymýšlet lol
            int remember;
            if (array.GetLength(0) <= array.GetLength(1))
            {
                for (int i = 0; i < (array.GetLength(0) - 1) / 2 + 1; i++)
                {
                    remember = array[i, array.GetLength(1) - 1 - i];
                    array[i, array.GetLength(1) - 1 - i] = array[array.GetLength(0) - 1 - i, array.GetLength(1) - array.GetLength(0) + i];
                    array[array.GetLength(0) - i - 1, array.GetLength(1) - array.GetLength(0) + i] = remember;
                }
                PrintArray(array);
            }
            else
            {
                for (int i = 0; i < (array.GetLength(1) - 1) / 2 + 1; i++)
                {
                    remember = array[i, array.GetLength(1) - 1 - i];
                    array[i, array.GetLength(1) - 1 - i] = array[array.GetLength(1) - 1 - i, i];
                    array[array.GetLength(1) - 1 - i, i] = remember;
                }
                PrintArray(array);
            }
        }//vedlejší diagonála
        static void MatrixMultiplication(int input, int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] *= input;
                }
            }
            PrintArray(array);
        }//násobení matice číslem
        static void RowMultiplication(int row, int input, int[,] array)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[row, i] *= input;
            }
            PrintArray(array);
        }//násobení konkrétního řádku
        static void ColMultiplication(int column, int input, int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                array[i, column] *= input;
            }
            PrintArray(array);
        }//násobení konkrétního sloupce
        static void MatrixAddition(int[,] array)
        {
            int[,] secondArray = new int[array.GetLength(0),array.GetLength(1)];
            Console.WriteLine("matice, se kterou se bude sčítat původní:");
            FillArray(secondArray);
            PrintArray(secondArray);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] += secondArray[i,j];
                }
            }
            PrintArray(array);
        }//sčítání dvou matic
        static void MatrixSubstraction(int[,] array)
        {
            int[,] secondArray = new int[array.GetLength(0), array.GetLength(1)];
            Console.WriteLine("matice, se kterou se bude sčítat původní:");
            FillArray(secondArray);
            PrintArray(secondArray);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] -= secondArray[i, j];
                }
            }
            PrintArray(array);
        }//odčítání 2 matic
        static int[,] MatrixTransposition(int[,] array)
        {
            int[,] secondArray = new int[array.GetLength(1), array.GetLength(0)]; // vytvořím matici s převrávenými paramatry, flipnu jejich indexy
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++) 
                {
                    secondArray[j,i] = array[i, j];
                }
            }
            PrintArray(secondArray);
            return secondArray;
        }//transpozice matice
        static void MatrixTheFinalAssignment(int[,] array)
        {
            int[,] multiplyArray = new int[array.GetLength(1), InputInt("počtu sloupců jímž chceš násobit")]; //počet řádků v druhé matici se musí rovnat počtu sloupců první matice
            FillArray(multiplyArray);
            PrintArray(multiplyArray);
            int[,] resultArray = new int[array.GetLength(0), multiplyArray.GetLength(1)]; //výsledná matice má počet řádků podle 1., počet sloupců podle 2. matice
            for (int i = 0; i < resultArray.GetLength(0); i++)
            {
                int[] row = RowCopy(array, i); //array hodnot v jednotlivých sloupcích
                for (int j = 0; j < resultArray.GetLength(1); j++)
                {
                    int[] column = ColumnCopy(multiplyArray, j); //array hodnot v jednotlivých řádcích
                    for (int k = 0; k < resultArray.GetLength(1); k++)
                    {
                        resultArray[i, j] += row[k] * column[k]; //hodnota pole je součet součinů prvků i řádku 1. matice a j sloupce 2. matice
                    }
                }
            }
            PrintArray(resultArray);
        }//součin matic
        static int[] ColumnCopy(int[,] array, int y)
        {
            int[] column = new int[array.GetLength(0)];
            for(int i = 0; i < array.GetLength(0); i++)
            {
                column[i] = array[i, y];
            }
            return column;

        }//dělá array hodnot sloupce
        static int[] RowCopy(int[,] array, int x)
        {
            int[] row = new int[array.GetLength(1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                row[i] = array[x, i];
            }
            return row;
        }// dělá array hodnot řádku
      
    }
}