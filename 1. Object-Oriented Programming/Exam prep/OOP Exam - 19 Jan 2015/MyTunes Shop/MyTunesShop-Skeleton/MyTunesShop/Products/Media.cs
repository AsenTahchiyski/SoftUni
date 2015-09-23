namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;

    public abstract class Media : IMedia, IRateable
    {
        private static readonly int MinYear = DateTime.MinValue.Year;
        private static readonly int MaxYear = DateTime.Now.Year;

        private static readonly int MinRating = 1;
        private static readonly int MaxRating = 5;
        
        private string title;
        private decimal price;
        private int year;
        private IList<int> ratings;
        private IPerformer performer;
        private string genre;

        protected Media(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
            this.ratings = new List<int>();
        }
        
        public string Title
        {
            get { return this.title; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ValueNotSpecified, "title"));
                }
                this.title = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ValueMustBeNonNegative, "price"));
                }
                this.price = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            protected set
            {
                if (value < MinYear || value > MaxYear)
                {
                    throw new ArgumentException(string.Format("The year of a song must be between {0} and {1}.", MinYear, MaxYear));
                }

                this.year = value;
            }
        }

        public IPerformer Performer
        {
            get
            {
                return this.performer;
            }

            protected set
            {
                if (value == null)
                {
                    throw new ArgumentException(string.Format("The performer of a {0} is required.", this.GetType().Name));
                }

                this.performer = value;
            }
        }

        public string Genre
        {
            get
            {
                return this.genre;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format("The genre of a {0} is required.", this.GetType().Name));
                }

                this.genre = value;
            }
        }

        public IList<int> Ratings
        {
            get { return this.ratings; }
        }

        public void PlaceRating(int rating)
        {
            if (rating < MinRating || rating > MaxRating)
            {
                throw new Exception(string.Format(ErrorMessages.ValueOutOfRange, "rating", MinRating, MaxRating));
            }
            this.ratings.Add(rating);
        }
    }
}
