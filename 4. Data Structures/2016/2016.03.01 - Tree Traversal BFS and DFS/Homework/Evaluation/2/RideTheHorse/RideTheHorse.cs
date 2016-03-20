namespace RideTheHorse
{
	using System;
	using System.Collections.Generic;

	class RideTheHorse
	{
		static void Main()
		{
			var rows = int.Parse(Console.ReadLine());
			var colums = int.Parse(Console.ReadLine());

			var matrix = new int[rows][];

			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new int[colums];
			}

			for (int i = 0; i < matrix.Length; i++)
			{
				matrix[i] = new int[colums];
			}

			int startY = int.Parse(Console.ReadLine());
			int startX = int.Parse(Console.ReadLine());

			var turnsQueue = new Queue<Step>();

			turnsQueue.Enqueue(new Step(startY, startX));

			while (turnsQueue.Count != 0)
			{
				var current = turnsQueue.Dequeue();

				var currentY = current.Y;
				var currentX = current.X;

				if (matrix[currentY][currentX] == 0)
				{
					matrix[currentY][currentX] = current.Turn;
				}

				if (CanStep(currentY - 2, currentX - 1, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY - 2, currentX - 1, current.Turn + 1));
				}

				if (CanStep(currentY - 1, currentX - 2, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY - 1, currentX - 2, current.Turn + 1));
				}

				if (CanStep(currentY - 2, currentX + 1, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY - 2, currentX + 1, current.Turn + 1));
				}

				if (CanStep(currentY - 1, currentX + 2, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY - 1, currentX + 2, current.Turn + 1));
				}

				if (CanStep(currentY + 2, currentX - 1, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY + 2, currentX - 1, current.Turn + 1));
				}

				if (CanStep(currentY + 1, currentX - 2, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY + 1, currentX - 2, current.Turn + 1));
				}

				if (CanStep(currentY + 2, currentX + 1, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY + 2, currentX + 1, current.Turn + 1));
				}

				if (CanStep(currentY + 1, currentX + 2, matrix, current.Turn))
				{
					turnsQueue.Enqueue(new Step(currentY + 1, currentX + 2, current.Turn + 1));
				}
			}
			Console.WriteLine();
			Print(matrix, colums / 2);
		}

		private static void Print(int[][] matrix, int colum)
		{
			for (int row = 0; row < matrix.Length; row++)
			{
				Console.WriteLine(matrix[row][colum]);
			}
		}

		private static bool CanStep(int currentY, int currentX, int[][] matrix, int turn)
		{
			return currentY >= 0 && currentY < matrix.Length && currentX >= 0 && currentX < matrix[0].Length &&
			  matrix[currentY][currentX] == 0;
		}
	}

	public class Step
	{
		public Step(int y, int x, int turn = 1)
		{
			this.Y = y;
			this.X = x;
			this.Turn = turn;
		}

		public int X { get; set; }

		public int Y { get; set; }

		public int Turn { get; set; }
	}
}
