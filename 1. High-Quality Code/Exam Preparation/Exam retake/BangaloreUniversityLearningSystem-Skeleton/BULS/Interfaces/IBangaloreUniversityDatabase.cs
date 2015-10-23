namespace BangaloreUniversityLearningSystem.Interfaces
{
    using Data;
    using Models;

    public interface IBangaloreUniversityDatabase
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}
