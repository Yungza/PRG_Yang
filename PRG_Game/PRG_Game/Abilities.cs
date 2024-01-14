using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PRG_Game
{
    public class Abilities
    {
        public string type;
        public string name;
        public int damage;
        public int accuracy;
        public string desciption;
        public virtual void DealDamage(Characters target)
        {
            Random rnd = new Random();
            int rng = rnd.Next(0,100);
            if (rng<= accuracy)
            {
                if (type == "fire" && target.type == "grass" || type == "grass" && target.type == "water" || type == "water" && target.type == "fire")
                {
                    target.healthPoint = target.healthPoint - (damage * 2);
                    Console.WriteLine($"super effective! {target.name} hp has decreased by {damage * 2} using {name}");
                }
                else if (type == target.type)
                {
                    target.healthPoint = target.healthPoint - damage;
                    Console.WriteLine($"{target.name} hp has decreased by {damage} using {name}");
                }
                else
                {
                    target.healthPoint = target.healthPoint - (damage / 2);
                    Console.WriteLine($"not very effective! {target.name} hp has deacreased by {damage/2} using {name}");
                }
            }
            else
            {
                Console.WriteLine("missed!");
            }
            Console.WriteLine("press any key to proceed");
            Console.ReadKey();
        }
    }
}
