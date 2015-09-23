namespace Battleships.Ships
{
    using System;

    public class Warship : Battleship
    {
        public Warship(string name, double lengthInMeters, double volume)
        {
            this.Name = name;
            this.LengthInMeters = lengthInMeters;
            this.Volume = volume;
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyTarget(targetShip);
            return "Victory is ours!";
        }
    }
}
