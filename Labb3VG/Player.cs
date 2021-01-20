using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using Labb3VG.MyMonster;

namespace Labb3VG
{
    class Player
    {
        private string name;
        private int lvl;
        private double lvlBar;
        private int experience;
        private int gold;
        private double hpCurrently;
        private double hpBar;
        private int toughness;
        private int strength;
        private bool amulett;
        private bool fireWeapon;
        private bool grassWeapon;
        private bool waterWeapon;
        private bool defAmulet;
        private bool atkAmulet;
        private bool dead;


        public Random rnd = new Random();



        public Player()
        {
            lvl = 1;
            gold = 0;
            HpBar = 300;
            hpCurrently = HpBar;
            lvlBar = 100;
            experience = 0;
            Strength = lvl;
            Toughness = 0;

        }



        public string Name { get => name; set => name = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Gold { get => gold; set => gold = value; }
        public double HpCurrently { get => hpCurrently; set => hpCurrently = value; }
        public int Toughness { get => toughness; set => toughness = value; }
        public int Strength { get => strength; set => strength = value; }
        public bool StrengtAmulet { get => amulett; set => amulett = value; }
        public double LvlBar { get => lvlBar; set => lvlBar = value; }
        public int Experience { get => experience; set => experience = value; }
        public double HpBar { get => hpBar; set => hpBar = value; }
        public bool FireWeapon { get => fireWeapon; set => fireWeapon = value; }
        public bool GrassWeapon { get => grassWeapon; set => grassWeapon = value; }
        public bool WaterWeapon { get => waterWeapon; set => waterWeapon = value; }
        public bool DefAmulet { get => defAmulet; set => defAmulet = value; }
        public bool AtkAmulet { get => atkAmulet; set => atkAmulet = value; }
        public bool Dead { get => dead; set => dead = value; }

        public void BattleStatus()
        {
            Console.WriteLine($"{Name}: {hpCurrently}");
        }
        public void TakeDamage(int damage)
        {
           if(defAmulet)
            { damage -= 2; }

            hpCurrently -= damage;

        }
        public int Attack(Monster monster)
        {
            int attack = 0;

            if (monster.Element == "water" && grassWeapon || monster.Element == "fire" && waterWeapon || monster.Element == "grass" && fireWeapon)
            {
                attack = Strikes(8);
            }

            else
            {
                attack = Strikes(0);
            }

            return attack;
        }

        private int Strikes(int weapon)
        {

            int attack = 0;


            int nr = rnd.Next(1, 22);                      // Låg risk att missa attacken, 5 procent. 
            if (nr != 1)
            {
                nr = rnd.Next(1, 4);
            }
            else
            {
                nr = 4;
            }



            switch (nr)
            {
                case 1:

                    attack += Strength + weapon;
                    Console.WriteLine($"You hit the monster, dealing {attack} damage");
                    break;

                case 2:
                    attack += Strength + 2 + weapon;
                    Console.WriteLine($"You hit the monster, dealing {attack} damage");
                    break;

                case 3:
                    attack += Strength + 3 + weapon;
                    Console.WriteLine($"You hit the monster with Great strengt. dealing {attack} damage");
                    break;

                case 4:
                    attack = 0;
                    Console.WriteLine("what happen´ bro? Get your shit together cause you just missed an open hit. Dealing 0 damage");
                    break;
            }

            return attack;
        }

        public void LvlUp()
        {

            Lvl++;
            Experience = Experience - (int)LvlBar;
            LvlBar = Math.Round(LvlBar * 1.25);
            HpBar = Math.Round(HpBar * 1.15);
            Strength++;

            hpCurrently = HpBar;
            if (Lvl < 10)
            {
                Console.WriteLine($"Congratulations! You leveled up! \nYou are now level {Lvl}, and you have {Experience} experience and {HpCurrently} hp and {gold} gold");
            }
            else
            {
                Console.WriteLine("Amazing! You reached lvl 10 and killed all the monsters on Hisingen.  AbuHassan can now relax and focus on his buisness again. ");
                lvl = 1;
                gold = 0;
                HpBar = 300;
                hpCurrently = HpBar;
                lvlBar = 100;
                experience = 0;
                Strength = lvl;
                Toughness = 0;
                AtkAmulet = false;
                DefAmulet = false;
                FireWeapon = false;
                WaterWeapon = false;
                GrassWeapon = false;
                Console.WriteLine("[Press enter to restart the game]");
                Console.ReadKey();
                GameLogic.Start();
            }

        }

        public override string ToString()
        {
            return $"***********\n* Name: {Name}\n* Level: {Lvl}\n* HP: {HpCurrently}/{HpBar}\n* Exp: {Experience}/{LvlBar}\n* Gold: {Gold}\n* Strength: {Strength}\n* Toughness: {Toughness}\n***********";
        } // Lägg till om personen har en amulett eller svärd. 
    }


}
