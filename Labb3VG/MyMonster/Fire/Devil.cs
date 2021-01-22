using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Fire
{
    class Devil : Monster, IMonster
    {

        static List<string> demonNames = new List<string>() { "Hades", "Satan", "Lucifer", "Beelzebub", "Mammon", "Leviathan" };
        public Devil()
        {
            this.Name = demonNames[Utility.MonsterNames()];
            this.Element = "fire";
            this.Race = "Devil";
            this.Sound = "He Yells: \"Your soul will be mine!\"";
            this.Lvl = Utility.RandomLvl();
            this.Hp = 50 + (Lvl * 4);
            this.DropGold = 40 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (Lvl * 2);
            this.AttackNames = new List<string>() { "Fire Chock", "Fire Field", "Great Fireball " };
        }
    
    }
}