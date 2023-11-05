namespace _2D_Matice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] initialArray = new int[InputInt("počtu řádků"), InputInt("počtu sloupců")];
            int[,] workArray = new int[initialArray.GetLength(0), initialArray.GetLength(1)];
            FillArray(initialArray, workArray);
            PrintArray(workArray);
            while (true)
            {
                Console.WriteLine("operace k dispozici:");
                Console.WriteLine("0. resetování matice");
                Console.WriteLine("1. prohazování");
                string input = LimitInput(0, 2, "operace").ToString();
                string input2;
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
        static void FillArray(int[,] initialArray, int[,] workArray)
        {
            Random rnd = new Random();
            int lastNumber = 0;
            for (int i = 0; i < initialArray.GetLength(0); i++)
            {
                for (int j = 0; j < initialArray.GetLength(1); j++)
                {
                    initialArray[i, j] = workArray[i, j] = lastNumber + rnd.Next(1, 10);
                    lastNumber = initialArray[i, j];
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
            int xSecond = rnd.Next(0,array.GetLength(0));
            int yFirst = rnd.Next(0,array.GetLength(1));
            int ySecond = rnd.Next(0,array.GetLength (1));
            int remember = array[xSecond, ySecond];
            Console.WriteLine($"budu měnit prvek se souřadnicemi x = {yFirst}, y = {xFirst} s prvkem: {ySecond}, {xSecond}");
            array[xSecond, ySecond] = array[xFirst, yFirst];
            array[xFirst, yFirst] = remember;
            PrintArray (array);
        }//prohazování náhodných prvků
        static void RowSwap(int[,] array)
        {
            Console.WriteLine($"zadej dva řádky jenž chceš prohodit");
            int firstRow = LimitInput(0, array.GetLength(0)-1, "prvního řádku");
            int secondRow = LimitInput(0, array.GetLength(0)-1, "druhého řádku");
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
            PrintArray (array);
        }//prohazování řádků
        static void ColSwap(int[,] array)
        {
            Console.WriteLine($"zadej dva sloupce jenž chceš prohodit");
            int firstColumm = LimitInput(0, array.GetLength(1) - 1,"prvního řádku");
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
        {
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

    }
}