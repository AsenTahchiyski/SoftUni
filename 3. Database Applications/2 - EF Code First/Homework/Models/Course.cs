using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Course
    {
        private ICollection<Homework> homeworkSubmissions;
        private ICollection<Resource> resources;
        private ICollection<Student> students;

        public Course(string name, DateTime startDate, DateTime endDate, decimal price, string description = null)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Price = price;
            this.Description = description;
            this.homeworkSubmissions = new HashSet<Homework>();
            this.resources = new HashSet<Resource>();
            this.students = new HashSet<Student>();
        }

        // to enable anonymous object based LINQ queries
        public Course() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual ICollection<Homework> HomeworkSubmissions
        {
            get { return this.homeworkSubmissions; }
        }

        public void AddHomework(Homework homework)
        {
            this.homeworkSubmissions.Add(homework);
        }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }
    }
}
