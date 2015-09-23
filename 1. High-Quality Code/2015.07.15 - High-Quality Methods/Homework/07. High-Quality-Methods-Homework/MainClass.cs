namespace Methods
{
    using System;

    public class MainClass
    {
        public static void Main()
        {
            // test TestMethods class
            Console.WriteLine(TestMethods.CalculateTriangleArea(3, 4, 5));
            Console.WriteLine(TestMethods.DigitToWord(5));
            Console.WriteLine(TestMethods.GetMaxElement(5, -1, 3, 2, 14, 2, 3));

            TestMethods.PrintAsRealNumber(1.3, 2);
            TestMethods.PrintAsPercentage(0.75);
            TestMethods.PrintRightAligned(2.30, 8);

            Console.WriteLine(TestMethods.CalculateDistanceBetweenPoints(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + TestMethods.IsLineHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + TestMethods.IsLineVertical(3, 3));

            // test Student class
            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");
            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} is older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
