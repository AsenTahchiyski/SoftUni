namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestDouble
    {
        public static void TestSum(double timesToPerform)
        {
            double a = 0;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = a + 1;
            }
        }

        public static void TestSubtract(double timesToPerform)
        {
            double a = 0;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = a - 1;
            }
        }

        public static void TestIncrementBy1Prefix(double timesToPerform)
        {
            double a = 0;
            for (double i = 0; i < timesToPerform; i++)
            {
                ++a;
            }
        }

        public static void TestIncrementBy1Postfix(double timesToPerform)
        {
            double a = 0;
            for (double i = 0; i < timesToPerform; i++)
            {
                a++;
            }
        }

        public static void TestPlusEquals1(double timesToPerform)
        {
            double a = 0;
            for (double i = 0; i < timesToPerform; i++)
            {
                a += 1;
            }
        }

        public static void TestMultiply(double timesToPerform)
        {
            double a = 0;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = a * 2;
            }
        }

        public static void TestMDivide(double timesToPerform)
        {
            double a = Int64.MaxValue;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = a / 2;
            }
        }
    }
}
