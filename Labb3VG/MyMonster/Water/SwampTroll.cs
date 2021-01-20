using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Labb3VG.MyMonster.Water
{
    class SwampTroll : Monster, IMonster
    {

        static List<string> trollNames = new List<string>() { "Goliat", "Ymer", "Rölli", "Melker", "Rumpnisse", "Smegael" };

        public SwampTroll()
        {
            this.Name = trollNames[Tools.MonsterNames()];
            this.Element = "water";
            this.Race = "swamp troll";
            this.Sound = " He mumble for himself \"Hmmm, bugs\"";
            this.Lvl = Tools.RandomLvl();
            this.HP = 50 + (Lvl * 4);
            this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (int)Math.Round(Lvl * 1.5);
            this.AttackNames = new List<string>() { "Fist Pump","Bite","Human Throw"};

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
    
        
    





