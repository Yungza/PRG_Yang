using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti čísly.
            int[] myInt = { 1, 5, 3, 4, 2};

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            for (int i = 0;i<myInt.Length; i++)
            {
                Console.WriteLine(myInt[i]);
            }
            foreach (int x in myInt)
            {
                Console.WriteLine(x);
            }
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            for (int i = 0; i < myInt.Length; i++)
            {
                sum = sum + myInt[i];
            }
            Console.WriteLine("suma prvků je: " + sum);

            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = sum/myInt.Length;
            Console.WriteLine("průměr je: " + average);

            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = myInt.Max();
            Console.WriteLine("největší prvek: " + max) ;

            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = myInt.Min();
            Console.WriteLine("nejmenší prvek: " + min);

            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole. 
            int index = 0;
            Console.WriteLine("zadej číslo jehož pořadí v listu chceš zjistit");
            int find = int.Parse(Console.ReadLine());
            index = Array.IndexOf(myInt, find)+1;
            if (index == 0)
            {
                Console.WriteLine("prvek v listu neexistuje");
            }
            else
            Console.WriteLine("hledané číslo je na: " + index + ". místě"); //nefunguje protože to je sortlý lol

            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            Random rng = new Random();
            myInt = new int[100];
            for (int i = 0; i <100 ; i++)
            {
                myInt[i] = rng.Next(0,10);
            }
            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int num in myInt)
            {
                counts[num]++;
            }
            for (int i = 0; i < counts.Length; i++)
            {
                Console.Write($"četnost{i}je{counts[i]}");
            }
            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] reversedMyInt = new int[100];
            for (int i = reversedMyInt.Length-1; i >=0; i--)
            {
                reversedMyInt[i] = myInt[99 - i];
            }
            for (int i = 0; i < reversedMyInt.Length; i++)
            {
                Console.Write($"{reversedMyInt[i]}");
            }
            Console.ReadKey();
        }
    }
}
