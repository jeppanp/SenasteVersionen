using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using Labb3VG.MyMonster.Water;
using Labb3VG.MyMonster;



namespace Labb3VG
{
    static class Utility
    {
        static Random random = new Random();
        static int nr;
        static bool hit;
        

        public static Monster PickMonster()
        {
            Monster monster;
            
                                                                            // Depeding on the player lvls, a monster the fit his ranking is selected. First through a sort and then a random pick. 
            if (GameLogic.player.Lvl < 4)
            {
                monster = RandomMonster(0,4);
            }
            else if (GameLogic.player.Lvl >= 4 && GameLogic.player.Lvl < 7)
            {
                monster = RandomMonster(2, 8);   
            }
            else
            {
                monster = RandomMonster(4, 11);
            }


            return monster;
        }

        private static Monster RandomMonster(int x, int y)
        {
            List<Monster> TemporaryMonsterList = new List<Monster>();

            foreach (var elemet in GameLogic.monsterList)
            {
                if (elemet.Lvl > x && elemet.Lvl < y )
                {
                    TemporaryMonsterList.Add(elemet);
                }
            }

            nr = random.Next(TemporaryMonsterList.Count);

            return TemporaryMonsterList[nr];
        }

        public static int Adventurering()
        {
            nr = random.Next(1,101);
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


            return nr = random.Next(1, 11);
        }
        public static int Number1To100()
        {


            return nr = random.Next(1, 101);
        }

        public static bool AttackOrMissMonster()     // 10 procent to miss the attack for monsters
        {

            if (Number1To100() > 10)
            {
                hit = true;
            }
            else
            {
                hit = false;
            }
            return hit;
        }

        public static bool AttackOrMissPlayer()     // 5 procent to miss the attack for player
        {

            if (Number1To100() > 5)
            {
                hit = true;
            }
            else
            {
                hit = false;
            }
            return hit;
        }

        public static int StrenghtInAttack(int strenght)
        {
            nr = random.Next(1, 3);

            if (strenght > 5)
            {
                nr = random.Next(4, 7);
            }

            return nr + strenght;
        }

    }
}
