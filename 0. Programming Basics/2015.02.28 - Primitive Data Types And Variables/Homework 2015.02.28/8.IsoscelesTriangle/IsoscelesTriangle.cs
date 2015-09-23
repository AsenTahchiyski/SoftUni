using System;
using System.Text;
class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char c = '\u00A9';
        Console.WriteLine("   {0}   ", c);
        Console.WriteLine("  {0} {0}  ", c);
        Console.WriteLine(" {0}   {0} ", c);
        Console.WriteLine("{0} {0} {0} {0}", c);
    }
}
