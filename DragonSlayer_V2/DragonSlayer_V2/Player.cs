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
            Brick = 1,
            Magic,
            Heal
        }

        public int HP { get; set; }
        public int Attacks { get; set; }
        //Constructor
        public Player(int hp)
        {
            this.HP = hp;
            this.Attacks = 0;
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

            string choiceString = Console.ReadLine();
            int choice = Convert.ToInt32(choiceString);
            switch (choice)
            {
                case 1:
                    return AttackType.Brick;
                case 2:
                    return AttackType.Magic;
                case 3:
                    return AttackType.Heal;
                default:
                    Console.WriteLine("Invalid choice.");
                    return 0;
            }
        }

        public int DoAttack()
        {
            Random rng = new Random();

            int HitChance = rng.Next(1, 101);

            if (ChooseAttack() == AttackType.Brick)
            {
                int dmg = rng.Next(20, 36);
                if (HitChance < 30)
                {
                    Console.WriteLine("You suck at throwing bricks!");
                    return 0;
                }
                else
                {
                    Attacks++;
                    Console.WriteLine("You hit your enemy for " + dmg + " damage.");
                    return dmg;
                }
            }
            else if (ChooseAttack() == AttackType.Magic)
            {
                Attacks++;
                int magicDmg = rng.Next(10, 16);
                Console.WriteLine("You hit your enemy for " + magicDmg + " damage.");
                return magicDmg;
            }
            else if (ChooseAttack() == AttackType.Heal)
            {
                int heal = rng.Next(10, 21);
                return this.HP += heal;
            }
            else
            {
                return 0;
            }
        }

        //Checks if HP is above 0
        public void TakeDamage(int damage)
        {
            this.HP -= damage;
            if (this.HP <= 0)
                Console.WriteLine("You have died.");
        }
    }
}
