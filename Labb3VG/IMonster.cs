using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using Labb3VG.MyMonster;

namespace Labb3VG
{
    interface IMonster
    {
        public string Name { get; }
        public int HP { get; set; }
        public int DropGold { get; set; }
        public int Experience { get; set; }
        public int Lvl { get; set; }
        public string Race { get; set; }
        public string Sound { get; set; }
        public string Element { get; set; }
        public int Damage { get; set; }
        public bool Dead { get; set; }


        public List<string> AttackNames { get; }

        public int Attack();



    }


}
