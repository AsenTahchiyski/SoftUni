namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestFuncFloat
    {
        public static void TestSqrt(float timesToPerform)
        {
            float a = timesToPerform;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = (float)Math.Sqrt(a);
            }
        }

        public static void TestNlog(float timesToPerform)
        {
            float a = timesToPerform;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = (float)Math.Log(a);
            }
        }

        public static void TestSine(float timesToPerform)
        {
            float a = timesToPerform;
            for (float i = 0; i < timesToPerform; i++)
            {
                a = (float)Math.Sin(a);
            }
        }
    }
}
