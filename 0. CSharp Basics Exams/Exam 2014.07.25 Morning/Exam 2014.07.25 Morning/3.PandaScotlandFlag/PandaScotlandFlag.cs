using System;
class PandaScotlandFlag
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char letter = 'A';
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.Write("{0}{1}{2}", new string('~', i), letter++, new string('#', n - 2 * (i + 1)));
            letter = getLetter(letter);
            Console.WriteLine("{0}{1}", letter++, new string('~', i));
            letter = getLetter(letter);
        }
        Console.WriteLine("{0}{1}{0}", new string('-', (n - 1) / 2), letter++);
        letter = getLetter(letter);
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.Write("{0}{1}{2}", new string('~', (n - (3 + 2 * i)) / 2), letter++, new string('#', 2 * i + 1));
            letter = getLetter(letter);
            Console.WriteLine("{0}{1}", letter++, new string('~', (n - (3 + 2 * i)) / 2));
            letter = getLetter(letter);
        }
    }
    static char getLetter(char letter)
    {
        if (letter > 'Z')
        {
            letter = 'A';
        }
        return letter;
    }
}
