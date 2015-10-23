namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MinCourseNameLength = 5;

        private string name;

        public Course(string name)
        {
            this.Lectures = new List<Lecture>();
            this.Students = new List<User>();
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinCourseNameLength)
                {
                    string message = string.Format(string.Format(GlobalMessages.ModelNameLengthAtLeast, "course name", MinCourseNameLength));
                    throw new ArgumentException(message);
                }

                this.name = value;
            }
        }

        public IList<Lecture> Lectures { get; set; }

        public IList<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}
