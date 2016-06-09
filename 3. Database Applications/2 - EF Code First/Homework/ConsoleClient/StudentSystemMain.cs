using System.Linq;
using DataLayer;

namespace ConsoleClient
{
    public class StudentSystemMain
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            var students = context.Students.Count();

            // 1.	Lists all students and their homework submissions. Select only their names and for each homework - content and content-type.
            //var result1 = context.Students
            //    .Select(s => new
            //    {
            //        s.Name,
            //        Homeworks = s.Homeworks.Select(h => new
            //        {
            //            h.Content,
            //            h.ContentType
            //        })
            //    });

            //foreach (var student in result1)
            //{
            //    Console.WriteLine("Student name: " + student.Name);
            //    foreach (var homework in student.Homeworks)
            //    {
            //        Console.WriteLine("-- {0} ({1})", homework.Content, homework.ContentType);
            //    }
            //}

            // 2.	List all courses with their corresponding resources. Select the course name and description and everything for each resource. Order the courses by start date (ascending), then by end date (descending).
            //var result2 = context.Courses
            //    .OrderBy(c => c.StartDate)
            //    .ThenByDescending(c => c.EndDate)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.Description,
            //        c.Resources
            //    });

            //foreach (var course in result2)
            //{
            //    Console.WriteLine("Course: " + course.Name);
            //    Console.WriteLine("Description: " + course.Description);
            //    foreach (var resource in course.Resources)
            //    {
            //        Console.WriteLine("Lecture {0} - {1} ({2}) // {3}", resource.LectureNumber, resource.Name, resource.Type, resource.Url);
            //    }
            //}

            // 3.	List all courses with more than 5 resources. Order them by resources count (descending), then by start date (descending). Select only the course name and the resource count.
            //var result3 = context.Courses
            //    .Where(c => c.Resources.Count >= 5)
            //    .OrderByDescending(c => c.Resources.Count)
            //    .ThenByDescending(c => c.StartDate)
            //    .Select(c => new
            //    {
            //        c.Name,
            //        ResourceCount = c.Resources.Count
            //    });

            //foreach (var course in result3)
            //{
            //    Console.WriteLine("Course name: {0} ({1} resources)", course.Name, course.ResourceCount);
            //}

            // 4.	List all courses which were active on a given date (choose the date depending on the data seeded to ensure there are results), and for each course count the number of students enrolled. Select the course name, start and end date, course duration (difference between end and start date) and number of students enrolled.Order the results by the number of students enrolled(in descending order), then by duration(descending).
            //var date = new DateTime(2016, 1, 13);
            //var result4 = context.Courses
            //    .Where(c => c.StartDate <= date && c.EndDate >= date)
            //    .AsEnumerable()
            //    .Select(c => new
            //    {
            //        c.Name,
            //        c.StartDate,
            //        c.EndDate,
            //        Duration = (int)(c.EndDate - c.StartDate).TotalDays,
            //        Students = c.Students.Count
            //    })
            //    .OrderByDescending(c => c.Students)
            //    .ThenByDescending(c => c.Duration);

            //foreach (var course in result4)
            //{
            //    Console.WriteLine("{0} ({1:dd-MM-yyyy} - {2:dd-MM-yyyy}) - {3} days // {4} students", 
            //        course.Name, course.StartDate, course.EndDate, course.Duration, course.Students);
            //}

            // 5.	For each student, calculate the number of courses he/she has enrolled in, the total price of these courses and the average price per course for the student. Select the student name, number of courses, total price and average price. Order the results by total price (descending), then by number of courses(descending) and then by the student's name (ascending).
            //var result5 = context.Students
            //    .Select(s => new
            //    {
            //        s.Name,
            //        CoursesTotal = s.Courses.Count,
            //        TotalCoursesPrice = s.Courses.Sum(c => c.Price),
            //        AverageCoursePrice = s.Courses.Average(c => c.Price)
            //    })
            //    .OrderByDescending(s => s.TotalCoursesPrice)
            //    .ThenByDescending(s => s.CoursesTotal)
            //    .ThenBy(s => s.Name);

            //foreach (var student in result5)
            //{
            //    Console.WriteLine("{0} ({1} course/s)\nAverage course price: {2:f2} BGN\nTotal courses price: {3:f2} BGN", 
            //        student.Name, student.CoursesTotal, student.AverageCoursePrice, student.TotalCoursesPrice);
            //}
        }
    }
}
