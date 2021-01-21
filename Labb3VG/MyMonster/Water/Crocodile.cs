using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Labb3VG.MyMonster.Water
{
    class Crocodile : Monster
    {

        static List<string> crocNames = new List<string>() { "Crocks", "Allie", "Green Tail", "Lolong", "Steve Irwin", "Delta" };

        public Crocodile()
        {
            this.Name = crocNames[Utility.MonsterNames()];
            this.Element = "water";
            this.Race = "Crocodile";
            this.Sound = "Rooooaaarrrrr";
            this.Lvl= Utility.RandomLvl();
            this.HP = 50 + (Lvl*4);
            this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (Lvl * 2);
            this.AttackNames =  new List<string>() { "Tail Snapper", "Bite", "claw demolition" };

        }



    }
}
