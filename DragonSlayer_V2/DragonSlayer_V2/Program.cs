using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonSlayer_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 110;
            Game game = new Game();
            game.PlayGame();
            if (game.Enemy.IsAlive == false)
            {
                Console.WriteLine("You killed the enemy in " + game.Player.Attacks + " attacks.");
                AddHighScore(game.Player.Attacks);
                DisplayHighScores();
            }
            Console.ReadKey();
        }
        static void AddHighScore(int playerScore)
        {
            Console.WriteLine("Add your name to the list of high scores: ");
            string playerName = Console.ReadLine();

            //Create a gateway to the database
            KevinEntities db = new KevinEntities();

            //Create new high score object
            HighScore newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = "Dragon Slayer V2";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            //Add it to the database
            db.HighScores.Add(newHighScore);

            //Save changes to db
            db.SaveChanges();
        }

        static void DisplayHighScores()
        {
            Console.Clear();
            Console.WriteLine("Dragon Slayer V2 High Scores");
            Console.WriteLine("-----------------------------");

            KevinEntities db = new KevinEntities();
            List<HighScore> highScoreList = db.HighScores.Where(x => x.Game == "Dragon Slayer V2").OrderBy(x => x.Score).Take(10).ToList();
            foreach (HighScore i in highScoreList)
            {
                Console.WriteLine("{0}. {1} - {2} - {3}", highScoreList.IndexOf(i) + 1, i.Name, i.Score, i.DateCreated.Value.ToShortDateString());
            }
        }
    }
}
