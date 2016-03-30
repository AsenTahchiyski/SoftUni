using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace p1.StudentsAndCourses
{
    class Program
    {
        static void Main()
        {
            OrderedMultiDictionary<string, Person> data = new OrderedMultiDictionary<string, Person>(true);
            string filePath = "../../students.txt";
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] lineData = line.Split('|');
                    string firstName = lineData[0].Trim();
                    string lastName = lineData[1].Trim();
                    string course = lineData[2].Trim();
                    data[course].Add(new Person() { FirstName = firstName, LastName = lastName });
                    line = reader.ReadLine();
                }
            }

            foreach (var course in data)
            {
                Console.WriteLine(course.Key + ": " + string.Join(", ", course.Value));
            }
        }
    }
}
