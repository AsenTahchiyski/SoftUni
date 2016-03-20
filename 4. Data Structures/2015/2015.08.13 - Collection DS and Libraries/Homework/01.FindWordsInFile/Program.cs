namespace _01.FindWordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string inputPath = "./../../beer.txt";
            var allWords = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(inputPath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] words = line.Split(new char[]
                        {
                            ' ', ',', '.', '-', ':', '!', '?', '?', '"', '\'', ';', '_', '`'
                        });

                    foreach (string word in words)
                    {
                        if (!allWords.ContainsKey(word.ToLower()))
                        {
                            allWords.Add(word.ToLower(), 0);
                        }

                        allWords[word.ToLower()]++;
                    }

                    line = reader.ReadLine();
                }
            }

            Console.Write("Enter word to search (or \"END!\" to exit): ");
            string wordToSearch = Console.ReadLine();

            while (wordToSearch != "END!")
            {
                if (allWords.ContainsKey(wordToSearch))
                {
                    Console.WriteLine("{0} is present {1} times", wordToSearch, allWords[wordToSearch]);
                }
                else
                {
                    Console.WriteLine("{0} is present 0 times", wordToSearch);
                }

                Console.Write("Enter word to search or \"END!\" to exit: ");
                wordToSearch = Console.ReadLine();
            }
        }
    }
}
