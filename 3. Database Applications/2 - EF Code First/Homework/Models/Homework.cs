using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Homework
    {
        private Student student;
        private Course course;

        public Homework(Student student, Course course, string content, ContentType type, DateTime submitDate)
        {
            this.Content = content;
            this.ContentType = type;
            this.SubmitDate = submitDate;
            this.student = student;
            this.course = course;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }

        public virtual Student Student
        {
            get { return this.student; }
            set { this.student = value; }
        }

        public virtual Course Course
        {
            get { return this.course; }
            set { this.course = value; }
        }
    }
}
