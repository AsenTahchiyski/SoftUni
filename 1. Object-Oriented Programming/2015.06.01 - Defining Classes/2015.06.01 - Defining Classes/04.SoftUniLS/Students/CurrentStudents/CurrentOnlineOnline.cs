using System;

namespace SULS.Students.Current
{
    class CurrentOnlineStudent : CurrentStudent
    {
        private string currentCourse;
        private string studentNum;
        private double avgGrade;
        private string firstName;
        private string lastName;
        private int age;

        public CurrentOnlineStudent(string firstName, string lastName, int age, string studentNum, double avgGrade, string currCourse) 
            : base (firstName, lastName, age, studentNum, avgGrade, currCourse)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.StudentNumber = studentNum;
            this.AverageGrade = avgGrade;
            this.CurrentCourse = currCourse;
        }
    }
}
