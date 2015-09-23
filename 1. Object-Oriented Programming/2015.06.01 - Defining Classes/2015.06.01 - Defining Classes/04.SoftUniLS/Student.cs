using System;

namespace SULS.Students
{
    class Student : Person
    {
        private string studentNum;
        private double avgGrade;
        private string firstName;
        private string lastName;
        private int age;

        public Student(string firstName, string lastName, int age, string stNum, double avgGrade) : base(firstName, lastName, age)
        {
            this.StudentNumber = stNum;
            this.AverageGrade = avgGrade;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string StudentNumber
        {
            get { return this.studentNum; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Student number cannot be empty.");
                }
                this.studentNum = value;
            }
        }

        public double AverageGrade
        {
            get { return this.avgGrade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Averaga grade should be between 2 and 6.");
                }
                this.avgGrade = value;
            }
        }
    }
}
