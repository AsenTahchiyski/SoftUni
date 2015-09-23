using System;

namespace SULS.Students
{
    class GraduateStudent : Student
    {
        private string studentNum;
        private double avgGrade;
        private string firstName;
        private string lastName;
        private int age;

        public GraduateStudent(string firstName, string lastName, int age, string stNum, double avgGrade)
            : base(firstName, lastName, age, stNum, avgGrade)
        {
            this.StudentNumber = stNum;
            this.AverageGrade = avgGrade;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
