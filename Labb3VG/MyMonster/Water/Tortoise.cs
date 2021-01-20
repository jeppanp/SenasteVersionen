using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Water
{
    class Tortoise : Monster
    {
        static List <string> turtleNames = new List<string>() { "Rafael", "Ninja Turtle", "Squirtle", "Slowmo", "Blastoise", "Shellman" };
    public Tortoise()
    {
        this.Name = turtleNames[Tools.MonsterNames()];
        this.Element = "water";
        this.Race = "Tortoise";
        this.Sound = "You can hear the sound of \"Bluuuuub Bluuuuub\"";
        this.Lvl = Tools.RandomLvl();
        this.HP = 50 + (Lvl * 4);
        this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
        this.Experience = 50 + (Lvl * 2);
        this.Damage = (int)Math.Round(Lvl * 1.5);
        this.AttackNames = new List<string>() { "Shell Squeezing", "Bite", "Sea Drowning" };

    }

        public override int Attack()
        {
            int attack = Tools.StrenghtInAttack(Damage);

            if (Tools.AttackOrMiss() == 1)
            {

                Console.WriteLine($"{Name} hits you with a {AttackNames[Tools.AttackNames()]} dealing {attack} damage.");
            }
            else
            {
                Console.WriteLine($"Wow! That {AttackNames[Tools.AttackNames()]} just passed your head, didn´t get hurt.");
            }


            return attack;
        }
    }
}