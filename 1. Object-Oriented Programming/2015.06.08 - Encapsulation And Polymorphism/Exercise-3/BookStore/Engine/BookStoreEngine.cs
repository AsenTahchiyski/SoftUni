namespace BookStore.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Books;
    using BookStore.Interfaces;

    public class BookStoreEngine
    {
        private readonly List<Book> books;
        private decimal revenue;
        private readonly IRenderer renderer;
        private readonly IInputHandler inputHandler;
        private readonly FileRenderer fileRenderer;

        public BookStoreEngine(IRenderer renderer, IInputHandler inputHandler)
        {
            this.IsRunning = true;
            this.books = new List<Book>();
            this.revenue = 0;
        }

        public bool IsRunning { get; private set; }

        public void Run()
        {
            while (this.IsRunning)
            {
                string command = this.inputHandler.ReadLine();

                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }

                string[] commandArgs = command.Split();

                string commandResult = this.ExecuteCommand(commandArgs);

                this.renderer.WriteLine(commandResult);
            }

            this.renderer.WriteLine(string.Format("Total revenue: {0:F2}", this.revenue));
        }

        public string ExecuteSellBookCommand(string title)
        {
            Book bookToSell = this.books.FirstOrDefault(book => book.Title == title);

            this.revenue += bookToSell.Price;
            this.books.Remove(bookToSell);
            return "Book sold";
        }

        public string ExecuteRemoveBookCommand(string title)
        {
            Book bookToRemove = this.books.FirstOrDefault(book => book.Title == title);

            if (bookToRemove == null)
            {
                return "Book does not exist";
            }

            this.books.Remove(bookToRemove);
            return "Book removed";
        }

        private string ExecuteCommand(string[] commandArgs)
        {
            switch (commandArgs[0])
            {
                case "add":
                    return this.ExecuteAddBookCommand(commandArgs);
                case "sell": 
                    return this.ExecuteSellBookCommand(commandArgs[1]);
                case "remove":
                    return this.ExecuteRemoveBookCommand(commandArgs[1]);
                case "stop":
                    this.IsRunning = false;
                    return "Goodbye!";
                default:
                    return "Unknown command";
            }
        }

        private string ExecuteAddBookCommand(string[] commandArgs)
        {
            string title = commandArgs[1];
            string author = commandArgs[2];
            decimal price = decimal.Parse(commandArgs[3]);

            this.books.Add(new Book(title, author, price));

            return "Book added";
        }
    }
}
