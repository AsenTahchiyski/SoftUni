using System;

namespace _01.HumanStudentWorker
{
    class Student : Human
    {
        private string facNum;
        
        public string FacultyNumber 
        {
            get
            {
                return this.facNum;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faculty numbers length is between 5 and 10 characters.");
                }
                this.facNum = value;
            }
        }

        public Student(string fName, string lName, string facNum)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.FacultyNumber = facNum;
        }
    }
}
