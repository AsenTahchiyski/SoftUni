namespace BangaloreUniversityLearningSystem.Views.Courses
{
    using System.Text;
    using Interfaces;

    public class Create : View
    {
        public Create(ICourse course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as ICourse;
            viewResult.AppendFormat("Course {0} created successfully.", course.Name).AppendLine();
        }
    }
}
