using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student(string name, string phoneNum = null, DateTime? birthday = null)
        {
            this.Name = name;
            this.Registration = DateTime.Now;
            this.PhoneNumber = phoneNum;
            this.Birthday = birthday;
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        // to enable anonymous object based LINQ queries
        public Student() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Registration { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
