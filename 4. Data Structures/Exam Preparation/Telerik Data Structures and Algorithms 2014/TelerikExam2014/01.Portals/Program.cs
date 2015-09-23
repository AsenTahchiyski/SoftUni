namespace _01.Portals
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    class Program
    {
        private const string ImpassableSymbol = "#";

        static void Main()
        {
            // get initial input data
            string[] startLocation = Console.ReadLine().Split(' ');
            int startingRow = int.Parse(startLocation[0]);
            int startingCol = int.Parse(startLocation[1]);

            string[] matrixSize = Console.ReadLine().Split(' ');
            int rows = int.Parse(matrixSize[0]);
            int cols = int.Parse(matrixSize[1]);

            // fill matrix
            string[,] matrix = new string[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string[] rowElements = Console.ReadLine().Split(' ');
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            Cell startCell = new Cell(matrix[startingRow, startingCol], startingRow, startingCol);
            Tree tree = new Tree(new TreeNode(int.Parse(startCell.Value), startingRow, startingCol));


        }

        public Tree TraverseTree(Tree tree, TreeNode startCell, string[,] matrix)
        {
            foreach (TreeNode child in startCell.GetChildren())
            {
                Cell currentCell = new Cell(child.Value.ToString(), child.Row, child.Col);
                IEnumerable<Cell> cellsInRange = GetCellsInRange(currentCell, matrix);
                foreach (Cell cell in cellsInRange)
                {
                    
                }
            }

            return tree;
        }

        public IEnumerable<Cell> GetCellsInRange(Cell cell, string[,] matrix)
        {
            if (!char.IsDigit(cell.Value[0]))
            {
                return null;
            }

            List<Cell> cellsinRange = new List<Cell>();
            int cellValue = int.Parse(cell.Value);

            Cell upperCell = new Cell(matrix[cell.Row + cellValue, cell.Col], cell.Row, cell.Col);
            Cell lowerCell = new Cell(matrix[cell.Row - cellValue, cell.Col], cell.Row, cell.Col);
            Cell leftCell = new Cell(matrix[cell.Row, cell.Col - cellValue], cell.Row, cell.Col);
            Cell rightCell = new Cell(matrix[cell.Row, cell.Col + cellValue], cell.Row, cell.Col);

            if (IsValid(upperCell, matrix))
            {
                cellsinRange.Add(upperCell);
            }

            if (IsValid(lowerCell, matrix))
            {
                cellsinRange.Add(lowerCell);
            }

            if (IsValid(leftCell, matrix))
            {
                cellsinRange.Add(leftCell);
            }

            if (IsValid(rightCell, matrix))
            {
                cellsinRange.Add(rightCell);
            }

            return cellsinRange;
        }

        public static bool IsValid(Cell cell, string[,] matrix)
        {
            return cell.Row >= 0 && cell.Row < matrix.GetLength(0) &&
                   cell.Col >= 0 && cell.Col < matrix.GetLength(1) &&
                   cell.Value != ImpassableSymbol && !cell.Visited;
        }
    }

    class Cell
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public string Value { get; set; }
        public bool Visited { get; set; }

        public Cell(string value, int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
            this.Visited = false;
        }
    }

    class Tree
    {
        private readonly TreeNode root;

        public TreeNode GetRoot()
        {
            return this.root;
        }

        public Tree(TreeNode root)
        {
            this.root = root;
        }
    }

    class TreeNode
    {
        private readonly List<TreeNode> children;
        private readonly TreeNode parent;
        
        public int Value { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }

        public TreeNode(int value, int row, int col)
        {
            this.Col = col;
            this.Row = row;
            this.Value = value;
            this.parent = null;
            this.children = new List<TreeNode>();
        }

        public TreeNode GetParent()
        {
            return this.parent;
        }

        public IEnumerable<TreeNode> GetChildren()
        {
            return this.children;
        }

        public void AddChild(TreeNode child)
        {
            this.children.Add(child);
        }
    }
}
