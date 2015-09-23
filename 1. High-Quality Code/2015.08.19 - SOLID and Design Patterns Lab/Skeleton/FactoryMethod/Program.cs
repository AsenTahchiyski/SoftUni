namespace TankManufacturer
{
    using System;
    using FactoryMethod.Factories;

    class Program
    {
        static void Main()
        {
            var germanFactory = new GermanTankFactory();
            var russianFactory = new RussianTankFactory();
            var americanFactory = new AmericanTankFactory();

            var tigerTank = germanFactory.CreateTank();
            var t34Tank = russianFactory.CreateTank();
            var m1Abrams = americanFactory.CreateTank();

            Console.WriteLine(tigerTank);
            Console.WriteLine();
            Console.WriteLine(t34Tank);
            Console.WriteLine();
            Console.WriteLine(m1Abrams);
        }
    }
}
