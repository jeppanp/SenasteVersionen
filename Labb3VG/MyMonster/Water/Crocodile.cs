using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Labb3VG.MyMonster.Water
{
    class Crocodile : Monster
    {

        static List<string> crocNames = new List<string>() { "Crocks", "Allie", "Green Tail", "Lolong", "Steve Irwin", "Delta" };

        public Crocodile()
        {
            this.Name = crocNames[Tools.MonsterNames()];
            this.Element = "water";
            this.Race = "Crocodile";
            this.Sound = "Rooooaaarrrrr";
            this.Lvl= Tools.RandomLvl();
            this.HP = 50 + (Lvl*4);
            this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
            this.Experience = 50 + (Lvl * 2);
            this.Damage = (int)Math.Round(Lvl * 1.5);
            this.AttackNames =  new List<string>() { "Tail Snapper", "Bite", "claw demolition" };

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
