using System;
using System.IO;
class OddLines
{
    static void Main()
    {
        // create file with 10 numbered lines
        using (StreamWriter makeFile = new StreamWriter("example.txt"))
        {
            for (int i = 1; i <= 10; i++)
            {
                string line = "This is line " + i;
                makeFile.WriteLine(line);
            }
        }
        // get odd lines and print them on the console
        using (StreamReader readLines = new StreamReader("example.txt"))
        {
            int lineNumber = 0;
            string line = readLines.ReadLine();
            while (line != null)
            {
                lineNumber++;
                if(lineNumber % 2 == 1) Console.WriteLine(line);
                line = readLines.ReadLine();
            }
        }
    }
}
