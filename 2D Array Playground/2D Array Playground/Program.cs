using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] array = new int[5, 5];
            int number = 1;
            for (int i = 0;i<array.GetLength(0);i++)
            {
                for (int j = 0;j< array.GetLength(1); j++)
                {
                    array[i,j] = number;
                    number++;
                    Console.Write(array[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                Console.Write(array[nRow, i] + " ");
            }
            Console.WriteLine();

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.WriteLine(array[i, nColumn]);
            }
            // BONUS TODO: HLAVNÍ DIAGONÁLA
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write(array[i, i] + " ");
            }
            Console.WriteLine();
            // BONUS TODO: VEDLEJŠÍ DIAGONÁLA
            for (int i = array.GetLength(0)-1; i>-1; i--)
            {
                Console.Write(array[array.GetLength(0)-1-i, i] + " ");
            }
            Console.WriteLine() ;
            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond;
            Random rnd = new Random();
            xFirst = rnd.Next(0, 5);
            yFirst = rnd.Next(0, 5);
            xSecond = rnd.Next(0, 5);
            ySecond = rnd.Next(0, 5);
            int remember = array[xSecond, ySecond];
            array[xSecond, ySecond] = array[xFirst,ySecond];
            array[xFirst, yFirst] = remember;
            Console.WriteLine($"první souřadnice: {xFirst} {yFirst}, druhé souřednice: {xSecond} {ySecond}");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j <array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;
            int[] rememberRow = new int[array.GetLength (1)];
            for (int i = 0; i < array.GetLength(1); i++)
            {
                rememberRow[i] = array[mRowSwap,i];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[mRowSwap, i] = array[nRowSwap, i];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                array[nRowSwap,i] = rememberRow[i];
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.

            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.


            Console.ReadKey();
        }
    }
}
