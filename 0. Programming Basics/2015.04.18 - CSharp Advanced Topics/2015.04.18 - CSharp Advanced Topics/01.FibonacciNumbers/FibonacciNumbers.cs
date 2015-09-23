using System;
class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Fib(n));
    }
    static long Fib(int n)
    {
        switch (n)
	    {
            case 0: return 1;
            case 1: return 1;
		    default:
                long fibonacciN = 0;
                long fibonacciNminus1 = 1;
                long fibonacciNminus2 = 1;
                for (int i = 2; i <= n; i++)
                {
                    fibonacciN = fibonacciNminus1 + fibonacciNminus2;
                    fibonacciNminus2 = fibonacciNminus1;
                    fibonacciNminus1 = fibonacciN;
                }
                return fibonacciN;
        }  
    }
}
