namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestDecimal
    {
        public static void TestSum(decimal timesToPerform)
        {
            decimal a = 0;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = a + 1;
            }
        }

        public static void TestSubtract(decimal timesToPerform)
        {
            decimal a = 0;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = a - 1;
            }
        }

        public static void TestIncrementBy1Prefix(decimal timesToPerform)
        {
            decimal a = 0;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                ++a;
            }
        }

        public static void TestIncrementBy1Postfix(decimal timesToPerform)
        {
            decimal a = 0;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a++;
            }
        }

        public static void TestPlusEquals1(decimal timesToPerform)
        {
            decimal a = 0;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a += 1;
            }
        }

        public static void TestMultiply(decimal timesToPerform)
        {
            decimal a = 0;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = a * 2;
            }
        }

        public static void TestMDivide(decimal timesToPerform)
        {
            decimal a = Int64.MaxValue;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = a / 2;
            }
        }
    }
}
