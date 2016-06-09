namespace DataLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataLayer.StudentSystemContext";
        }

        protected override void Seed(StudentSystemContext context)
        {
            // Seed DB only if empty
            if (context.Students.Count() > 0)
            {
                return;
            }

            var students = new List<Student>()
            {
                new Student("Pesho Ivanov", "08888888888", new DateTime(1980, 5, 5)),
                new Student("Gosho Petrov", "08388848888", new DateTime(1990, 4, 4)),
                new Student("Minka Gankina", "0854338888", new DateTime(1985, 12, 12)),
                new Student("Penka Karadjova", "088865432888", new DateTime(1995, 10, 5)),
                new Student("Pesho Ivanov", "08888888888", new DateTime(1988, 11, 1))
            };

            var courses = new List<Course>()
            {
                new Course("JavaScript Basics", new DateTime(2016, 1, 4), new DateTime(2016, 1, 28), 100.99m, "JavaScript for beginners."),
                new Course("Java Basics", new DateTime(2015, 10, 4), new DateTime(2015, 10, 28), 100.99m, "Java for beginners."),
                new Course("C# Basics", new DateTime(2014, 11, 4), new DateTime(2015, 3, 28), 0m, "C# for total beginners."),
                new Course("Advanced JavaScript", new DateTime(2016, 1, 29), new DateTime(2016, 2, 22), 100.99m, "JavaScript OOP."),
                new Course("AngularJS", new DateTime(2016, 3, 28), new DateTime(2016, 4, 28), 100.99m, "Building SPA with AngularJS.")
            };

            var homeworks = new List<Homework>();
            for (int i = 0; i < students.Count; i++)
            {
                homeworks.Add(new Homework(students[i], courses[i], "Homework " + i, ContentType.zip, DateTime.Now));
            }

            for (int i = 0; i < students.Count; i++)
            {
                homeworks.Add(new Homework(students[i], courses[courses.Count - i - 1], "Homework " + (i + 1), ContentType.zip, DateTime.Now));
            }

            var resources = new List<Resource>()
            {
                new Resource(courses[0], 1, "Lecture presentation.", ResourceType.Presentation, "#"),
                new Resource(courses[0], 1, "Homework description.", ResourceType.Document, "#"),
                new Resource(courses[0], 1, "Classroom excercise", ResourceType.Document, "#"),
                new Resource(courses[0], 1, "Excercise project skeleton.", ResourceType.Other, "#"),
                new Resource(courses[0], 1, "Lecture video (screen capture).", ResourceType.Video, "#")
            };

            var licenses = new List<ResourceLicense>()
            {
                new ResourceLicense("Creative Commons"),
                new ResourceLicense("SoftUni Foundation"),
                new ResourceLicense("OpenSource"),
                new ResourceLicense("All Rights Reserved (c)"),
                new ResourceLicense("Some Rights Reserved")
            };

            for (int i = 0; i < students.Count; i++)
            {
                students[i].Courses.Add(courses[i]);
            }

            for (int i = 0; i < resources.Count; i++)
            {
                resources[i].Licenses.Add(licenses[i]);
            }

            //foreach (var student in students)
            //{
            //    context.Students.AddOrUpdate(student);
            //}

            //foreach (var course in courses)
            //{
            //    context.Courses.AddOrUpdate(course);
            //}

            //foreach (var homework in homeworks)
            //{
            //    context.Homeworks.AddOrUpdate(homework);
            //}

            //foreach (var resource in resources)
            //{
            //    context.Resources.AddOrUpdate(resource);
            //}

            context.Students.AddRange(students);
            context.Courses.AddRange(courses);
            context.Homeworks.AddRange(homeworks);
            context.Resources.AddRange(resources);
            context.Licenses.AddRange(licenses);
        }
    }
}
