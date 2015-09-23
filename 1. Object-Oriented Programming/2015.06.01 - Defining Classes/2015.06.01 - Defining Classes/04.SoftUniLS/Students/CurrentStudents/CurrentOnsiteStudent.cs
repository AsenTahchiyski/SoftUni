using System;

namespace SULS.Students.Current
{
    class CurrentOnsiteStudent : CurrentStudent
    {
        private int visits;
        private string currentCourse;
        private string studentNum;
        private double avgGrade;
        private string firstName;
        private string lastName;
        private int age;

        public CurrentOnsiteStudent(string firstName, string lastName, int age, string studentNum, double avgGrade, string currCourse) 
            : base (firstName, lastName, age, studentNum, avgGrade, currCourse)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.StudentNumber = studentNum;
            this.AverageGrade = avgGrade;
            this.CurrentCourse = currCourse;
            this.Visits = visits;
        }

        public int Visits
        {
            get { return this.visits; }
            set
            {
                if (value < 0 || value > int.MaxValue)
	            {
                    throw new ArgumentOutOfRangeException("Visits must be positive and less than 2,000,000,000");
	            }
                this.visits = value;
            }
        }
    }
}
