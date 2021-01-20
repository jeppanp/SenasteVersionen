using System;
using System.Collections.Generic;
using System.Threading;
using Labb3VG.MyMonster;
using Labb3VG.MyMonster.Water;
using Labb3VG.MyMonster.Grass;
using Labb3VG.MyMonster.Fire;
using Microsoft.VisualBasic;
namespace Labb3VG
{
    static class GameLogic
    {
        static public List<Monster> monsterList = new List<Monster>();
        static public Player player = new Player();
        static Random rnd = new Random();
        static bool keepGoing = true;
        static int userAnswer;
        static bool userAnswerInBool;
        static int damage;
        static Monster monster;


        public static void Start()
        {
            Console.Clear();
            Console.Title = "Save Hisingen";
            CreateMonsters();

            Console.WriteLine("**********************");
            Console.WriteLine("*Welcome to the Game!*");
            Console.WriteLine("**********************");
            Console.Write("Enter your namne: ");
            player.Name = Console.ReadLine();

            if(player.Name.Trim().ToLower() == "robin")
            { RobinMode(); }

            Menu();
        }

        private static void Menu()
        {
            while (keepGoing)
            {


                Console.WriteLine("1. Go adventuring");
                Console.WriteLine("2. Show details about your character");
                Console.WriteLine("3. Shop");
                Console.WriteLine("4. Exit Game");
                Console.Write(">");
                userAnswerInBool = Int32.TryParse(Console.ReadLine(), out userAnswer);

                

                switch (userAnswer)
                {

                    case 1:
                        GoAdventuring();
                        break;

                    case 2:
                        PlayerDetails();
                        break;

                    case 3:
                        Shop.ShopMenu(player);
                        break;

                    case 4:
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("[Wrong input]");
                    break; 

                }

            }
        }

        private static void RobinMode()
        {
            player.Gold = 1000000;
            player.HpBar = 10000;
            player.HpCurrently = 10000;
            player.DefAmulet = true;
            player.AtkAmulet = true;
            player.FireWeapon = true;
            player.WaterWeapon = true;
            player.GrassWeapon = true;
            
           
        }

        private static void GoAdventuring()
        {
            if (IsPlayerAlive())
            {
                switch (Tools.FindingMonster())

                {
                    case 1:
                        Battle();
                        break;

                    case 2:
                        Console.WriteLine("wow, you find a hidden tressure. Looted 50 gold");
                        player.Gold += 50;
                        break;

                    case 3:
                        Console.WriteLine("You see nothing but sawying grass all around you");
                        break;

                }

            }
        }


        private static void Battle()
        {
            monster = Tools.RandomisedMonster();  // Slumpa fram lvlbaserat
            monster.Greetings();

            while (!player.Dead && !monster.Dead)
            {

                damage = player.Attack(monster);
                monster.TakeDamage(damage);
                if (monster.HP <= 0)
                {
                    monster.Dead = true;
                    Loot(monster);

                }
                else
                {
                    damage = monster.Attack();
                    player.TakeDamage(damage);
                }

                if (player.HpCurrently <= 0)           // bestämm om de ska ske något när en dör. tappa guld? avbryta spelet? healing möjlighet? 
                {
                    player.Dead = true;
                    Console.WriteLine("You were killed by the monster :(");
                    Console.WriteLine("[Press enter to go back to menu]");
                    Console.ReadKey();

                }

                else if (!monster.Dead)
                {
                    player.BattleStatus();
                    monster.BattleStatus();

                    Console.WriteLine("[press enter to contiunue]");
                    Console.ReadKey();
                }

            }

        }

        private static void Loot(Monster monster)
        {
            Console.WriteLine($"You killed the monster! Gaining {monster.Experience} experience and looted {monster.DropGold} gold");

            player.Gold += monster.DropGold;
            player.Experience += monster.Experience;

            if (player.Experience >= player.LvlBar)
            {
                player.LvlUp();
            }

            Console.WriteLine("[Press enter to go back to menu]");
            Console.ReadKey();

        }
        private static bool IsPlayerAlive()
        {
            if (player.HpCurrently > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Sorry mate, you´re dead. Try to find a healer that can bring you back from the dead. But it will cost you...");
                Console.ReadKey();
                return false;
            }

        }

        private static void PlayerDetails()
        {
            Console.WriteLine(player);
            Console.WriteLine("[Press enter to go back to menu]");
            Console.ReadKey();
            Console.Clear();
        }

        private static void CreateMonsters()   // Just because i want random kind of monsters, in different lvls i go through this loop. And the settings gives them random lvls and names. 
        {
            for (int i = 0; i < 15; i++)
            {
                monsterList.Add(new Dragon());
                monsterList.Add(new Devil());
                monsterList.Add(new Tortoise());
                monsterList.Add(new SwampTroll());
                monsterList.Add(new Crocodile());
                monsterList.Add(new RabiesBear());
                monsterList.Add(new Wasp());
                monsterList.Add(new Scarab());
            }                                                    
                monsterList.Add(new DragonLord());                                   //but only one dragon lord.
        }
    }
}
