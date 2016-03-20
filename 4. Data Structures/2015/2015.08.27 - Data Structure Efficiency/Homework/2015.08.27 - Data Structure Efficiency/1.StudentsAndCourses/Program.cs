namespace _1.StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        static void Main()
        {
            string sourcePath = "../../../students.txt";

            // I'm using OrderedMultiDictionary and LINQ since SortedDictionary will not work for key values that may reoccur, 
            // which is the case for both student names and course name.

            OrderedMultiDictionary<string, Student> studentsByCourse = new OrderedMultiDictionary<string, Student>(true);

            using (StreamReader reader = new StreamReader(sourcePath))
            {
                string line = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    string[] details = line.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = details[0].Trim();
                    string lastName = details[1].Trim();
                    string course = details[2].Trim();

                    Student currentStudent = new Student(firstName, lastName);
                    studentsByCourse.Add(course, currentStudent);

                    line = reader.ReadLine();
                }
            }

            foreach (KeyValuePair<string, ICollection<Student>> keyValuePair in studentsByCourse)
            {
                StringBuilder result = new StringBuilder();
                result.Append(keyValuePair.Key + ": ");
                var studentsOrdered = keyValuePair.Value
                    .OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName);
                result.Append(string.Join(", ", studentsOrdered));
                Console.WriteLine(result.ToString());
            }
        }
    }
}
