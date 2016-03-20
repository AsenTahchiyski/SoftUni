using System;
using Wintellect.PowerCollections;

namespace p1
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new OrderedMultiDictionary<DateTime, string>(true);
            int coursesTotal = int.Parse(Console.ReadLine());
            for (int i = 0; i < coursesTotal; i++)
            {
                string[] courseData = Console.ReadLine().Split('|');
                string courseName = courseData[0].Trim();
                DateTime courseTime = DateTime.Parse(courseData[1].Trim());
                courses[courseTime].Add(courseName);
            }

            int intervalsTotal = int.Parse(Console.ReadLine());
            for (int i = 0; i < intervalsTotal; i++)
            {
                string[] intervData = Console.ReadLine().Split('|');
                DateTime start = DateTime.Parse(intervData[0].Trim());
                DateTime end = DateTime.Parse(intervData[1].Trim());
                var result = courses.Range(start, true, end, true);
                Console.WriteLine(new string('-', 10));
                Console.WriteLine(result.Values.Count);
                foreach (var coursesBe in result)
                {
                    foreach (var course in coursesBe.Value)
                    {
                        Console.WriteLine("{1} | {0}", coursesBe.Key, course);
                    }
                }

                Console.WriteLine(new string('-', 10));
            }
        }
    }
}
