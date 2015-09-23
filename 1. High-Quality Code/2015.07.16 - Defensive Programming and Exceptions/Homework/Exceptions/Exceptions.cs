using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public static class Exceptions
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        Debug.Assert(arr != null, "Array should not be null.");
        Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index must be positive and lower than the array length.");
        Debug.Assert(count >= 0 && count <= arr.Length - startIndex, "Count of elements to take must be positive and lower than the array length minus the start index.");

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        Debug.Assert(!string.IsNullOrEmpty(str), "String to extract from may not be null or empty.");

        // Debug.Assert(str.Length >= count);
        if (str.Length < count)
        {
            throw new ArgumentOutOfRangeException("count", "Invalid count value, should be bigger than the string length.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool IsPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void PrintIsPrimeResult(int primeCandidate)
    {
        if (IsPrime(primeCandidate))
        {
            Console.WriteLine("{0} is prime.", primeCandidate);
        }
        else
        {
            Console.WriteLine("{0} is not prime", primeCandidate);
        }
    }
    
    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        try
        {
            Console.WriteLine(ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException)
        {
        }

        int primeCancicate1 = 23;
        PrintIsPrimeResult(primeCancicate1);

        int primeCancicate2 = 33;
        PrintIsPrimeResult(primeCancicate2);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };

        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
