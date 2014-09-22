using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer_V2
{
    class Player
    {
        public enum AttackType
        {
            Sword = 1,
            Magic,
            Heal
        }
        private Random rng = new Random();
        public int HP { get; set; }
        public int Attacks { get; set; }
        public string Name { get; set; }
        //Constructor
        public Player(int hp, string name)
        {
            this.HP = hp;
            this.Attacks = 0;
            this.Name = name;
        }

        public bool IsAlive
        {
            get
            {
                return this.HP > 0;
            }
        }

                private AttackType ChooseAttack()
        {
            Console.WriteLine("\nChoose an attack");
            int input = int.Parse(Console.ReadLine());
            return (AttackType)input;
        }

        public void Attack(Enemy enemy)
        {
            switch (ChooseAttack())
            {
                case AttackType.Sword:
                    if (rng.Next(1, 101) < 70)
                    {
                        Console.Clear();
                        int swordDmg = rng.Next(15, 31);
                        Console.WriteLine("{0} hit {1} for {2} damage.", this.Name, enemy.Name, swordDmg);
                        enemy.HP -= swordDmg;
                        Attacks++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You missed {0}.", enemy.Name);
                    }
                    break;
                case AttackType.Magic:
                    Console.Clear();
                    int magicDmg = rng.Next(5, 16);
                    Console.WriteLine("{0} hit {1} for {2} damage.", this.Name, enemy.Name, magicDmg);
                    enemy.HP -= magicDmg;
                    Attacks++;
                    break;
                case AttackType.Heal:
                    Console.Clear();
                    int heal = rng.Next(10, 21);
                    this.HP += heal;
                    Console.WriteLine("{0} healed for {1} HP.", this.Name, heal);
                    break;
                default:
                    break;
            }
        }
    }
}
