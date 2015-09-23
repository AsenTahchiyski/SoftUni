namespace Methods
{
    using System;

    public class TestMethods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("side", "Sides should be positive.");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c)); // Heron's formula
            return area;
        }

        public static string DigitToWord(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
            }

            throw new ArgumentOutOfRangeException("digit", "Invalid digit.");
        }

        public static int GetMaxElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new InvalidOperationException("Array is empty or null.");
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintAsRealNumber(object number, int digitsAfterDot)
        {
            double objectToNumber;
            if (!double.TryParse(number.ToString(), out objectToNumber))
            {
                throw new ArgumentException("Object is not a number.");
            }

            string format = "{0:f" + digitsAfterDot + "}";
            Console.WriteLine(format, objectToNumber);
        }

        public static void PrintAsPercentage(object number)
        {
            double objectToNumber;
            if (!double.TryParse(number.ToString(), out objectToNumber))
            {
                throw new ArgumentException("Object is not a number.");
            }

            Console.WriteLine("{0:p0}", objectToNumber);
        }

        public static void PrintRightAligned(object number, int symbolsIndent)
        {
            double objectToNumber;
            if (!double.TryParse(number.ToString(), out objectToNumber))
            {
                throw new ArgumentException("Object is not a number.");
            }
            
            string format = "{0," + symbolsIndent + "}";
            Console.WriteLine(format, objectToNumber);
        }

        public static double CalculateDistanceBetweenPoints(double firstPointX, double firstPointY, double secondPointX, double secondPointY)
        {
            double deltaX = secondPointX - firstPointX;
            double deltaY = secondPointY - firstPointY;
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
            return distance;
        }

        public static bool IsLineHorizontal(double firstPointY, double secondPointY)
        {
            return firstPointY.ToString() == secondPointY.ToString(); // to string so rounding errors can be avoided
        }

        public static bool IsLineVertical(double firstPointX, double secondPointX)
        {
            return firstPointX.ToString() == secondPointX.ToString(); // to string so rounding errors can be avoided
        }
    }
}
