using System;
class OddOrEvenCounter
{
    static void Main()
    {
        int sets = int.Parse(Console.ReadLine());
        int elements = int.Parse(Console.ReadLine());
        string type = Console.ReadLine();
        int[,] matrix = new int[sets, elements];
        int[] oddCounter = new int[sets];
        int[] evenCounter = new int[sets];
        for (int set = 0; set < sets; set++)
        {
            for (int element = 0; element < elements; element++)
            {
                matrix[set, element] = int.Parse(Console.ReadLine());
                if (matrix[set, element] % 2 == 0)
                {
                    evenCounter[set]++;
                }
                else
                {
                    oddCounter[set]++;
                }
            }
        }
        int bestSet = 0;
        int bestSetIndex = 0;
        if (type == "odd")
        {
            for (int i = 0; i < sets; i++)
            {
                if (oddCounter[i] > bestSet)
                {
                    bestSet = oddCounter[i];
                    bestSetIndex = i + 1;
                }
            }
        }
        else if (type == "even")
        {
            for (int i = 0; i < sets; i++)
            {
                if (evenCounter[i] > bestSet)
                {
                    bestSet = evenCounter[i];
                    bestSetIndex = i + 1;
                }
            }
        }
        string setPlace = null;
        switch (bestSetIndex)
	    {
            case 1: setPlace = "First"; break;
            case 2: setPlace = "Second"; break;
            case 3: setPlace = "Third"; break;
            case 4: setPlace = "Fourth"; break;
            case 5: setPlace = "Fifth"; break;
            case 6: setPlace = "Sixth"; break;
            case 7: setPlace = "Seventh"; break;
            case 8: setPlace = "Eighth"; break;
            case 9: setPlace = "Ninth"; break;
            case 10: setPlace = "Tenth"; break;
            default: break;
	    }
        if (bestSet == 0)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("{0} set has the most {1} numbers: {2}", setPlace, type, bestSet);
        }
	}
}
