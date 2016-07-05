using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalcClient
{
    class Program
    {
        static void Main()
        {
            using (var client = new DistanceService.DistanceCalculatorClient())
            {
                var result = client.CalculateDistance(1, 1, 10, 10);
                Console.WriteLine(result);
            }
        }
    }
}
