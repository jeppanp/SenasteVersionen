﻿using System;
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
        private string weapon1;
        private string weapon2;
        private string weapon3;
        private bool defAmulet;
        private bool atkAmulet;
        private bool dead;
        private int healedByDruid;
        private List<string> weaponList = new List<string>();

        public Random rnd = new Random();



        public Player()
        {
            lvl = 1;
            gold = 0;
            HpBar = 350;
            hpCurrently = HpBar;
            lvlBar = 100;
            experience = 0;
            Strength = lvl;
            Toughness = 0;
            healedByDruid = 1;

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
        public string Weapon1 { get => weapon1; set => weapon1 = value; }
        public string Weapon2{ get => weapon2; set => weapon2 = value; }
        public string Weapon3 { get => weapon3; set => weapon3 = value; }
        public List<string> WeaponList { get => weaponList; set => weaponList = value; }
        public int HealedByDruid { get => healedByDruid; set => healedByDruid = value; }

        public void BattleStatus()
        {
            Console.WriteLine($"{Name}: {hpCurrently}");
        }
        public void TakeDamage(int damage)
        {
            
             damage -= toughness; 
            
            if(damage<0)
            { damage = 0;
                Console.WriteLine("But your armor reduced all the damage to 0");
            }


            hpCurrently -= damage;

        }


        public int Attack()
        {
            int attack = 0;

            if (GameLogic.monster.Element == "water" && grassWeapon || GameLogic.monster.Element == "fire" && waterWeapon || GameLogic.monster.Element == "grass" && fireWeapon)
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

            int attack = Utility.StrenghtInAttack(Strength) + weapon;


            if (Utility.AttackOrMissPlayer())
            {

                Console.WriteLine($"You hit the monster, dealing {attack} damage");
            }
            else
            {
                attack = 0;
                Console.WriteLine("what happen´ bro? Get your shit together cause you just missed an open hit. Dealing 0 damage");
            }

            return attack;
        }
        public void IsDead()
        {
            hpCurrently = 0;
            Dead = true;
            Gold = (int)Math.Round(Gold * 0.5);          // Drops half of the gold, and lose some abilities. 
            Strength--;
            Toughness--;

            Console.WriteLine($"You were killed by the monster and dropped {Gold} gold :(");
            Console.WriteLine("[Press enter to go back to menu]");
            Console.ReadKey();
        }
        public bool LvlUp()
        {

            Lvl++;
            Experience = Experience - (int)LvlBar;
            LvlBar = Math.Round(LvlBar * 1.5);
            HpBar = Math.Round(HpBar * 1.15);
            Strength++;
            if(lvl % 2 == 0)            // Every second lvl tougness increases
            { toughness++; }

            hpCurrently = HpBar;
            if (Lvl < 10)
            {
                Console.WriteLine($"Congratulations! You leveled up! \nYou are now level {Lvl}, and you have {Experience} experience and {HpCurrently} hp and {gold} gold");
                return  true;
            }
            else
            {
                Console.WriteLine("Amazing! You reached lvl 10 and killed all the monsters on Hisingen.  AbuHassan can now relax and focus on his buisness again. ");
                return false;

            }

        }

        public override string ToString()
        {
            string status = null;
            if (fireWeapon)
            { weapon1 = "FireSword,"; }
            if (waterWeapon)
            { weapon2 = "Trident,"; }
            if (grassWeapon)
            { weapon3 = "Electric Rod"; }
            if(dead)
            { status = ", you are dead."; }


            return $"***********\n* Name: {Name} {status}\n* Level: {Lvl}\n* HP: {HpCurrently}/{HpBar}\n* Exp: {Experience}/{LvlBar}\n* Gold: {Gold}\n* Strength: {Strength}\n* Toughness: {Toughness}\n* Weapon: {weapon1}{weapon2}{weapon3}\n***********";
        } 
    }


}
