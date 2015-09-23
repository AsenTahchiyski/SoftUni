using System;
using System.IO;
class LineNumbers
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
        // add numbers
        using (StreamReader readLines = new StreamReader("example.txt"))
        {
            using (StreamWriter addNumbers = new StreamWriter("example_numbered.txt"))
            {
                string newLine = readLines.ReadLine();
                int lineNumber = 1;
                while (newLine != null)
                {
                    newLine = lineNumber + ". " + newLine;
                    lineNumber++;
                    addNumbers.WriteLine(newLine);
                    newLine = readLines.ReadLine();
                }    
            }
        }
        Console.WriteLine("All done, please check in the /bin/debug folder.");
    }
}
