using System;
class Tables
{
    static void Main()
    {
        long bundle1 = long.Parse(Console.ReadLine());
        long bundle2 = long.Parse(Console.ReadLine());
        long bundle3 = long.Parse(Console.ReadLine());
        long bundle4 = long.Parse(Console.ReadLine());
        long tops = long.Parse(Console.ReadLine());
        long TablesToMake = long.Parse(Console.ReadLine());
        long AllLegs = bundle1 * 1 + bundle2 * 2 + bundle3 * 3 + bundle4 * 4;
        long FullLegSets = AllLegs / 4;
        long LegsLeft = AllLegs - (FullLegSets * 4);

        if (tops > TablesToMake && FullLegSets > TablesToMake && tops >= FullLegSets)
        {
            Console.WriteLine("more: {0}", FullLegSets - TablesToMake);
            Console.WriteLine("tops left: {0}, legs left: {1}", tops - TablesToMake, ((FullLegSets - TablesToMake) * 4) + LegsLeft);
        }
        if (tops > TablesToMake && FullLegSets > TablesToMake && tops < FullLegSets)
        {
            Console.WriteLine("more: {0}", tops - TablesToMake);
            Console.WriteLine("tops left: {0}, legs left: {1}", tops - TablesToMake, ((FullLegSets - TablesToMake) * 4) + LegsLeft);
        }
        if (tops >= TablesToMake && FullLegSets < TablesToMake)
        {
            Console.WriteLine("less: {0}", TablesToMake - FullLegSets);
            Console.WriteLine("tops needed: 0, legs needed: {0}", (TablesToMake * 4) - AllLegs);
        }
        if (tops == TablesToMake && FullLegSets >= TablesToMake) //
        {
            Console.WriteLine("Just enough tables made: {0}", tops);
        }
        if (tops > TablesToMake && FullLegSets == TablesToMake)
        {
            Console.WriteLine("Just enough tables made: {0}", FullLegSets);
        }
        if (tops < TablesToMake && FullLegSets >= TablesToMake)
        {
            Console.WriteLine("less: -{0}", TablesToMake - tops);
            Console.WriteLine("tops needed: {0}, legs needed: 0", TablesToMake - tops);
        }
        if (tops < TablesToMake && FullLegSets < TablesToMake && tops >= FullLegSets)
        {
            Console.WriteLine("less: -{0}", TablesToMake - FullLegSets);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", TablesToMake - tops, (TablesToMake * 4) - AllLegs);
        }
        if (tops < TablesToMake && FullLegSets < TablesToMake && tops < FullLegSets)
        {
            Console.WriteLine("less: {0}", TablesToMake - tops);
            Console.WriteLine("tops needed: {0}, legs needed: {1}", TablesToMake - tops, (TablesToMake * 4) - AllLegs);
        }
    }
}
