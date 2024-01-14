using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
            List<Characters> playerTeam = new List<Characters>
            {
                CreateHounzenka(),null,null
            };
            Characters boss = CreateCat();
            boss.level = 200;
            UpdateHP(playerTeam[0]);
            char[,] map = new char[32, 32];
            FillMap(map);
            char[,] mapEdit = (char[,])map.Clone();
            PlayerMovement(map, mapEdit, playerTeam);
            Console.ReadKey();
        }
        static void Battle(Characters enemy, List<Characters> playerTeam)
        {
            Console.Clear();
            Console.WriteLine($" a wild {enemy.name} lv. {enemy.level} has appeared!");
            UpdateHP(enemy);
            bool lost = true;
            int turn = 0;
            Characters player;
            while (CheckTeamAlive(playerTeam) && enemy.healthPoint > 0)
            {
                player = ChooseCharacter(playerTeam);
                UpdateHP(player);
                while (player.healthPoint > 0 && enemy.healthPoint > 0)
                {
                    Console.Clear();
                    Console.Write($"{player.look} [{player.healthPoint}/{player.maxHealth}] ");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.WriteLine();
                    }
                    Console.Write($"{enemy.look} [{enemy.healthPoint}/{enemy.maxHealth}] ");
                    Console.WriteLine();
                    if (turn % 2 == 0)
                    {
                        Console.WriteLine("choose action");
                        ChooseAbility(player).DealDamage(enemy);
                        turn++;
                    }
                    else
                    {
                        enemy.specialAbility.DealDamage(player);
                        turn++;
                    }
                }
                if (enemy.healthPoint <= 0)
                {
                    Console.WriteLine($"you won!, {player.name}'s level increased by 1!");
                    player.level += 1;
                    Console.WriteLine($"do you want to catch {enemy.name} lv. {enemy.level}?");
                    Console.WriteLine("type a number 0-2 to replace a character, type anything other to skip");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int result) && (input == "0" || input == "1" || input == "2"))
                    {
                        playerTeam[int.Parse(input)] = enemy;
                    }
                    else
                    {
                        Console.Write("you chose to skip");
                    }
                    lost = false;
                }
                else
                {
                    Console.WriteLine($"{player.name} lost!");
                }
                
            }
            if (lost)
            {
                Console.WriteLine("all your characters are dead, you lost!");
                Console.WriteLine("press any key to proceed");
                Console.ReadKey();
            }
            for (int i = 0; i < 3; i++)
            {
                if (playerTeam[i] != null)
                {
                    UpdateHP(playerTeam[i]);
                }
            }

        }
        static Characters ChooseCharacter(List<Characters> playerTeam)
        {
            for (int i = 0; i < 3; i++)
            {
                if (playerTeam[i] != null)
                {
                    if (playerTeam[i].healthPoint > 0)
                    {
                        Console.WriteLine($"{i}.: {playerTeam[i].name} lv. {playerTeam[i].level}");
                    }
                }
            }
            string input = "a";
            while(int.TryParse(input, out int result) == false && (input == "0" || input == "1" || input == "2") == false)
            {
                Console.WriteLine("choose a character");
                input = Console.ReadLine();
            }
            if (playerTeam[int.Parse(input)] == null)
            {
                Console.WriteLine("Character nonexist");
                return ChooseCharacter(playerTeam);
            }
            else
            {
                return playerTeam[int.Parse(input)];
            }
        }
        static bool CheckTeamAlive(List<Characters> playerTeam)
        {
            for (int i = 0; i < 3; i++)
            {
                if (playerTeam[i] != null)
                {
                    if (playerTeam[i].healthPoint > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static Abilities ChooseAbility(Characters character)
        {
            Console.WriteLine($"1.: {character.normalAbility.name}: {character.normalAbility.desciption}");
            Console.WriteLine($"2.: {character.specialAbility.name}: {character.specialAbility.desciption}");
            string input = "a";
            while(int.TryParse(input, out int result) == false)
            {
                Console.WriteLine("vyber schopnost");
                input = Console.ReadLine();
            }
            int index = int.Parse(input);
            if (index == 1)
            {
                return character.normalAbility;
            }
            else
            {
                return character.specialAbility;
            }
        }
        static Abilities CreateFireAtack()
        {
            Abilities fireAtack = new Abilities();
            fireAtack.name = "fire atack";
            fireAtack.type = "fire";
            fireAtack.damage = 50;
            fireAtack.accuracy = 100;
            fireAtack.desciption = "deals 50 fire damage to the target";
            return fireAtack;
        }
        static Abilities CreateWaterAtack()
        {
            Abilities waterAtack = new Abilities();
            waterAtack.name = "water atack";
            waterAtack.type = "water";
            waterAtack.damage = 50;
            waterAtack.accuracy = 100;
            waterAtack.desciption = "deals 50 water damage to the target";
            return waterAtack;
        }
        static Abilities CreateGrassAtack()
        {
            Abilities grassAtack = new Abilities();
            grassAtack.name = "grass atack";
            grassAtack.type = "grass";
            grassAtack.damage = 50;
            grassAtack.accuracy = 100;
            grassAtack.desciption = "deals 50 grass damage to the target";
            return grassAtack;
        }
        static Abilities CreateStrongFireAtack()
        {
            Abilities strongFire = new Abilities();
            strongFire.name = "strong fire atack";
            strongFire.type = "fire";
            strongFire.damage = 100;
            strongFire.accuracy = 50;
            strongFire.desciption = "low accuracy ability that deals 100 fire damage to the target";
            return strongFire;

        }
        static Abilities CreateStrongWaterAtack()
        {
            Abilities strongWater = new Abilities();
            strongWater.name = "strong water atack";
            strongWater.type = "water";
            strongWater.damage = 100;
            strongWater.accuracy = 50;
            strongWater.desciption = "low accuracy ability that deals 100 water damage to the target";
            return strongWater;
        }
        static Abilities CreateStrongGrassAtack()
        {
            Abilities strongGrass = new Abilities();
            strongGrass.name = "strong grass atack";
            strongGrass.type = "grass";
            strongGrass.damage = 100;
            strongGrass.accuracy = 50;
            strongGrass.desciption = "low accuracy ability that deals 100 grass damage to the target";
            return strongGrass;
        }
        static Characters CreateHounzenka()
        {
            Characters hounzenka = new Characters();
            hounzenka.type = "grass";
            hounzenka.name = "hounzenka";
            hounzenka.level = rnd.Next(0, 10);
            hounzenka.look = "\\_/-.--.--.--.--.--.\r\n(\")__)__)__)__)__)__)\r\n ^ \"\" \"\" \"\" \"\" \"\" \"\"";
            hounzenka.normalAbility = CreateGrassAtack();
            hounzenka.specialAbility = CreateStrongGrassAtack();
            return hounzenka;
        }
        static Characters CreateCat()
        {
            Characters cat = new Characters();
            cat.type = "fire";
            cat.name = "cat";
            cat.level = rnd.Next(0, 10);
            cat.look = "/\\_/\\\r\n( o.o )\r\n > ^ <";
            cat.normalAbility = CreateFireAtack();
            cat.specialAbility = CreateStrongFireAtack();
            return cat;
        }
        static Characters CreateFilipsh()
        {
            Characters filipsh = new Characters();
            filipsh.type = "water";
            filipsh.name = "filipsh";
            filipsh.level = rnd.Next(0, 10);
            filipsh.look = " __v_\r\n(____\\/{";
            filipsh.normalAbility = CreateWaterAtack();
            filipsh.specialAbility = CreateStrongWaterAtack();
            return filipsh;
        }
        static void UpdateHP(Characters character)
        {
            character.maxHealth = 100 + character.level * 20;
            character.healthPoint = character.maxHealth;
        }
        static void PlayerMovement(char[,] map, char[,] mapEdit, List<Characters> playerTeam)
        {
            mapEdit[15, 1] = '0';
            int locationX = 15;
            int locationY = 1;
            DateTime pressTime = DateTime.MinValue;
            while (true)
            {
                PrintMap(mapEdit);
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
                    if (map[locationX, locationY] == '"')
                    {
                        if (RNG(50))
                        {
                            if (RNG(50))
                            {
                                Battle(CreateCat(), playerTeam);
                            }
                            else
                            {
                                Battle(CreateHounzenka(), playerTeam);
                            }
                        }
                    }
                    if (map[locationX,locationY] == 'W')
                    {
                        if (RNG(50))
                        {
                            Battle(CreateFilipsh(), playerTeam);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("zpomal týpku");
                }
                pressTime = DateTime.Now;
                
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
        public static bool RNG(int percentage)
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