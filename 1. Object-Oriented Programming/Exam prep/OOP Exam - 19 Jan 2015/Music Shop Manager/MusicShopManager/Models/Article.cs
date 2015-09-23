namespace MusicShop.Models
{
    using System;
    using MusicShopManager.Interfaces;

    internal abstract class Article : IArticle
    {
        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get { return this.make; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterRequired, "make"));
                }
                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterRequired, "model"));
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterPositive, "price"));
                }
                this.price = value;
            }
        }
    }
}
