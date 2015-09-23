﻿namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Enumerations;
    using Interfaces;
    using Models;

    public class CoursesController : Controller
    {
        public CoursesController(IData data, IUser user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(this.Data
                .Courses
                .GetAll()
                .OrderBy(c => c.Name)
                .ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            var course = this.CourseGetter(courseId);
            if (course == null)
            {
                throw new ArgumentNullException();
            }

            if (course.Lectures.Count == 0)
            {
                throw new ArgumentException("No lectures");
            }

            return this.View(course.Lectures);
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException("You are already enrolled in this course.");
            }

            course.AddStudent(this.User);
            return this.View(course);
        }
        
        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            // BUGFIX - inverted condition
            if (!this.User.IsInRole(Role.Lecturer)) 
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            var course = new Course(name);
            this.Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new DivideByZeroException("The current user is not authorized to perform this operation.");
            }

            ICourse course = this.CourseGetter(courseId);
            course.AddLecture(new Lecture("lectureName"));
            return this.View(course);
        }

        private ICourse CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format("There is no course with ID {0}.", courseId));
            }

            return course;
        }
    }
}
