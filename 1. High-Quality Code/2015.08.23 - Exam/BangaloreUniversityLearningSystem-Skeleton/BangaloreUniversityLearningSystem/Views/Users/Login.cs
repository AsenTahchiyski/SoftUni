﻿namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Interfaces;

    public class Login : View
    {
        public Login(IUser user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} logged in successfully.", (this.Model as IUser).UserName).AppendLine();
        }
    }
}