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
            this.Name = demonNames[Tools.MonsterNames()];
            this.Element = "fire";
            this.Race = "Devil";
            this.Sound = "He Yells: \"Your soul will be mine!\"";
            this.Lvl = Tools.RandomLvl();
            this.HP = 50 + (Lvl * 4);
            this.DropGold = 40 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (int)Math.Round(Lvl * 1.5);
            this.AttackNames = new List<string>() { "Fire Chock", "Fire Field", "Great Fireball " };
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