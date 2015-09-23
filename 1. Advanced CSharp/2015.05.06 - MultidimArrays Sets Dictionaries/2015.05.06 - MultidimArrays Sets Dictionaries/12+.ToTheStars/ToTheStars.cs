using System;
using System.Linq;
class ToTheStars
{
    static double[] coordNormandy = new double[2];
    static double[] coordFirst = new double[2];
    static double[] coordSecond = new double[2];
    static double[] coordThird = new double[2];
    static string nameFirst;
    static string nameSecond;
    static string nameThird;
    static void Main()
    {
        // input
        string[] paramFirst = Console.ReadLine().Split(' ');
        string[] paramSecond = Console.ReadLine().Split(' ');
        string[] paramThird = Console.ReadLine().Split(' ');
        coordNormandy = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
        coordFirst[0] = double.Parse(paramFirst[1]);
        coordFirst[1] = double.Parse(paramFirst[2]);
        coordSecond[0] = double.Parse(paramSecond[1]);
        coordSecond[1] = double.Parse(paramSecond[2]);
        coordThird[0] = double.Parse(paramThird[1]);
        coordThird[1] = double.Parse(paramThird[2]);
        int turns = int.Parse(Console.ReadLine());
        nameFirst = paramFirst[0];
        nameSecond = paramSecond[0];
        nameThird = paramThird[0];
        // make turns and check positions
        for (int i = 0; i <= turns; i++)
        {
            Console.WriteLine(GetPositionName());
            coordNormandy[1]++;
        }
    }
    static bool IsInRangeOf(double[] coordStar, double[] coordNormandy)
    {
        if (coordNormandy[0] >= coordStar[0] - 1 && coordNormandy[0] <= coordStar[0] + 1 &&
            coordNormandy[1] >= coordStar[1] - 1 && coordNormandy[1] <= coordStar[1] + 1)
        {
            return true;
        }
        else return false;
    }
    static string GetPositionName()
    {
        if (IsInRangeOf(coordFirst, coordNormandy)) return nameFirst.ToLower();
        else if (IsInRangeOf(coordSecond, coordNormandy)) return nameSecond.ToLower();
        else if (IsInRangeOf(coordThird, coordNormandy)) return nameThird.ToLower();
        else return "space";
    }
}
