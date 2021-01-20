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
            this.Name = waspNames[Tools.MonsterNames()];
            this.Element = "grass";
            this.Race = "Wasp";
            this.Sound = "You can hear the sound when he fly, \"Bssssss\"";
            this.Lvl = Tools.RandomLvl();
            this.HP = 50 + (Lvl * 4);
            this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (int)Math.Round(Lvl * 1.5);
            this.AttackNames = new List<string>() { "Posion Stinger", "Annoying Sound", "Wing Attack" };

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

