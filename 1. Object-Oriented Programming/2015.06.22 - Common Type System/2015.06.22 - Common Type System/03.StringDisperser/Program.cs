namespace StringDisperser
{
    using System;

    class Program
    {
        static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();

            StringDisperser two = stringDisperser.Clone() as StringDisperser;
            Console.WriteLine(two);
            two = new StringDisperser("gencho", "sasho", "paco", "florentin");
            Console.WriteLine(two);
            Console.WriteLine(stringDisperser);
        }
    }
}
