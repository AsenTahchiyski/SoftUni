namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestFloat
    {
        public static void TestSum(float timesToPerform)
        {
            float a = 0;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = a + 1;
            }
        }

        public static void TestSubtract(float timesToPerform)
        {
            float a = 0;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = a - 1;
            }
        }

        public static void TestIncrementBy1Prefix(float timesToPerform)
        {
            float a = 0;
            for (float i = 0; i < timesToPerform; i++)
            {
                ++a;
            }
        }

        public static void TestIncrementBy1Postfix(float timesToPerform)
        {
            float a = 0;
            for (float i = 0; i < timesToPerform; i++)
            {
                a++;
            }
        }

        public static void TestPlusEquals1(float timesToPerform)
        {
            float a = 0;
            for (float i = 0; i < timesToPerform; i++)
            {
                a += 1;
            }
        }

        public static void TestMultiply(float timesToPerform)
        {
            float a = 0;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = a * 2;
            }
        }

        public static void TestMDivide(float timesToPerform)
        {
            float a = Int64.MaxValue;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = a / 2;
            }
        }
    }
}
