namespace PerformanceOfOperations
{
    using System;

    public static class PerformanceTestFuncDecimal
    {
        public static void TestSqrt(decimal timesToPerform)
        {
            decimal a = timesToPerform;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = (decimal)Math.Sqrt((double)a);
            }
        }

        public static void TestNlog(decimal timesToPerform)
        {
            decimal a = timesToPerform;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = (decimal)Math.Log((double)a);
            }
        }

        public static void TestSine(decimal timesToPerform)
        {
            decimal a = timesToPerform;
            for (decimal i = 0; i < timesToPerform; i++)
            {
                a = (decimal)Math.Sin((double)a);
            }
        }
    }
}
