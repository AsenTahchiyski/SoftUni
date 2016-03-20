using System;
using Wintellect.PowerCollections;

namespace p2.StringEditor
{
    class Program
    {
        private static BigList<char> rope = new BigList<char>();

        static void Main(string[] args)
        {
            //string alphabet = "abcdefghijklmnopqrstuvwxyz";
            //for (int i = 0; i < 10000; i++)
            //{
            //    Insert(i, alphabet);
            //    Append(alphabet);
            //    Delete(3, 20);
            //    Replace(i + 1, 20, "howdy");
            //}

            //Print();

            string commandLine = Console.ReadLine();
            while (commandLine.ToLower() != "end")
            {
                string[] requestData = commandLine.Split();
                string commandType = requestData[0].Trim().ToLower();
                switch (commandType)
                {
                    case "append":
                        for (int i = 1; i < requestData.Length; i++)
                        {
                            Append(requestData[i].Trim() + (i == requestData.Length - 1 ? "" : " "));
                        }
                        break;
                    case "insert":
                        int startIndex = int.Parse(requestData[1]);
                        Insert(startIndex, requestData[2]);
                        break;
                    case "delete":
                        int start = int.Parse(requestData[1]);
                        int count = int.Parse(requestData[2]);
                        Delete(start, count);
                        break;
                    case "print":
                        Print();
                        break;
                    case "replace":
                        int from = int.Parse(requestData[1]);
                        int quantity = int.Parse(requestData[2]);
                        string replaceWith = requestData[3];
                        Replace(from, quantity, replaceWith);
                        break;
                    default:
                        break;
                }

                commandLine = Console.ReadLine();
            }
        }

        static void Insert(int startIndex, string text)
        {
            try
            {
                rope.InsertRange(startIndex, text);
                Console.WriteLine("OK");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        static void Append(string text)
        {
            rope.AddRange(text);
            Console.WriteLine("OK");
        }

        static void Delete(int startIndex, int count)
        {
            try
            {
                rope.RemoveRange(startIndex, count);
                Console.WriteLine("OK");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        static void Replace(int startIndex, int count, string replacement)
        {
            try
            {
                Delete(startIndex, count);
                Insert(startIndex, replacement);
                Console.WriteLine("OK");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        static void Print()
        {
            Console.WriteLine(string.Join("", rope));
        }
    }
}
