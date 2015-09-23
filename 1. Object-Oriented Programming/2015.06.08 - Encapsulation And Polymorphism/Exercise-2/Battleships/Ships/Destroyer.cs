namespace Battleships.Ships
{
    using System;

    public class Destroyer : Battleship
    {
        private int numberOfAmmunition;

        public Destroyer(string name, double lengthInMeters, double volume, int numberOfAmmunition)
        {
            this.Name = name;
            this.LengthInMeters = lengthInMeters;
            this.Volume = volume;
            this.NumberOfAmmunition = numberOfAmmunition;
        }

        public int NumberOfAmmunition
        {
            get
            {
                return this.numberOfAmmunition;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The number of ammunition in a destroyer cannot be negative.");
                }

                this.numberOfAmmunition = value;
            }
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "They didn't see us coming!";
        }
    }
}
