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
        this.Name = turtleNames[Utility.MonsterNames()];
        this.Element = "water";
        this.Race = "Tortoise";
        this.Sound = "You can hear the sound of \"Bluuuuub Bluuuuub\"";
        this.Lvl = Utility.RandomLvl();
        this.HP = 50 + (Lvl * 4);
        this.DropGold = 10 + (Lvl * 2);  // Skriv en random drop? 
        this.Experience = 60 + (Lvl * 2);
        this.Damage = (int)Math.Round(Lvl * 1.5);
        this.AttackNames = new List<string>() { "Shell Squeezing", "Bite", "Sea Drowning" };

    }


    }
}