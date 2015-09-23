namespace Theatre.DataModels
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;

    internal class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> performancesDatabase = new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatre)
        {
            if (this.performancesDatabase.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.performancesDatabase.Add(theatre, new SortedSet<Performance>());
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.performancesDatabase.Keys;
            return theatres;
        }

        public void AddPerformance(string theatre, string name, DateTime start, TimeSpan duration, decimal price)
        {
            if (!this.performancesDatabase.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.performancesDatabase[theatre];
            DateTime performanceEnd = start + duration;

            if (CheckForPerformanceOverlapping(performances, start, performanceEnd))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(theatre, name, start, duration, price);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.performancesDatabase.Keys;
            var allPerformances = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performances = this.performancesDatabase[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        public IEnumerable<Performance> ListPerformances(string theatre)
        {
            if (!this.performancesDatabase.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.performancesDatabase[theatre];
            return performances;
        }

        protected internal static bool CheckForPerformanceOverlapping(IEnumerable<Performance> performances, DateTime checkStart, DateTime checkEnd)
        {
            foreach (var existingPerformance in performances)
            {
                var existingPerformanceEnd = existingPerformance.Start + existingPerformance.Duration;

                bool check =
                    (existingPerformance.Start <= checkStart && checkStart <= existingPerformanceEnd) ||
                    (existingPerformance.Start <= checkEnd && checkEnd <= existingPerformanceEnd) ||
                    (checkStart <= existingPerformance.Start && existingPerformance.Start <= checkEnd) ||
                    (checkStart <= existingPerformanceEnd && existingPerformanceEnd <= checkEnd);

                if (check)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
