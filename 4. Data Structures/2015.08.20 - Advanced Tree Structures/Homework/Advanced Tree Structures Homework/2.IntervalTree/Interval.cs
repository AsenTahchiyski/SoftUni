//// https://github.com/vvondra/Interval-Tree
namespace _2.IntervalTree
{
    using System;

    public struct Interval<T> : IComparable<Interval<T>> where T: struct, IComparable<T>
    {
        private T start;
        private T end;
            
        public Interval(T start, T end) 
            : this()
        {
            this.Start = start;
            this.End = end;
        }

        public T Start 
        {
            get { return this.start; }
            set
            {
                if (!this.End.Equals(default(T)) && this.End.CompareTo(value) > 0)
                {
                    throw new ArgumentException("Start", "Interval start cannot be smaller than its end.");
                }

                this.start = value;
            }
        }

        public T End
        {
            get { return this.end; }
            set
            {
                if (!this.Start.Equals(default(T)) && this.Start.CompareTo(value) > 0)
                {
                    throw new ArgumentException("End", "Interval end cannot be bigger than its end.");
                }

                this.end = value;
            }
        }

        public bool Contains(Interval<T> interval)
        {
            return Start.CompareTo(interval.Start) <= 0 && End.CompareTo(interval.End) >= 0;
        }

        public bool Contains(T val)
        {
            return Start.CompareTo(val) <= 0 && End.CompareTo(val) >= 0;
        }

        public bool Overlaps(Interval<T> interval)
        {
            return Start.CompareTo(interval.End) <= 0 && End.CompareTo(interval.Start) >= 0;
        }

        public int CompareTo(Interval<T> interval)
        {
            if (this.Start.CompareTo(interval.Start) < 0)
            {
                return -1;
            }
            else if (this.Start.CompareTo(interval.Start) > 0)
            {
                return 1;
            }
            else if (this.End.CompareTo(interval.End) < 0)
            {
                return 1;
            }
            else if (this.End.CompareTo(interval.End) > 0)
            {
                return -1;
            }

            // Identical interval
            return 0;
        }
    }
}
