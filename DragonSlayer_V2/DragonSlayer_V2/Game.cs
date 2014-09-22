using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer_V2
{
    class Game
    {
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        public Game()
        {
            this.Player = Player;
            this.Enemy = Enemy;
        }


        public void DisplayCombatInfo()
        {
            Console.WriteLine("Player HP:" + this.Player.HP + "\nEnemy HP: " + this.Enemy.HP);
        }

        public void PlayGame()
        {
            Console.WriteLine(@"______                                                   _  ______                                         
|  _  \                                                 | | |  _  \                                        
| | | |_ __ __ _  __ _  ___  _ __  ___    __ _ _ __   __| | | | | |_   _ _ __   __ _  ___  ___  _ __  ___  
| | | | '__/ _` |/ _` |/ _ \| '_ \/ __|  / _` | '_ \ / _` | | | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \/ __| 
| |/ /| | | (_| | (_| | (_) | | | \__ \ | (_| | | | | (_| | | |/ /| |_| | | | | (_| |  __/ (_) | | | \__ \ 
|___/ |_|  \__,_|\__, |\___/|_| |_|___/  \__,_|_| |_|\__,_| |___/  \__,_|_| |_|\__, |\___|\___/|_| |_|___/ 
                  __/ |                                                         __/ |                      
                 |___/                                                         |___/                        ");
            //Player HP
            Console.WriteLine("Please enter the amount of HP you want to have: ");
            string playerHPString = Console.ReadLine();
            int playerHP = Convert.ToInt32(playerHPString);

            //Enemy name
            Console.WriteLine("Please enter the name of your enemy: ");
            string enemyName = Console.ReadLine();

            //Enemy HP
            Console.WriteLine("Please enter the amount of HP you want " + enemyName + " to have: ");
            string enemyHPString = Console.ReadLine();
            int enemyHP = Convert.ToInt32(enemyHPString);

            //New enemy and player
            this.Player = new Player(playerHP);
            this.Enemy = new Enemy(enemyName, enemyHP);
            Console.WriteLine("You have 3 options for how to fight your enemy.\n 1. Throw brick (70% hit, 20-35 damage)\n 2. Dust attack (100% hit, 10-15 damage)\n 3. Heal (Repair self for 10-20 HP)\nPlease choose an action.\n");
            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {
                DisplayCombatInfo();
                this.Enemy.TakeDamage(this.Player.DoAttack());
                this.Player.TakeDamage(this.Player.DoAttack());
            }
        }

    }
}
