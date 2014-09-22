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

        public int DoAttack()
        {
            Random rng = new Random();
            int enemyDmg = rng.Next(5, 16);
            int HitChance = rng.Next(1, 101);
            if (HitChance < 20)
            {
                Console.WriteLine("The " + this.Name + " barely missed you!");
                return 0;
            }
            //Take damage
            else
            {
                return enemyDmg;
            }
        }

        public void TakeDamage(int damage)
        {
            this.HP -= damage;
            if (this.HP <= 0)
                Console.WriteLine("You have slain the dragon!");
        }
    }
}
