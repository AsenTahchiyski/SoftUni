using System;
class OddAndEvenProduct
{
    static void Main()
    {
        Start:
        Console.WriteLine("Enter numbers separated by space:");
        string[] numbers = Console.ReadLine().Split(' ');
        int oddProduct = 1;
        int evenProduct = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i % 2 == 0)
            {
                oddProduct *= int.Parse(numbers[i]);
            }
            else
            {
                evenProduct *= int.Parse(numbers[i]);
            }
        }
        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes\nproduct = {0}", evenProduct);
        }
        else
        {
            Console.WriteLine("no\nodd_product = {0}\neven_product = {1}", oddProduct, evenProduct);
        }
        goto Start;
    }
}
