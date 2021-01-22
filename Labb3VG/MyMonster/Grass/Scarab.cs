using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Grass
{
    class Scarab : Monster, IMonster
    {

        static List<string> scarabNames = new List<string>() { "Insek", "Krypet", "Bäfis", "Tvestjärt", "Ekoxe", "millipede" };
        public Scarab()
        {
            this.Name = scarabNames[Utility.MonsterNames()];
            this.Element = "grass";
            this.Race = "Scarab";
            this.Sound = "You hear the sound of his movement: tik tik tik tik";
            this.Lvl = Utility.RandomLvl();
            this.Hp = 50 + (Lvl * 4);
            this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (Lvl + 1);
            this.AttackNames = new List<string>() { "Posion Hit", "Bite", "Fart" };

        }

    }
}

