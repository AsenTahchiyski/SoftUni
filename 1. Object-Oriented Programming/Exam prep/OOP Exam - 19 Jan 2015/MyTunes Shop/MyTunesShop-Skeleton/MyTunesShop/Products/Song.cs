using System.Linq;
using System.Text;

namespace MyTunesShop
{
    using System;

    public class Song : Media, ISong
    {
        private string duration;

        public Song(string title, decimal price, IPerformer performer, string genre, int year, string duration)
            : base (title, price)
        {
            this.Title = title;
            this.Price = price;
            this.Performer = performer;
            this.Genre = genre;
            this.Year = year;
            this.Duration = duration;
        }

        public string Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The duration of a song is required.");
                }

                this.duration = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("{0} ({1}) by {2}", this.Title, this.Year, this.Performer));
            output.AppendLine(string.Format("Genre: {0}, Price:${1:F2}", this.Genre, this.Price));
            output.AppendLine(string.Format("Rating: {0:F0.0}", this.Ratings.Average()));
            output.AppendLine(string.Format("Supplies: {0}, Sold: {0}"));
            return output.ToString();
        }
    }
}
