namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestInt
    {
        public static void TestSum(int timesToPerform)
        {
            int a = 0;
            for (int i = 0; i < timesToPerform; i++)
            {
                a = a + 1;
            }
        }

        public static void TestSubtract(int timesToPerform)
        {
            int a = 0;
            for (int i = 0; i < timesToPerform; i++)
            {
                a = a - 1;
            }
        }

        public static void TestIncrementBy1Prefix(int timesToPerform)
        {
            int a = 0;
            for (int i = 0; i < timesToPerform; i++)
            {
                ++a;
            }
        }

        public static void TestIncrementBy1Postfix(int timesToPerform)
        {
            int a = 0;
            for (int i = 0; i < timesToPerform; i++)
            {
                a++;
            }
        }

        public static void TestPlusEquals1(int timesToPerform)
        {
            int a = 0;
            for (int i = 0; i < timesToPerform; i++)
            {
                a += 1;
            }
        }

        public static void TestMultiply(int timesToPerform)
        {
            int a = 0;
            for (int i = 0; i < timesToPerform; i++)
            {
                a = a * 2;
            }
        }

        public static void TestMDivide(int timesToPerform)
        {
            int a = Int32.MaxValue;
            for (int i = 0; i < timesToPerform; i++)
            {
                a = a / 2;
            }
        }
    }
}
