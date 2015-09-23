namespace Theatre.DataModels
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string name, DateTime start, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.Name = name;
            this.Start = start;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; private set; }

        public string Name { get; private set; }

        public DateTime Start { get; private set; }

        public TimeSpan Duration { get; private set; }

        protected internal decimal Price { get; private set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            int tmp = this.Start.CompareTo(otherPerformance.Start);
            return tmp;
        }

        public override string ToString()
        {
            string result = string.Format("Performance(Theatre: {0}; Name: {1}; Start: {2}, Duration: {3}, Price: {4})", this.Theatre, this.Name, this.Start.ToString("dd.MM.yyyy HH:mm"), this.Duration.ToString("hh':'mm"), this.Price.ToString("f2"));
            return result;
        }
    }
}
