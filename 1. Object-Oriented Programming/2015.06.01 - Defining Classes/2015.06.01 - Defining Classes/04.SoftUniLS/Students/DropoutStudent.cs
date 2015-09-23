using System;
using System.Text;

namespace SULS.Students
{
    class DropoutStudent : Student
    {
        private string dropoutReason;
        private string studentNum;
        private double avgGrade;
        private string firstName;
        private string lastName;
        private int age;

        public DropoutStudent(string firstName, string lastName, int age, string studentNum, double avgGrade, string dropoutReason) 
            : base (firstName, lastName, age, studentNum, avgGrade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.StudentNumber = studentNum;
            this.AverageGrade = avgGrade;
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get { return this.dropoutReason; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Dropout reason cannot be empty");
                }
                this.dropoutReason = value;
            }
        }

        public void Reapply()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(new string('=', 30));
            output.AppendLine("Dropout Student Reapply Information:");
            output.AppendLine(new string('=', 30));
            output.AppendLine(string.Format("Student: {0} {1} ({2} years old)", this.firstName, this.lastName, this.age));
            output.AppendLine(string.Format("Student number: {0}", this.studentNum));
            output.AppendLine(string.Format("Average grade: {0}", this.avgGrade));
            output.AppendLine(string.Format("Dropout reason: {0}", this.dropoutReason));

            Console.WriteLine(output.ToString());
        }
    }
}
