﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Deathroll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Jednoduchy program na procviceni podminek a cyklu (lze udelat i rekurzi).
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem deathroll.
             * Pravidla deathrollu: Prvni hrac navrhne cislo (puvodne ve wowku pocet goldu, o ktere se hraci vsadi) a "rollne" navrhnute cislo, jinak receno je to stejne,
             * jako kdyby si hodil kostkou s tolika stenami, jako je navrhnute cislo. Prvnimu hraci "padne" nejake cislo a druhy hrac si "rollne" padnute cislo.
             * Prohrava ten hrac, kteremu padne 1 jako prvnimu.
             * Ukazka hry: Hraci se shodnou na cisle 1000. Prvni hrac rollne 0-1000, padne mu 920. Druhy hrac rolluje 0-920, padne mu 235 atd. atd. az jednomu z hracu padne 1
             * a ten prohrava.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy aktualne rollovane cislo a stav "goldu" uzivatele i pocitace (oba zacinaji treba s 1000 goldu)
             * 
             * - uzivatel zada prvotni sazku, ktera musi byt maximalne tolik, kolik ma goldu
             * 
             * Opakuj dokud nepadne jednomu z hracu 1:
             * {
             *      Pokud je sude kolo:
             *      {
             *          - uzivatel zada hodnotu, kterou rolluje
             *          - kontroluj, ze uzivatel zadal spravnou hodnotu
             *          - uloz rollnute cislo
             *          - vypis uzivateli, co rollnul
             *      }
             *      Pokud je liche kolo:
             *      {
             *          - pocitac rollne nahodne cislo mezi 0 a aktualne rollovanym cislem
             *          - vypis uzivateli, co rollnul pocitac
             *      }
             * }
             * 
             * 
             * - posledni hrajici hrac prohral, protoze mu padla 1 a sazku bere druhy hrac
             * - vypis uzivateli kdo vyhral a stav goldu uzivatele i pocitace
             * 
             * ROZSIRENI:
             * - umozni uzivateli opakovat deathroll dokud ma nejake goldy
             */
            Random rng = new Random();
            int goldPlayer = 1000;
            int goldBot = 1000;
            int roll = 0;
            while (goldPlayer > 0 && goldBot > 0)
            {
                string input = "";
                int start = rng.Next(0, 2);
                int deathRollValue = 9999;// TADY OPRAVIT
                if (start == 1) 
                {
                    while (!int.TryParse(input, out int result) || deathRollValue > goldPlayer || deathRollValue > goldBot)
                    {
                        Console.WriteLine("Začínáš, urči hodnotu death rollu, musí být menší než gold hráčů");
                        input = Console.ReadLine();
                        deathRollValue = Int32.Parse(input);
                        roll = deathRollValue;
                    }
                }
                else if (start == 0)
                {
                    if (goldBot<=goldPlayer)
                    {
                        deathRollValue = rng.Next(1, goldBot);
                    }
                    else
                    {
                        deathRollValue = rng.Next(1, goldPlayer);
                    }
                    roll = deathRollValue;
                    Console.WriteLine("Začíná počítač, hodnta death rollu je: " + deathRollValue.ToString());
                }
                for (int i =start + 1; i < 9999; i++) //změna kola
                {
                    if (i %2==0)
                    {
                        Console.WriteLine("na tahu je počítač");
                        roll = rng.Next(1,roll); // nový roll
                        Console.WriteLine(roll.ToString());
                        Console.ReadKey();
                        if (roll == 1) 
                        {
                            Console.WriteLine("počítač prohrál");
                            goldBot -= deathRollValue;
                            goldPlayer += deathRollValue;
                            Console.WriteLine("počítač: " + goldBot + " hráč: " + goldPlayer);
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("jsi na tahu");
                        roll= rng.Next(1,roll); // nový roll
                        Console.WriteLine(roll.ToString());
                        Console.ReadKey();
                        if(roll ==1)
                        {
                            Console.WriteLine("hráč prohrál");
                            goldBot += deathRollValue;
                            goldPlayer -= deathRollValue;
                            Console.WriteLine("počítač: " + goldBot + " hráč: " + goldPlayer);
                            Console.ReadKey();
                            break;
                        }
                        
                    }
                }
            }
            if (goldPlayer <= 0)
            {
                Console.WriteLine("hráč zkrachoval, vyhrává počítač");
            }
            else
            {
                Console.WriteLine("počítač zkrachoval, vyhrává hráč");
            }
            Console.ReadKey();
        }
    }
}
