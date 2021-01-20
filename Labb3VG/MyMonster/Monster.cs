using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Labb3VG.MyMonster
{
   abstract class Monster : IMonster
    {
        public string Name { get; set; }

        public int HP { get; set; }

        public int DropGold { get; set; }

        public int Experience { get; set; }

        public int Lvl { get; set; }

        public string Race { get; set; }
        public string Sound { get; set; }

        public string Element { get; set; }
        public int Damage { get; set; }

        public List<string> AttackNames { get; set; }
        public bool Dead { get; set; }

        virtual public void Greetings()
        {
            Console.WriteLine($" Ooohh. You run into {Name}, a {Race} (lvl {Lvl}).{Sound}");
        }

        virtual public void TakeDamage(int damage)
        {
            HP -= damage;
        }
        virtual public void BattleStatus()
        {
            Console.WriteLine($"{Name}: {HP}");
        }

        public override string ToString()
        {
            return "Name: "+ Name +  "\nHP: " + HP + "\nLvl: " + Lvl + "\nRace: " + Race; ;
        }

        abstract public int Attack();
    
            

        
    }


}
