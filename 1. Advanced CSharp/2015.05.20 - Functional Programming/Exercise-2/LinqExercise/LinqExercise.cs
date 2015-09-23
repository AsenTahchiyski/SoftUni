using System.IO;
namespace LinqExercise
{
    using System.Collections.Generic;

    public class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../Students-data.txt";

            List<Student> students = new List<Student>();
            using (StreamReader reader = new StreamReader(FilePath))
            {
                string data = reader.ReadLine();
                data = reader.ReadLine();
                while (data != null)
                {
                    data = reader.ReadLine();

                    string[] tokens = data.Split();
                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    string email = tokens[3];
                    string gender = tokens[4];
                    string studentType = tokens[5];
                    int examResult = int.Parse(tokens[6]);
                    int homeworksSent = int.Parse(tokens[7]);
                    int homeworksEvaluated = int.Parse(tokens[8]);
                    double teamworkScore = double.Parse(tokens[9]);
                    int attendancesCount = int.Parse(tokens[10]);
                    double bonus = double.Parse(tokens[11]);

                    students.Add(new Student(
                        id,
                        firstName,
                        lastName,
                        email,
                        gender,
                        studentType,
                        examResult,
                        homeworksSent,
                        homeworksEvaluated,
                        teamworkScore,
                        attendancesCount,
                        bonus));
                    data = reader.ReadLine();
                }
            }
            // TODO write LINQ queries here
            var maleStudentsQuery = students
                .FindAll(student => student.Gender == "Male");
            foreach (var student in maleStudentsQuery)
            {
                System.Console.WriteLine("{0} {1} - {2}", student.FirstName, student.LastName, student.Gender);
            }
        }
    }
}
