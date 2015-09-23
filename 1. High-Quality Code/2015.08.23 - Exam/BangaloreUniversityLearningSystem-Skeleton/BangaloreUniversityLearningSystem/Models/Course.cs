namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Course : ICourse
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Lectures = new List<ILecture>();
            this.Students = new List<IUser>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    string message = "The course name must be at least 5 symbols long.";
                    throw new ArgumentException(message);
                }

                this.name = value;
            }
        }

        public IList<ILecture> Lectures { get; set; }

        public IList<IUser> Students { get; set; }

        public void AddLecture(ILecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(IUser student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}
