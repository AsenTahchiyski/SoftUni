namespace BangaloreUniversityLearningSystem.Views
{
    using System.Text;
    using Interfaces;

    public class AddLecture : View
    {
        public AddLecture(ICourse course)
            : base(course)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var course = this.Model as ICourse;
            viewResult
                .AppendFormat("Lecture successfully added to course {0}.", course.Name)
                .AppendLine();
        }
    }
}
