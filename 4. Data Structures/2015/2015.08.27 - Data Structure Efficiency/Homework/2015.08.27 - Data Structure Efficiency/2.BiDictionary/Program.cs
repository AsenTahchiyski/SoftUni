namespace _2.BiDictionary
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<string> keys1 = new List<string>()
            {
                "Pesho",
                "Gosho",
                "Ivan",
                "Dragan",
                "Nashmat",
                "Ivan",
                "Petko",
                "Sasho",
                "Hristo",
                "Marin"
            };

            List<string> keys2 = new List<string>()
            {
                "Petrov",
                "Ivanov",
                "Georgiev",
                "Iliev",
                "Yavorov",
                "Nakov",
                "Filipov",
                "Bayrakchiev",
                "Atanasov",
                "Miloshev"
            };

            Random random = new Random();
            List<int> values = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                values.Add(random.Next());
            }
            
            BiDictionary<string, int> biDictionary = new BiDictionary<string, int>();
            for (int i = 0; i < 10; i++)
            {
                biDictionary.Add(keys1[i], keys2[i], values.GetRange(i * 10, 10));
            }

            foreach (var key in keys1)
            {
                Console.WriteLine(key + ": " + string.Join(", ", biDictionary.GetValuesAnyKey(key)));
                Console.WriteLine(new string('-', 40));
            }

            foreach (var key in keys2)
            {
                Console.WriteLine(key + ": " + string.Join(", ", biDictionary.GetValuesAnyKey(key)));
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
