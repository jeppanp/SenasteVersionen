using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3VG.MyMonster.Grass
{
class Scarab : Monster, IMonster
{

    static List<string> scarabNames = new List<string>() { "Insek", "Krypet", "Bäfis", "Tvestjärt", "Ekoxe", "millipede" };
    public Scarab()
    {
        this.Name = scarabNames[Tools.MonsterNames()];
        this.Element = "grass";
        this.Race = "Scarab";
        this.Sound = "You hear the sound of his movement: tik tik tik tik";
        this.Lvl = Tools.RandomLvl();
        this.HP = 50 + (Lvl * 4);
        this.DropGold = 15 + (Lvl * 3);  // Skriv en random drop? 
        this.Experience = 50 + (Lvl * 2);
        this.Damage = (int)Math.Round(Lvl * 1.5);
        this.AttackNames = new List<string>() { "Posion Hit", "Bite", "Fart" };

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

