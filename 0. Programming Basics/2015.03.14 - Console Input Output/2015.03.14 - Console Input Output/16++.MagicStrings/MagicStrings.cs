using System;
class MagicStrings
{
    static void Main()
    {
        int diff = int.Parse(Console.ReadLine());
        if (diff > 16)
        {
            Console.WriteLine("No");
            return;
        }
        string let = "knps";
        for (int a = 0; a < 4; a++)
        {
            for (int b = 0; b < 4; b++)
            {
                for (int c = 0; c < 4; c++)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        int leftWeight = weight(let[a]) + weight(let[b]) + weight(let[c]) + weight(let[d]);
                        if (Math.Abs(leftWeight - diff) >= 4 || Math.Abs(leftWeight - diff) <= 20)
                        {
                            for (int x = 0; x < 4; x++)
                            {
                                for (int y = 0; y < 4; y++)
                                {
                                    for (int z = 0; z < 4; z++)
                                    {
                                        for (int v = 0; v < 4; v++)
                                        {
                                            int rightWeight = weight(let[x]) + weight(let[y]) + weight(let[z]) + weight(let[v]);
                                            if (Math.Abs(leftWeight - rightWeight) == diff)
                                            {
                                                Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}", let[a], let[b], let[c], let[d], let[x], let[y], let[z], let[v]);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No");
                            return;
                        }
                    }
                }
            }
        }

    }
    static int weight(char letter)
    {
        int letterWeight = 0;
        switch (letter)
        {
            case 's': letterWeight = 3; break;
            case 'n': letterWeight = 4; break;
            case 'p': letterWeight = 5; break;
            case 'k': letterWeight = 1; break;
            default:                    break;
        }
        return letterWeight;
    }
}
