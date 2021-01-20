using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Fire
{
    class DragonLord : Monster, IMonster
    {

        public DragonLord()
        {
            this.Name = "The Red Nightmare";
            this.Element = "fire";
            this.Race = "Dragon Lord";
            this.Sound = " He Yells FCHHHHHHHH, YOU WILL BUUUUURN";
            this.Lvl = 10;
            this.HP = 600;
            this.DropGold = 240;  // Skriv en random drop? 
            this.Experience = 150;
            this.Damage = 30;
            this.AttackNames = new List<string>() { "Wall Of Fire ", "Fire Flame", "Great Fireball " };
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