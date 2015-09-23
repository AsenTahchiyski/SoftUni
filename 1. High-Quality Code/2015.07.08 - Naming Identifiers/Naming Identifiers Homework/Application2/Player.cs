namespace MinesweeperGame
{
    using System;

    public class Player : IPlayer
    {
        private string name;
        private int points;

        public Player(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("points", "Points cannot be negative.");
                }

                this.points = value;
            }
        }
    }
}
