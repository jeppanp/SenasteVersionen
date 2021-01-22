using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Grass
{

    class RabiesBear : Monster, IMonster
    {

        static List<string> bearNames = new List<string>() { "Baloo", "Winnie The Pooh", "Ted", "Lorek", "Bungle", "Paddington" };
        public RabiesBear()
        {
            this.Name = bearNames[Utility.MonsterNames()];
            this.Element = "grass";
            this.Race = "Rabies Bear";
            this.Sound = "He moans like \"Grooar\"... *drooling* *drooling*";
            this.Lvl = Utility.RandomLvl();
            this.Hp = 70 + (Lvl * 5);
            this.DropGold = 30 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 7);
            this.Damage = (Lvl * 2);
            this.AttackNames = new List<string>() { "Spitting Rabies", "Drooling", "Bite" };
        }

    }
}