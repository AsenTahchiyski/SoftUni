namespace Homework.ToTheStars
{
    using System;
    using System.Linq;

    internal class ToTheStarsReformatted
    {
        private static readonly double[] FirstStarSystemCoordinates = new double[2];
        private static readonly double[] SecondStarSystemCoordinates = new double[2];
        private static readonly double[] ThirdStarSystemCoordinates = new double[2];

        private static double[] coordinatesNormandy = new double[2];
        private static string firstStarSystemName;
        private static string secondStarSystemName;
        private static string thirdStarSystemName;

        public static void Main()
        {
            // input
            string[] parametersFirstStarSystem = Console.ReadLine().Split(' ');
            string[] parametersSecondStarSystem = Console.ReadLine().Split(' ');
            string[] parametersThirdStarSystem = Console.ReadLine().Split(' ');

            coordinatesNormandy = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            FirstStarSystemCoordinates[0] = double.Parse(parametersFirstStarSystem[1]);
            FirstStarSystemCoordinates[1] = double.Parse(parametersFirstStarSystem[2]);
            SecondStarSystemCoordinates[0] = double.Parse(parametersSecondStarSystem[1]);
            SecondStarSystemCoordinates[1] = double.Parse(parametersSecondStarSystem[2]);
            ThirdStarSystemCoordinates[0] = double.Parse(parametersThirdStarSystem[1]);
            ThirdStarSystemCoordinates[1] = double.Parse(parametersThirdStarSystem[2]);

            int numberOfTurns = int.Parse(Console.ReadLine());
            firstStarSystemName = parametersFirstStarSystem[0];
            secondStarSystemName = parametersSecondStarSystem[0];
            thirdStarSystemName = parametersThirdStarSystem[0];

            // make turns and check positions
            for (int i = 0; i <= numberOfTurns; i++)
            {
                Console.WriteLine(GetPositionName());
                coordinatesNormandy[1]++;
            }
        }

        private static bool IsInRangeOf(double[] coordinatesStarSystem, double[] coordinatesNormandy)
        {
            return coordinatesNormandy[0] >= coordinatesStarSystem[0] - 1 &&
                   coordinatesNormandy[0] <= coordinatesStarSystem[0] + 1 &&
                   coordinatesNormandy[1] >= coordinatesStarSystem[1] - 1 &&
                   coordinatesNormandy[1] <= coordinatesStarSystem[1] + 1;
        }

        private static string GetPositionName()
        {
            if (IsInRangeOf(FirstStarSystemCoordinates, coordinatesNormandy))
            {
                return firstStarSystemName.ToLower();
            }
            else if (IsInRangeOf(SecondStarSystemCoordinates, coordinatesNormandy))
            {
                return secondStarSystemName.ToLower();
            }
            else if (IsInRangeOf(ThirdStarSystemCoordinates, coordinatesNormandy))
            {
                return thirdStarSystemName.ToLower();
            }
            else
            {
                return "space";
            }
        }
    }
}
