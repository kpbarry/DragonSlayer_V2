using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer_V2
{
    class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        private Random rng = new Random();
        //Heh, public enemy
        public Enemy(string name, int hp)
        {
            this.Name = name;
            this.HP = hp;
        }

        public bool IsAlive
        {
            get
            {
                return this.HP > 0;
            }
        }

        public void Attack(Player player)
        {
            //80% chance to hit
            if (rng.Next(0, 101) > 20)
            {
                int damage = rng.Next(5, 16);
                player.HP -= damage;
                Console.WriteLine("{0} hit you for {1} damage!", this.Name, damage);
            }
            else
            {
                Console.WriteLine("{0} missed {1}.", this.Name, player.Name);
            }
        }
    }
}
