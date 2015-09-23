using System;
class StringsAndObjects
{
    static void Main()
    {
        string sup = "Hello";
        string brah = "World";
        object SupBrah = sup + " " + brah;
        string SupBrahStringed = (string)SupBrah;

        Console.WriteLine(SupBrahStringed);
    }
}
