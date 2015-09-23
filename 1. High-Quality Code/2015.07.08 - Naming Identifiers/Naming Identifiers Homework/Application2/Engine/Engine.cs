namespace MinesweeperGame
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        private const int MaxNumberOfMines = 35;
        private readonly IRenderer renderer;
        
        private string command = string.Empty;
        private char[,] playField = CreatePlayField();
        private char[,] mineField = PopulateMinesInField();
        private int currentPoints = 0;
        private bool isPlayerAlive = true;
        private List<IPlayer> highscores = new List<IPlayer>(6);
        private int row = 0;
        private int column = 0;
        private bool isRunning = false;
        private bool areAllMinesFound = false;

        public Engine(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void Run()
        {
            do
            {
                if (!this.isRunning)
                {
                    this.renderer.WriteLine("Welcome to Minesweeper! Try to find all cells that do not contain a mine.\n" +
                                      "The 'top' command shows the highscores, 'restart' starts a new game,\n" +
                                      "'exit' stops the game.");
                    this.DrawPlayField(this.playField);
                    this.isRunning = true;
                }

                this.renderer.Write("Please provide row and column numbers: ");
                this.command = this.renderer.ReadLine().Trim();
                if (this.command.Length >= 3)
                {
                    if (int.TryParse(this.command[0].ToString(), out this.row) && int.TryParse(this.command[2].ToString(), out this.column)
                        && this.row <= this.playField.GetLength(0) && this.column <= this.playField.GetLength(1))
                    {
                        this.command = "turn";
                    }
                }

                switch (this.command)
                {
                    case "top":
                        this.ShowHighScores(this.highscores);
                        break;
                    case "restart":
                        this.playField = CreatePlayField();
                        this.mineField = PopulateMinesInField();
                        this.DrawPlayField(this.playField);
                        this.isPlayerAlive = true;
                        this.isRunning = true;
                        break;
                    case "exit":
                        this.renderer.WriteLine("Bye-bye!");
                        break;
                    case "turn":
                        if (this.mineField[this.row, this.column] != '*')
                        {
                            if (this.mineField[this.row, this.column] == '-')
                            {
                                this.ProcessGameTurn(this.playField, this.mineField, this.row, this.column);
                                this.currentPoints++;
                            }

                            if (MaxNumberOfMines == this.currentPoints)
                            {
                                this.areAllMinesFound = true;
                            }
                            else
                            {
                                this.DrawPlayField(this.playField);
                            }
                        }
                        else
                        {
                            this.isPlayerAlive = false;
                        }

                        break;
                    default:
                        this.renderer.WriteLine("\nInvalid command.\n");
                        break;
                }

                if (!this.isPlayerAlive)
                {
                    this.DrawPlayField(this.mineField);
                    this.renderer.Write(string.Format("\nOh noes! You've stepped on a mine! Your score is {0}. " + "Enter your name: ", this.currentPoints));
                    string name = this.renderer.ReadLine();
                    IPlayer t = new Player(name, this.currentPoints);
                    if (this.highscores.Count < 5)
                    {
                        this.highscores.Add(t);
                    }
                    else
                    {
                        for (int i = 0; i < this.highscores.Count; i++)
                        {
                            if (this.highscores[i].Points < t.Points)
                            {
                                this.highscores.Insert(i, t);
                                this.highscores.RemoveAt(this.highscores.Count - 1);
                                break;
                            }
                        }
                    }

                    this.highscores.Sort((IPlayer r1, IPlayer r2) => r2.Name.CompareTo(r1.Name));
                    this.highscores.Sort((IPlayer r1, IPlayer r2) => r2.Points.CompareTo(r1.Points));
                    this.ShowHighScores(this.highscores);

                    this.playField = CreatePlayField();
                    this.mineField = PopulateMinesInField();
                    this.currentPoints = 0;
                    this.isPlayerAlive = true;
                    this.isRunning = false;
                }

                if (this.areAllMinesFound)
                {
                    this.renderer.WriteLine("\nCongratulations! You've opened 35 cells without stepping on a mine!");
                    this.DrawPlayField(this.mineField);
                    this.renderer.WriteLine("Enter your name: ");
                    string name = this.renderer.ReadLine();
                    IPlayer player = new Player(name, this.currentPoints);
                    this.highscores.Add(player);
                    this.ShowHighScores(this.highscores);
                    this.playField = CreatePlayField();
                    this.mineField = PopulateMinesInField();
                    this.currentPoints = 0;
                    this.areAllMinesFound = false;
                    this.isRunning = false;
                }
            }
            while (this.command != "exit");

            this.renderer.Read();
        }

        private static char[,] CreatePlayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PopulateMinesInField()
        {
            int rows = 5;
            int columns = 10;
            char[,] playField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playField[i, j] = '-';
                }
            }

            List<int> mineCoordinates = new List<int>();
            while (mineCoordinates.Count < 15)
            {
                Random random = new Random();
                int newMineCoorinates = random.Next(50);
                if (!mineCoordinates.Contains(newMineCoorinates))
                {
                    mineCoordinates.Add(newMineCoorinates);
                }
            }

            foreach (int mine in mineCoordinates)
            {
                int mineColumn = mine / columns;
                int mineRow = mine % columns;
                if (mineRow == 0 && mine != 0)
                {
                    mineColumn--;
                    mineRow = columns;
                }
                else
                {
                    mineRow++;
                }

                playField[mineColumn, mineRow - 1] = '*';
            }

            return playField;
        }

        private static char CalculateNearbyMineCount(char[,] playField, int row, int column)
        {
            int counter = 0;
            int rows = playField.GetLength(0);
            int columns = playField.GetLength(1);

            if (row - 1 >= 0)
            {
                if (playField[row - 1, column] == '*')
                {
                    counter++;
                }
            }

            if (row + 1 < rows)
            {
                if (playField[row + 1, column] == '*')
                {
                    counter++;
                }
            }

            if (column - 1 >= 0)
            {
                if (playField[row, column - 1] == '*')
                {
                    counter++;
                }
            }

            if (column + 1 < columns)
            {
                if (playField[row, column + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (playField[row - 1, column - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < columns))
            {
                if (playField[row - 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column - 1 >= 0))
            {
                if (playField[row + 1, column - 1] == '*')
                {
                    counter++;
                }
            }

            if ((row + 1 < rows) && (column + 1 < columns))
            {
                if (playField[row + 1, column + 1] == '*')
                {
                    counter++;
                }
            }

            return char.Parse(counter.ToString());
        }

        private void ShowHighScores(List<IPlayer> points)
        {
            this.renderer.WriteLine("\nPoints:");
            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    this.renderer.WriteLine(string.Format("{0}. {1} --> {2} cells", i + 1, points[i].Name, points[i].Points));
                }

                this.renderer.WriteLine(string.Empty);
            }
            else
            {
                this.renderer.WriteLine("Highscores are empty!\n");
            }
        }

        private void ProcessGameTurn(char[,] playField, char[,] bombField, int row, int column)
        {
            char numberOfMines = CalculateNearbyMineCount(bombField, row, column);
            bombField[row, column] = numberOfMines;
            playField[row, column] = numberOfMines;
        }

        private void DrawPlayField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            this.renderer.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            this.renderer.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                this.renderer.Write(string.Format("{0} | ", i));
                for (int j = 0; j < columns; j++)
                {
                    this.renderer.Write(string.Format("{0} ", board[i, j]));
                }

                this.renderer.Write("|");
                this.renderer.WriteLine(string.Empty);
            }

            this.renderer.WriteLine("   ---------------------\n");
        }

        ////private static void PopulateMineCountNumbers(char[,] playField)
        ////{
        ////    int columns = playField.GetLength(0);
        ////    int rows = playField.GetLength(1);

        ////    for (int i = 0; i < columns; i++)
        ////    {
        ////        for (int j = 0; j < rows; j++)
        ////        {
        ////            if (playField[i, j] != '*')
        ////            {
        ////                char nearbyMineCount = CalculateNearbyMineCount(playField, i, j);
        ////                playField[i, j] = nearbyMineCount;
        ////            }
        ////        }
        ////    }
        ////}
    }
}