﻿namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;
    using Interfaces;

    public class Register : View
    {
        public Register(IUser user)
            : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            viewResult.AppendFormat("User {0} registered successfully.", (this.Model as IUser).UserName).AppendLine();
        }
    }
}
