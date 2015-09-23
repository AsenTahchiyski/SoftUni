namespace Battleships.Ships
{
    using System;

    public class Yacht : Ship
    {
        public Yacht(string name, double lengthInMeters, double volume)
        {
            this.Name = name;
            this.LengthInMeters = lengthInMeters;
            this.Volume = volume;
        }

    }
}
