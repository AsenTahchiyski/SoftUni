namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Linq;
    using Enumerations;
    using Exceptions;
    using Interfaces;
    using Models;
    using Utilities;

    public class CoursesController : Controller
    {
        public CoursesController(IBangaloreUniversityDatabase data, User user)
        {
            this.Data = data;
            this.User = user;
        }

        public IView All()
        {
            return this.View(this.Data.Courses.GetAll().OrderBy(c => c.Name).ThenByDescending(c => c.Students.Count));
        }

        public IView Details(int courseId)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(GlobalMessages.NoUserLogged);
            }

            this.EnsureAuthorization(Role.Student, Role.Lecturer);

            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(GlobalMessages.NoCourseWithId, courseId));
            }

            if (!this.User.Courses.Contains(course))
            {
                throw new ArgumentException(GlobalMessages.NotEnrolledInCourse);
            }
            
            return this.View(this.CourseGetter(courseId));
        }

        public IView Enroll(int courseId)
        {
            this.EnsureAuthorization(Role.Student, Role.Lecturer);
            var course = Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(GlobalMessages.NoCourseWithId, courseId));
            }

            if (this.User.Courses.Contains(course))
            {
                throw new ArgumentException(GlobalMessages.AlreadyEnrolledInCourse);
            }

            course.AddStudent(this.User);
            return this.View(course);
        }

        public IView Create(string name)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(GlobalMessages.NoUserLogged);
            }

            // BUG2: Boolean condition inverted.
            if (!this.User.IsInRole(Role.Lecturer)) 
            {
                throw new AuthorizationFailedException(GlobalMessages.AuthorizationFailed);
            }

            var course = new Course(name);
            Data.Courses.Add(course);
            return this.View(course);
        }

        public IView AddLecture(int courseId, string lectureName)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(GlobalMessages.NoUserLogged);
            }

            if (!this.User.IsInRole(Role.Lecturer))
            {
                throw new AuthorizationFailedException(GlobalMessages.AuthorizationFailed);
            }

            Course course = this.CourseGetter(courseId);
            course.AddLecture(new Lecture(lectureName)); // BUG3: "lectureName" should not be a string but the variable passed on to the method
            return this.View(course);
        }

        private Course CourseGetter(int courseId)
        {
            var course = this.Data.Courses.Get(courseId);
            if (course == null)
            {
                throw new ArgumentException(string.Format(GlobalMessages.NoCourseWithId, courseId));
            }

            return course;
        }
    }
}
