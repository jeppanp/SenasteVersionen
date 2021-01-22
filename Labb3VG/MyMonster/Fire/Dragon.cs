using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Labb3VG.MyMonster.Fire
{

    class Dragon : Monster, IMonster
    {

        List<string> dragonNames = new List<string>() { "Onyxia", "Katla", "Twiligt Eye", "Saphira", "Smaug", "Mushu" };
        public Dragon()
        {
            this.Name = dragonNames[Utility.MonsterNames()];
            this.Element = "fire";
            this.Race = "Dragon";
            this.Sound = "You hear the sound of FCHHHHHHHH";
            this.Lvl = Utility.RandomLvl();
            this.Hp = 80 + (Lvl * 4);
            this.DropGold = 40 + (Lvl * 5);  // Skriv en random drop? 
            this.Experience = 80 + (Lvl * 2);
            this.Damage = (int)Math.Round(Lvl * 2.5);
            this.AttackNames = new List<string>() { "Wall Of Fire ", "Fire Flame", "Great Fireball " };
        }

    }
}