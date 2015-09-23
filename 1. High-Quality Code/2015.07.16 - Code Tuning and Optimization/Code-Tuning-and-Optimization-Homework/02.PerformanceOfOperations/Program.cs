namespace PerformanceOfOperations
{
    using System;
    using System.Diagnostics;

    class Program
    {
        private const int timesToPerform = 5;
        private static Stopwatch timer = new Stopwatch();

        static void Main()
        {
            //GetExecutionTimeInt(PerformanceTestInt.TestSum);
            //GetExecutionTimeInt(PerformanceTestInt.TestSubtract);
            //GetExecutionTimeInt(PerformanceTestInt.TestIncrementBy1Prefix);
            //GetExecutionTimeInt(PerformanceTestInt.TestIncrementBy1Postfix);
            //GetExecutionTimeInt(PerformanceTestInt.TestPlusEquals1);
            //GetExecutionTimeInt(PerformanceTestInt.TestMultiply);
            //GetExecutionTimeInt(PerformanceTestInt.TestMDivide);

            //GetExecutionTimeLong(PerformanceTestLong.TestSum);
            //GetExecutionTimeLong(PerformanceTestLong.TestSubtract);
            //GetExecutionTimeLong(PerformanceTestLong.TestIncrementBy1Prefix);
            //GetExecutionTimeLong(PerformanceTestLong.TestIncrementBy1Postfix);
            //GetExecutionTimeLong(PerformanceTestLong.TestPlusEquals1);
            //GetExecutionTimeLong(PerformanceTestLong.TestMultiply);
            //GetExecutionTimeLong(PerformanceTestLong.TestMDivide);

            //GetExecutionTimeFloat(PerformanceTestFloat.TestSum);
            //GetExecutionTimeFloat(PerformanceTestFloat.TestSubtract);
            //GetExecutionTimeFloat(PerformanceTestFloat.TestIncrementBy1Prefix);
            //GetExecutionTimeFloat(PerformanceTestFloat.TestIncrementBy1Postfix);
            //GetExecutionTimeFloat(PerformanceTestFloat.TestPlusEquals1);
            //GetExecutionTimeFloat(PerformanceTestFloat.TestMultiply);
            //GetExecutionTimeFloat(PerformanceTestFloat.TestMDivide);

            //GetExecutionTimeDouble(PerformanceTestDouble.TestSum);
            //GetExecutionTimeDouble(PerformanceTestDouble.TestSubtract);
            //GetExecutionTimeDouble(PerformanceTestDouble.TestIncrementBy1Prefix);
            //GetExecutionTimeDouble(PerformanceTestDouble.TestIncrementBy1Postfix);
            //GetExecutionTimeDouble(PerformanceTestDouble.TestPlusEquals1);
            //GetExecutionTimeDouble(PerformanceTestDouble.TestMultiply);
            //GetExecutionTimeDouble(PerformanceTestDouble.TestMDivide);

            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestSum);
            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestSubtract);
            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestIncrementBy1Prefix);
            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestIncrementBy1Postfix);
            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestPlusEquals1);
            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestMultiply);
            //GetExecutionTimeDecimal(PerformanceTestDecimal.TestMDivide);

            //GetExecutionTimeFloat(PerformanceTestFuncFloat.TestSqrt);
            //GetExecutionTimeFloat(PerformanceTestFuncFloat.TestNlog);
            //GetExecutionTimeFloat(PerformanceTestFuncFloat.TestSine);

            //GetExecutionTimeDouble(PerformanceTestFuncDouble.TestSqrt);
            //GetExecutionTimeDouble(PerformanceTestFuncDouble.TestNlog);
            //GetExecutionTimeDouble(PerformanceTestFuncDouble.TestSine);

            GetExecutionTimeDecimal(PerformanceTestFuncDecimal.TestSqrt);
            GetExecutionTimeDecimal(PerformanceTestFuncDecimal.TestNlog);
            GetExecutionTimeDecimal(PerformanceTestFuncDecimal.TestSine);

        }

        static void GetExecutionTimeInt(Action<int> action)
        {
            timer.Start();
            action.Invoke(timesToPerform);
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            timer.Reset();
        }

        static void GetExecutionTimeLong(Action<long> action)
        {
            timer.Start();
            action.Invoke(timesToPerform);
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            timer.Reset();
        }

        static void GetExecutionTimeFloat(Action<float> action)
        {
            timer.Start();
            action.Invoke(timesToPerform);
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            timer.Reset();
        }

        static void GetExecutionTimeDouble(Action<double> action)
        {
            timer.Start();
            action.Invoke(timesToPerform);
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            timer.Reset();
        }

        static void GetExecutionTimeDecimal(Action<decimal> action)
        {
            timer.Start();
            action.Invoke(timesToPerform);
            timer.Stop();
            Console.WriteLine(timer.ElapsedTicks);
            timer.Reset();
        }
    }
}
