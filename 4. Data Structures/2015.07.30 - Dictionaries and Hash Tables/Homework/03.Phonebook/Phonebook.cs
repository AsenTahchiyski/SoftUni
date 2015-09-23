namespace _03.Phonebook
{
    using System;
    using Dictionary;

    class Phonebook
    {
        static void Main()
        {
            string input = Console.ReadLine();
            CustomDictionary<string, string> phonebook = new CustomDictionary<string, string>();
            
            while (input != "search")
            {
                string[] nameAndPhone = input.Split('-');
                string name = nameAndPhone[0];
                string phone = nameAndPhone[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, phone);
                }
                else
                {
                    Console.WriteLine("Contact {0} already exists.", name);
                }

                input = Console.ReadLine();
            }

            while (true)
            {
                string searchName = Console.ReadLine();

                if (phonebook.ContainsKey(searchName))
                {
                    Console.WriteLine("{0} -> {1}", searchName, phonebook[searchName]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", searchName);
                }
            }
        }
    }
}
