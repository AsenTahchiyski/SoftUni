namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestLong
    {
        public static void TestSum(long timesToPerform)
        {
            long a = 0;
            for (long i = 0; i < timesToPerform; i++)
            {
                a = a + 1;
            }
        }

        public static void TestSubtract(long timesToPerform)
        {
            long a = 0;
            for (long i = 0; i < timesToPerform; i++)
            {
                a = a - 1;
            }
        }

        public static void TestIncrementBy1Prefix(long timesToPerform)
        {
            long a = 0;
            for (long i = 0; i < timesToPerform; i++)
            {
                ++a;
            }
        }

        public static void TestIncrementBy1Postfix(long timesToPerform)
        {
            long a = 0;
            for (long i = 0; i < timesToPerform; i++)
            {
                a++;
            }
        }

        public static void TestPlusEquals1(long timesToPerform)
        {
            long a = 0;
            for (long i = 0; i < timesToPerform; i++)
            {
                a += 1;
            }
        }

        public static void TestMultiply(long timesToPerform)
        {
            long a = 0;
            for (long i = 0; i < timesToPerform; i++)
            {
                a = a * 2;
            }
        }

        public static void TestMDivide(long timesToPerform)
        {
            long a = Int64.MaxValue;
            for (long i = 0; i < timesToPerform; i++)
            {
                a = a / 2;
            }
        }
    }
}
