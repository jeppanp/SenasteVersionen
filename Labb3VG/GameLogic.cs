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
        static public Monster monster;


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



            if (player.Name.Trim().ToLower() == "robin")
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
                if (player.Dead && player.HealedByDruid == 1)
                { Console.WriteLine("5. Go and search for the druid"); }
                Console.Write(">");

                userAnswerInBool = Int32.TryParse(Console.ReadLine(), out userAnswer);



                switch (userAnswer)
                {

                    case 1:
                        GoAdventuring();
                        break;

                    case 2:
                        GoPlayerDetails();
                        break;

                    case 3:
                        Shop.ShopMenu(player);
                        break;

                    case 4:
                        keepGoing = false;
                        break;

                    case 5:
                        if (player.Dead && player.HealedByDruid == 1)
                        {
                            GoFindDruid();
                        }
                        Menu();
                        break;

                    default:
                        Console.WriteLine("[Wrong input]");
                        break;

                }

            }
        }

        private static void GoFindDruid()
        {
            Console.WriteLine("Druid: Ohh, so you manage to find me after all.. what are you doing here?");
            Console.ReadKey();

            Console.WriteLine("\n1. Nothing, just chilling. Wanna hang out. ");
            Console.WriteLine("2. Someone told me you can bring me back to life.");
            userAnswerInBool = Int32.TryParse(Console.ReadLine(), out userAnswer);
            switch (userAnswer)
            {
                case 1:
                    Console.WriteLine("\nDruid: Cool man, well I dont have time for hanging around with jerks");
                    Console.WriteLine("The game is over for you");
                    Console.ReadKey();
                    keepGoing = false;
                    break;

                case 2:
                    Console.WriteLine("Druid: heheh, I see. But the amount of stamina to manage such thing is only one creatue that holds.\n Its the Devil himself.");
                    Console.WriteLine("Druid: If you decide to go back to life, you endanger the life of all the people at Hisingen. \nThe Devils power will increase by doing this. Are you still up for that risk?  ");
                    Console.ReadKey();

                    Console.WriteLine("\n1. Yes, I need go back to save Abu Hassans Business");
                    Console.WriteLine("2. Hell no, I´m not up for that crap, I better be dead");
                    userAnswerInBool = Int32.TryParse(Console.ReadLine(), out userAnswer);
                    switch (userAnswer)
                    {
                        case 1:
                            Monster devil = monsterList.Find(x => x.Race == "Devil" && x.Lvl > 6);
                            devil.HP *= 10;
                            devil.Damage *= 4;
                            devil.DropGold += player.Gold;
                            player.Gold = 0;
                            player.HpCurrently = (int)player.HpBar * 0.5;
                            player.Dead = false;
                            player.HealedByDruid--;
                            Console.WriteLine("\nDruid: if that is what you really want.. Get ready then, I´ll summon his power and trough him bring your life back");
                            Console.ReadKey();
                            Console.WriteLine("Druid: And its done. Oh, Now I need to rest, and now everything depends on you.");
                            Console.ReadKey();

                            Console.WriteLine($"Druid: Oh, I forget to tell you that the devil calls himself for {devil.Name}, and he just took all of your gold.. ");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.WriteLine("\nDruid: Such a waste of time. Leave me alone");
                            Console.WriteLine("The game is over for you");
                            Console.ReadKey();
                            keepGoing = false;
                            break;

                    }
                    break;
            }

        }


        private static void RobinMode()
        {
            player.Gold = 1000000;
            player.HpBar = 10000;
            player.HpCurrently = 10000;

            player.Strength = 20;
            player.Toughness = 20;

        }

        private static void GoAdventuring()
        {
            if (IsPlayerAlive())
            {
                switch (Utility.FindingMonster())

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
            monster = Utility.PickMonster();  // Slumpa fram lvlbaserat
            monster.Greetings();

            while (!player.Dead && !monster.Dead)
            {

                damage = player.Attack();
                monster.TakeDamage(damage);
                if (monster.HP <= 0)
                {
                    monster.Dead = true;
                    Loot(monster);

                }
                else
                {
                    damage = monster.Attack();
                    if (damage > 0)                                         // this if-statement is necessary to make it work with the propity "tougness". Otherwise i can´t seperate a miss from a monster, from a block with the armor
                    { player.TakeDamage(damage); }
                }

                if (player.HpCurrently <= 0)           // bestämm om de ska ske något när en dör. tappa guld? avbryta spelet? healing möjlighet? 
                {
                    player.IsDead();
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
                keepGoing = player.LvlUp();                   // If player is reach lvl 10 the loop for the game ends, and so does the game. 
            }

            Console.WriteLine("[Press enter to go back to menu]");
            Console.ReadKey();

        }
        private static bool IsPlayerAlive()
        {
            if (!player.Dead)
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

        private static void GoPlayerDetails()
        {
            Console.WriteLine(player);
            Console.WriteLine("[Press enter to go back to menu]");
            Console.ReadKey();
            Console.Clear();
        }

        private static void CreateMonsters()   // Just because i want random kind of monsters, in different lvls i go through this loop. And the settings gives them random lvls and names. 
        {
            for (int i = 0; i < 25; i++)
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
