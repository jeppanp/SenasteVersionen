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
            this.Name = dragonNames[Tools.MonsterNames()];
            this.Element = "fire";
            this.Race = "Dragon";
            this.Sound = "You hear the sound of FCHHHHHHHH";
            this.Lvl = Tools.RandomLvl();
            this.HP = 50 + (Lvl * 4);
            this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (int)Math.Round(Lvl * 1.5);
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