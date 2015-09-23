using System;
class QuotesInStrings
{
    static void Main()
    {
        string OneWay = @"The ""use"" of quotations causes difficulties.";
        string AnotherWay = "The \"use\" of quotations causes difficulties.";

        Console.WriteLine("{0}\n{1}", OneWay, AnotherWay);
    }
}
