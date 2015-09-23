namespace GenericList
{
    using System;
    class Program
    {
        static void Main()
        {
            GenericList<string> names = new GenericList<string>();
            names.ShowVersion();

            names.Add("Gosho");
            names.Add("Pesho");
            names.Add("Misho");
            names.Add("Tisho");
            names.Add("Nashmat");
            names.Add("Onufri");
            names.Add("Gencho");

            names.Insert("Tyanko", 2);
            names.Remove(1);
            //names.Clear();

            names.Add("Asen");
            names.Add("Zaro");

            Console.WriteLine("All elements: " + names);
            Console.WriteLine("Max element: " + names.Max());
            Console.WriteLine("Min element: " + names.Min());

            string search = "Onufri";
            Console.WriteLine("Elements contain {0}: {1}", search, names.Contains(search));
            Console.WriteLine("Index of {0}: {1}", search, names.IndexOf(search));
        }
    }
}
