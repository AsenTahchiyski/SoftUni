namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;
    using Enumerations;

    public interface IUser
    {
        string UserName { get; set; }

        string Password { get; set; }

        Role Role { get; }

        IList<ICourse> Courses { get; }

        bool IsInRole(Role role);
    }
}
