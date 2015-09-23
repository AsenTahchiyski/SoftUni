using System;
class MorseCodeNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int nSum = n / 1000 + (n / 100) % 10 + (n / 10) % 10 + n % 10;
        int[] codes = new int[6];
        bool noOutput = true;
        for (codes[0] = 0; codes[0] < 6; codes[0]++)
        {
            for (codes[1] = 0; codes[1] < 6; codes[1]++)
            {
                for (codes[2] = 0; codes[2] < 6; codes[2]++)
                {
                    for (codes[3] = 0; codes[3] < 6; codes[3]++)
                    {
                        for (codes[4] = 0; codes[4] < 6; codes[4]++)
                        {
                            for (codes[5] = 0; codes[5] < 6; codes[5]++)
                            {
                                if (codes[0] * codes[1] * codes[2] * codes[3] * codes[4] * codes[5] == nSum)
                                {
                                    Console.WriteLine(morseCode(codes));
                                    noOutput = false;
                                }        
                            }
                        }
                    }
                }
            }
        }
        if (noOutput)
        {
            Console.WriteLine("No");
        }
    }
    static string morseCode(int[] codes)
    {
        string output = null;
        for (int i = 0; i < codes.Length; i++)
        {
            switch (codes[i])
            {
                case 0: output = String.Concat(output, "-----|"); break;
                case 1: output = String.Concat(output, ".----|"); break;
                case 2: output = String.Concat(output, "..---|"); break;
                case 3: output = String.Concat(output, "...--|"); break;
                case 4: output = String.Concat(output, "....-|"); break;
                case 5: output = String.Concat(output, ".....|"); break;
                default: break;
            }
        }
        return output;
    }
}
