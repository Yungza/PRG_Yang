using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Game
{
    internal class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            char[,] map = new char[32, 32];
            FillMap(map);
            char[,] mapEdit = (char[,])map.Clone();
            PlayerMovement(map,mapEdit);

        }
        static void PlayerMovement(char[,] map, char[,] mapEdit)
        {
            mapEdit[15, 1] = '0';
            PrintMap(mapEdit);
            int locationX = 15;
            int locationY = 1;
            while (true)
            {
                DateTime pressTime = DateTime.MinValue;
                //creates variable cooldown with the value of 50 milliseconds, stolen from Filip Čermák 3.D but I know how it works
                TimeSpan cooldown = TimeSpan.FromMilliseconds(50);
                ConsoleKeyInfo movement = Console.ReadKey();
                if ((DateTime.Now - pressTime) >= cooldown)
                {
                    bool ifCorrectInput = true;
                    switch (movement.Key)
                    {
                        case ConsoleKey.W:
                            if (ValidMovement(mapEdit, locationX - 1, locationY))
                            {   
                                FillHole(map, mapEdit, locationX, locationY);
                                locationX -= 1;
                            }
                            else
                            {
                                ifCorrectInput = NonValidMovement();
                            }
                            break;
                        case ConsoleKey.S:
                            if (ValidMovement(mapEdit, locationX + 1, locationY))
                            {
                                FillHole(map, mapEdit, locationX, locationY);
                                locationX += 1;
                            }
                            else
                            {
                                ifCorrectInput = NonValidMovement();
                            }
                            break;
                        case ConsoleKey.D:
                            if (ValidMovement(mapEdit, locationX, locationY + 1))
                            {
                                FillHole(map, mapEdit, locationX, locationY);
                                locationY += 1;
                            }
                            else
                            {
                                ifCorrectInput = NonValidMovement();
                            }
                            break;
                        case ConsoleKey.A:
                            if (ValidMovement(mapEdit, locationX, locationY - 1))
                            {
                                FillHole(map, mapEdit, locationX, locationY);
                                locationY -= 1;
                            }
                            else
                            {
                                ifCorrectInput = NonValidMovement();
                            }
                            break;
                        default:
                            ifCorrectInput = false;
                            Console.WriteLine(": je neplatný vstup");
                            break;
                    }
                    if (ifCorrectInput)
                    {
                        mapEdit[locationX, locationY] = '0';
                        Console.Clear();
                        PrintMap(mapEdit);
                    }
                }
                else
                {
                    Console.WriteLine("zpomal týpku");
                }
                
            }
        }
        static bool ValidMovement(char[,] map, int nextX, int nextY)
        {
            if (map[nextX,nextY] == '#' || map[nextX, nextY] == 'T')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool NonValidMovement()
        {
            Console.WriteLine("neplatný movement");
            return false;
        }
        static void FillHole(char[,] map, char[,] mapEdit, int x, int y)
        {
            mapEdit[x,y] = map[x,y];
        }
        static void FillMap(char[,] map)
        {
            for (int i = 0; i < 32; i++) // tráva
            {
                for (int j = 0; j < 32; j++)
                {
                    map[i, j] = '"';
                }
            }
            for (int i = 0; i < 32; i++) // hranice
            {
                map[0, i] = '#';
                map[31, i] = '#';
                map[i, 0] = '#';
                map[i, 31] = '#';
            }
            for (int i = 1; i < 30; i++) // hlavní cesta
            {
                map[15, i] = '-';
            }
            for (int i = 4; i < 29; i++) // cesta
            {
                map[i, 5] = '|';
            }
            for (int i = 5; i < 24; i++) // cesta2
            {
                map[28, i] = '-';
            }
            for (int i = 15; i < 29; i++) // cesta 3
            {
                map[i, 23] = '|';
            }
            for (int i = 5; i < 16; i++) // cesta 4
            {
                map[10, i] = '-';
            }
            for (int i = 6; i < 11; i++) // cesta n 
            {
                map[i,15] = '|';
            }
            for (int  i = 5;  i < 21;  i++)
            {
                map[4, i] = '-';
            }
            for (int i = 15; i < 21; i++)
            {
                map[6, i] = '-';
            }
            for (int i = 4; i < 16; i++)
            {
                map[i, 20] = '|';
            }
            for (int i = 19; i < 28; i++) // voda
            {
                for (int j = 6; j < 15; j++)
                {
                    map[i, j] = 'W';
                }
            }
            for (int i = 21; i < 26; i++)
            {
                for (int j = 15; j < 17; j++)
                {
                    map[i, j] = 'W';
                }
            }
            for (int i = 1; i < 32; i++) // stromy :)
            {
                for (int j = 1; j < 32; j++)
                {
                    if (map[i, j] == '"' && RNG(5))
                    {
                        map[i, j] = 'T';
                    }
                }
            }

            map[15, 5] = map[28, 5] = map[28, 23] = map[15, 23] = map[15, 20] = map[10, 5] = map[4, 5] = map[4, 20] = map[6, 20] = map[6,15] = map[10,15] = '+'; // křižovatky
            map[15, 30] = 'G'; // Gym

        }
        static void PrintMap(char[,] map)
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    Console.Write(map[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
        static bool RNG(int percentage)
        {
            int rng = rnd.Next(0, 100);
            if (rng <= percentage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
