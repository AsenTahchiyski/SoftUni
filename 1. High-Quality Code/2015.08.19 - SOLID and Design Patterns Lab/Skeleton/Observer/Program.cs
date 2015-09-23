namespace Skyrim
{
    using System.Collections.Generic;
    using Units;

    class Program
    {
        static void Main()
        {
            // Dragon with 100 HP
            var dragon = new Dragon("Alduin", 300, 100);

            List<Warrior> warriors = new List<Warrior>
            {
                new Warrior("Ulfric Stormcloak", 80, 80),
                new Warrior("Cicero", 15, 50),
                new Warrior("Jarl Balgruuf", 40, 30)
            };

            foreach (var warrior in warriors)
            {
                dragon.Attach(warrior);
            }

            // Nothing happens
            dragon.HealthPoints -= 20;
            // Nothing happens
            dragon.HealthPoints -= 10;
            // Dragon dies
            dragon.HealthPoints -= 90;
        }
    }
}
