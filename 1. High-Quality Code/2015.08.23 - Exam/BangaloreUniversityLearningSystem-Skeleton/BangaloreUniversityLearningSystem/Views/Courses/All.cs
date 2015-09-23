namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class All : View
    {
        public All(IEnumerable<ICourse> courses)
            : base(courses)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var courses = this.Model as IEnumerable<ICourse>;
            if (!courses.Any())
            {
                viewResult.AppendLine("No courses.");
            }
            else
            {
                viewResult.AppendLine("All courses:");
                foreach (var course in courses)
                {
                    viewResult.AppendFormat("{0} ({1} students)", course.Name, course.Students.Count).AppendLine();
                }
            }
        }
    }
}
