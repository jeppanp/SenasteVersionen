using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Grass
{

    class Wasp : Monster, IMonster
    {

        static List<string> waspNames = new List<string>() { "Stingie", "Sssssixten", "Zed", "Sticky", "Beeritt", "Buzz" };

        public Wasp()
        {
            this.Name = waspNames[Utility.MonsterNames()];
            this.Element = "grass";
            this.Race = "Wasp";
            this.Sound = "You can hear the sound when he fly, \"Bssssss\"";
            this.Lvl = Utility.RandomLvl();
            this.HP = 50 + (Lvl * 2);
            this.DropGold = 15 + (Lvl * 2);  // Skriv en random drop? 
            this.Experience = 20 + (Lvl * 2);
            this.Damage = Lvl;
            this.AttackNames = new List<string>() { "Posion Stinger", "Annoying Sound", "Wing Attack" };

        }


    }
}

