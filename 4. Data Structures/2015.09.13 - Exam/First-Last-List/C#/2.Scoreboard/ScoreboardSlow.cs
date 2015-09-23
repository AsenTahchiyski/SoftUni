namespace _2.Scoreboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class ScoreboardSlow1
    {
        private SortedDictionary<string, Game> gamesByName = 
            new SortedDictionary<string, Game>();
        private SortedDictionary<string, User> usersByName = 
            new SortedDictionary<string, User>(); 
        private Dictionary<string, OrderedMultiDictionary<int, string>> scoresByGame
            = new Dictionary<string, OrderedMultiDictionary<int, string>>();
        private SortedSet<string> gameNames = new SortedSet<string>(); 

        public bool RegisterUser(string username, string password)
        {
            if (this.usersByName.ContainsKey(username))
            {
                Console.WriteLine("Duplicated user");
                return false;
            }

            User newUser = new User(username, password.GetHashCode().ToString()); // fast?
            this.usersByName.Add(username, newUser);
            Console.WriteLine("User registered");
            return true;
        }

        public bool RegisterGame(string gameName, string password)
        {
            if (this.gamesByName.ContainsKey(gameName))
            {
                Console.WriteLine("Duplicated game");
                return false;
            }

            Game newGame = new Game(gameName, password.GetHashCode().ToString());
            this.gamesByName.Add(gameName, newGame);
            this.scoresByGame.Add(gameName, new OrderedMultiDictionary<int, string>(true));
            this.gameNames.Add(gameName);
            Console.WriteLine("Game registered");
            return true;
        }

        public bool AddScore(string userName, string userPassword, 
            string gameName, string gamePassword, int score)
        {
            bool userExists = this.usersByName.ContainsKey(userName);
            bool gameExists = this.gamesByName.ContainsKey(gameName);
            if (!userExists || !gameExists)
            {
                Console.WriteLine("Cannot add score");
                return false;
            }

            bool userPasswordsMatch = 
                this.usersByName[userName].Password == userPassword.GetHashCode().ToString();
            bool gamePasswordsMatch = 
                this.gamesByName[gameName].Password == gamePassword.GetHashCode().ToString();
            if (!userPasswordsMatch || !gamePasswordsMatch)
            {
                Console.WriteLine("Cannot add score");
                return false;
            }

            this.usersByName[userName].ScoresByGame.Add(gameName, score);
            this.scoresByGame[gameName].Add(score, userName);
            Console.WriteLine("Score added");
            return true;
        }

        public void ShowScoreboard(string gameName)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                Console.WriteLine("Game not found");
            }

            var gameScores = this.scoresByGame[gameName];
            if (gameScores.Count == 0)
            {
                Console.WriteLine("No score");
            }

            int resultsPrinted = 0;
            foreach (var score in gameScores)
            {
                foreach (var player in score.Value)
                {
                    if (resultsPrinted > 9)
                    {
                        break;
                    }

                    Console.WriteLine("#{0} {1} {2}", resultsPrinted + 1, player, score.Key);
                    resultsPrinted++;
                }
                
            }
        }

        public void ListGamesByPrefix(string prefix)
        {
            var gamesMatching = this.gameNames.GetViewBetween(prefix, prefix);
            if (gamesMatching.Count == 0)
            {
                Console.WriteLine("No matches");
                return;
            }

            var result = gamesMatching.ToList();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(result[i]);
                if (i < 9)
                {
                    Console.Write(", ");
                }
            }
        }

        public bool DeleteGame(string gameName, string password)
        {
            if (!this.gamesByName.ContainsKey(gameName))
            {
                Console.WriteLine("Cannot delete game");
                return false;
            }

            this.gamesByName.Remove(gameName);
            this.gameNames.Remove(gameName);
            this.scoresByGame.Remove(gameName);
            Console.WriteLine("Game deleted");
            return true;
        }
    }

    public class Game
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public IEnumerable<int> Score { get; set; }

        public Game(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            this.Score = new List<int>();
        }
    }

    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public MultiDictionary<string, int> ScoresByGame { get; set; }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            this.ScoresByGame = new MultiDictionary<string, int>(true);
        }
    }
}
