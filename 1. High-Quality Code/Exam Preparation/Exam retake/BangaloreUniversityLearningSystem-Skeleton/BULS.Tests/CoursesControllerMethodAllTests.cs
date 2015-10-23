namespace BULS.Tests
{
    using System;
    using System.Text;
    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enumerations;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoursesControllerMethodAllTests
    {
        [TestMethod]
        public void TestAllCourses_ShouldReturnNoCourses()
        {
            // Arrange
            IBangaloreUniversityDatabase data = new BangaloreUniversityDatabase();
            User testUser = new User("test user", "password", Role.Student);
            CoursesController controller = new CoursesController(data, testUser);

            // Act
            IView view = controller.All();
            string result = view.Display();

            // Assert
            Assert.AreEqual("No courses.", result);
        }

        [TestMethod]
        public void TestAllCoursesOneCourse_ShouldReturnCourse()
        {
            // Arrange
            IBangaloreUniversityDatabase data = new BangaloreUniversityDatabase();
            User testUser = new User("test user", "password", Role.Student);
            CoursesController controller = new CoursesController(data, testUser);
            Course testCourse = new Course("test course");
            data.Courses.Add(testCourse);

            // Act
            IView view = controller.All();
            string result = view.Display();

            // Assert
            string expected = string.Format("All courses:{0}test course (0 students)", Environment.NewLine);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestAllCoursesMultipleCoursesNoStudents_ShouldReturnCourses()
        {
            // Arrange
            IBangaloreUniversityDatabase data = new BangaloreUniversityDatabase();
            User testUser = new User("test user", "password", Role.Student);
            CoursesController controller = new CoursesController(data, testUser);
            Course testCourse1 = new Course("test course1");
            Course testCourse2 = new Course("test course2");
            Course testCourse3 = new Course("test course3");
            Course testCourse4 = new Course("test course4");
            Course testCourse5 = new Course("test course5");
            Course testCourse6 = new Course("test course6");
            Course testCourse7 = new Course("test course7");
            Course testCourse8 = new Course("test course8");
            Course testCourse9 = new Course("test course9");
            Course testCourse10 = new Course("test course10");
            data.Courses.Add(testCourse1);
            data.Courses.Add(testCourse2);
            data.Courses.Add(testCourse3);
            data.Courses.Add(testCourse4);
            data.Courses.Add(testCourse5);
            data.Courses.Add(testCourse6);
            data.Courses.Add(testCourse7);
            data.Courses.Add(testCourse8);
            data.Courses.Add(testCourse9);
            data.Courses.Add(testCourse10);

            // Act
            IView view = controller.All();
            string result = view.Display();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("All courses:");
            expected.AppendLine("test course1 (0 students)");
            expected.AppendLine("test course10 (0 students)");
            expected.AppendLine("test course2 (0 students)");
            expected.AppendLine("test course3 (0 students)");
            expected.AppendLine("test course4 (0 students)");
            expected.AppendLine("test course5 (0 students)");
            expected.AppendLine("test course6 (0 students)");
            expected.AppendLine("test course7 (0 students)");
            expected.AppendLine("test course8 (0 students)");
            expected.Append("test course9 (0 students)");

            // Assert
            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void TestAllCoursesMultipleCoursesWithStudents_ShouldReturnCoursesWithCorrectStudentCount()
        {
            // Arrange
            IBangaloreUniversityDatabase data = new BangaloreUniversityDatabase();
            User testUser = new User("test user", "password", Role.Student);
            CoursesController controller = new CoursesController(data, testUser);
            Course testCourse1 = new Course("test course1");
            Course testCourse2 = new Course("test course2");
            Course testCourse3 = new Course("test course3");
            Course testCourse4 = new Course("test course4");
            Course testCourse5 = new Course("test course5");
            Course testCourse6 = new Course("test course6");
            Course testCourse7 = new Course("test course7");
            Course testCourse8 = new Course("test course8");
            Course testCourse9 = new Course("test course9");
            
            User student1 = new User("student1", "password", Role.Student);
            User student2 = new User("student2", "password", Role.Student);
            User student3 = new User("student3", "password", Role.Student);
            User student4 = new User("student4", "password", Role.Student);
            User student5 = new User("student5", "password", Role.Student);
            User student6 = new User("student6", "password", Role.Student);

            testCourse1.AddStudent(student1);
            testCourse1.AddStudent(student2);
            testCourse1.AddStudent(student3);
            testCourse1.AddStudent(student4);
            testCourse1.AddStudent(student5);
            testCourse1.AddStudent(student6);

            testCourse2.AddStudent(student1);
            testCourse2.AddStudent(student2);
            testCourse2.AddStudent(student3);
            testCourse2.AddStudent(student4);
            testCourse2.AddStudent(student5);

            testCourse3.AddStudent(student1);
            testCourse3.AddStudent(student2);
            testCourse3.AddStudent(student3);
            testCourse3.AddStudent(student4);
            testCourse3.AddStudent(student5);

            testCourse4.AddStudent(student2);
            testCourse4.AddStudent(student3);
            testCourse4.AddStudent(student4);
            testCourse4.AddStudent(student5);

            testCourse5.AddStudent(student4);
            testCourse5.AddStudent(student5);
            testCourse5.AddStudent(student6);

            testCourse6.AddStudent(student1);
            testCourse6.AddStudent(student2);
            testCourse6.AddStudent(student3);

            testCourse7.AddStudent(student2);
            testCourse7.AddStudent(student3);

            testCourse8.AddStudent(student5);

            data.Courses.Add(testCourse1);
            data.Courses.Add(testCourse2);
            data.Courses.Add(testCourse3);
            data.Courses.Add(testCourse4);
            data.Courses.Add(testCourse5);
            data.Courses.Add(testCourse6);
            data.Courses.Add(testCourse7);
            data.Courses.Add(testCourse8);
            data.Courses.Add(testCourse9);

            // Act
            IView view = controller.All();
            string result = view.Display();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("All courses:");
            expected.AppendLine("test course1 (6 students)");
            expected.AppendLine("test course2 (5 students)");
            expected.AppendLine("test course3 (5 students)");
            expected.AppendLine("test course4 (4 students)");
            expected.AppendLine("test course5 (3 students)");
            expected.AppendLine("test course6 (3 students)");
            expected.AppendLine("test course7 (2 students)");
            expected.AppendLine("test course8 (1 students)");
            expected.Append("test course9 (0 students)");

            // Assert
            Assert.AreEqual(expected.ToString(), result);
        }

        [TestMethod]
        public void TestAllCoursesMultipleCoursesWithStudents_ShouldReturnCoursesWithCorrectStudentCountOrderedCorrectly()
        {
            // Arrange
            IBangaloreUniversityDatabase data = new BangaloreUniversityDatabase();
            User testUser = new User("test user", "password", Role.Student);
            CoursesController controller = new CoursesController(data, testUser);
            Course testCourse1 = new Course("C# Basics");
            Course testCourse2 = new Course("Java Basics");
            Course testCourse3 = new Course("C Basics");
            Course testCourse4 = new Course("JavaScript");
            Course testCourse5 = new Course("Java Advanced");
            Course testCourse6 = new Course("HTML & CSS");
            Course testCourse7 = new Course("Java Basics");
            Course testCourse8 = new Course("C# Advanced");
            Course testCourse9 = new Course("C# Basics");

            User student1 = new User("student1", "password", Role.Student);
            User student2 = new User("student2", "password", Role.Student);
            User student3 = new User("student3", "password", Role.Student);
            User student4 = new User("student4", "password", Role.Student);
            User student5 = new User("student5", "password", Role.Student);
            User student6 = new User("student6", "password", Role.Student);

            testCourse9.AddStudent(student1);
            testCourse9.AddStudent(student2);
            testCourse9.AddStudent(student3);
            testCourse9.AddStudent(student4);
            testCourse9.AddStudent(student5);
            testCourse9.AddStudent(student6);

            testCourse8.AddStudent(student1);
            testCourse8.AddStudent(student2);
            testCourse8.AddStudent(student3);
            testCourse8.AddStudent(student4);
            testCourse8.AddStudent(student5);

            testCourse1.AddStudent(student1);
            testCourse1.AddStudent(student2);
            testCourse1.AddStudent(student3);
            testCourse1.AddStudent(student4);
            testCourse1.AddStudent(student5);

            testCourse2.AddStudent(student2);
            testCourse2.AddStudent(student3);
            testCourse2.AddStudent(student4);
            testCourse2.AddStudent(student5);

            testCourse7.AddStudent(student4);
            testCourse7.AddStudent(student5);
            testCourse7.AddStudent(student6);

            testCourse5.AddStudent(student1);
            testCourse5.AddStudent(student3);

            testCourse6.AddStudent(student2);
            testCourse6.AddStudent(student3);

            testCourse3.AddStudent(student5);

            data.Courses.Add(testCourse1);
            data.Courses.Add(testCourse2);
            data.Courses.Add(testCourse3);
            data.Courses.Add(testCourse4);
            data.Courses.Add(testCourse5);
            data.Courses.Add(testCourse6);
            data.Courses.Add(testCourse7);
            data.Courses.Add(testCourse8);
            data.Courses.Add(testCourse9);

            // Act
            IView view = controller.All();
            string result = view.Display();
            StringBuilder expected = new StringBuilder();
            expected.AppendLine("All courses:");
            expected.AppendLine("C Basics (1 students)");
            expected.AppendLine("C# Advanced (5 students)");
            expected.AppendLine("C# Basics (6 students)");
            expected.AppendLine("C# Basics (5 students)");
            expected.AppendLine("HTML & CSS (2 students)");
            expected.AppendLine("Java Advanced (2 students)");
            expected.AppendLine("Java Basics (4 students)");
            expected.AppendLine("Java Basics (3 students)");
            expected.Append("JavaScript (0 students)");

            // Assert
            Assert.AreEqual(expected.ToString(), result);
        }
    }
}
