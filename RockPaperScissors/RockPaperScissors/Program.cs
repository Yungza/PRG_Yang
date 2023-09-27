using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Jednoduchy program na procviceni podminek a cyklu.
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem kamen-nuzky-papir.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy skore obou
             *
             * Opakuj tolikrat, kolik kol chces hrat:
             * {
             *      Dokud uzivatel nezada vstup spravne:
             *      {
             *          - nacitej vstup od uzivatele
             *      }
             *      
             *      - vygeneruj s pomoci rng.Next() nahodny vstup pocitace
             *      
             *      Pokud vyhral uzivatel:
             *      {
             *          - informuj uzivatele, ze vyhral kolo
             *          - zvys skore uzivateli o 1
             *      }
             *      Pokud vyhral pocitac:
             *      {
             *          - informuj uzivatele, ze prohral kolo
             *          - zvys skore pocitaci o 1
             *      }
             *      Pokud byla remiza:
             *      {
             *          - informuj uzivatele, ze doslo k remize
             *      }
             * }
             * 
             * - informuj uzivatele, jake mel skore on/a a pocitac a kdo vyhral.
             */

            Random rng = new Random(); //instance tridy Random pro generovani nahodnych cisel
            int scorePlayer = 0;
            int scoreComputer = 0;
            string input = "";
            while (scoreComputer + scorePlayer < 5)
            {
                while (input != "kámen" && input!= "nůžky" && input !="papír")
                {
                    Console.WriteLine("zadej kámen/nůžky/papír");
                    input = Console.ReadLine();
                }
                int result = rng.Next(0, 3);
                if (result == 0)
                {
                    Console.WriteLine("Vyhrál jsi");
                    scorePlayer++;
                }
                else if (result == 1)
                {
                    Console.WriteLine("Vyhrál počítač");
                    scoreComputer++;
                }
                else
                {
                    Console.WriteLine("remíza");
                }
                input = "";
            }
            if (scorePlayer > scoreComputer)
            {
                Console.WriteLine("skóre je: " + scorePlayer + " : " + scoreComputer + ", " + "vyhrál jsi :)");
            }
            else
            {
                Console.WriteLine("skóre je: " + scorePlayer + " : " + scoreComputer + ", " + "prohrál jsi :(");
            }
            



            Console.ReadKey(); //Aby se nam to hnedka neukoncilo
        }
    }
}
