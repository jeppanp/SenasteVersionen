using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Labb3VG.MyMonster.Water;
using Labb3VG.MyMonster;



namespace Labb3VG
{
    static class Tools
    {
        static Random random = new Random();
        static int nr;

        public static Monster RandomisedMonster()
        {
            Monster monster;
            

            if (GameLogic.player.Lvl < 3)
            {
                monster = GameLogic.monsterList.Find(x => x.Lvl <= 3);
                GameLogic.monsterList.Remove(monster);
            }
            else if (GameLogic.player.Lvl >= 4 && GameLogic.player.Lvl < 7)
            {
                monster = GameLogic.monsterList.Find(x => x.Lvl >= 3 && x.Lvl <= 7);

                GameLogic.monsterList.Remove(monster);
            }
            else 
            {
                monster = GameLogic.monsterList.Find(x => x.Lvl >= 7);
                GameLogic.monsterList.Remove(monster);
            }


            return monster;
        }
        public static int FindingMonster()
        {
            nr = random.Next(101);
            if (nr >= 15)               //85 procent to run into a monster
            {
                return 1;
            }
            else if (nr <= 5)           // 5 procent to find gold
            {
                return 2;
            }
            else                        // 10 procent change of findining nothing
            {
                return 3;
            }
        }
        public static int AttackNames()
        {
            return random.Next(3);
        }
        public static int MonsterNames()
        {

            return random.Next(6);
        }

        public static int RandomLvl()
        {

            return random.Next(1, 11);
        }

        public static int Number1To10()
        {
            nr = random.Next(1, 11);

            return nr;
        }

        public static int AttackOrMiss()     // 10 procent to miss the attack for monsters
        {

            if (Number1To10() != 1)
            {
                nr = 1;
            }
            else
            {
                nr = 2;
            }
            return nr;
        }

        public static int StrenghtInAttack(int strengtMonster)
        {
            nr = random.Next(1, 3);

            if (strengtMonster > 5)
            {
                nr = random.Next(1, 7);
            }

            return nr + strengtMonster;
        }

    }
}
