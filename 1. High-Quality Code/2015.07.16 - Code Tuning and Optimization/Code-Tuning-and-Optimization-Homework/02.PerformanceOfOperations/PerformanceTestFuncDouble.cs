namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestFuncDouble
    {
        public static void TestSqrt(double timesToPerform)
        {
            double a = timesToPerform;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = Math.Sqrt(a);
            }
        }

        public static void TestNlog(double timesToPerform)
        {
            double a = timesToPerform;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = Math.Log(a);
            }
        }

        public static void TestSine(double timesToPerform)
        {
            double a = timesToPerform;
            for (double i = 0; i < timesToPerform; i++)
            {
                a = Math.Sin(a);
            }
        }
    }
}
