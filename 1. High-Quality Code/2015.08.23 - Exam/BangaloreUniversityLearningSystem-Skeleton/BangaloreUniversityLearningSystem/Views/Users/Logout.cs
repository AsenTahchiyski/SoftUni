namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Interfaces;

    public class Logout : View
    {
        public Logout(IUser user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged out successfully.", (this.Model as IUser).UserName).AppendLine();
        }
    }
}
