namespace GalacticGPS
{
    using System;

    struct Location
    {
        private double latitude;
        private double longtitude;

        public Location(double lat, double longt, Planet planet) : this()
        {
            this.Latitude = lat;
            this.Longtitude = longt;
            this.Planet = planet;
        }

        public double Latitude 
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (value > 90 || value < -90)
                {
                    throw new ArgumentOutOfRangeException("Invalid latitude, please choose a value between -90 and 90.");
                }
                this.latitude = value;
            }
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
            }
            set
            {
                if (value > 180 || value < -180)
                {
                    throw new ArgumentOutOfRangeException("Invalid longtitude, please choose a value between -180 and 180.");
                }
                this.longtitude = value;
            }
        }

        public Planet Planet { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1} - {2}", this.Latitude, this.Longtitude, this.Planet);
        }
    }
}
