namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IData
    {
        IUserRepository Users { get; }

        IRepository<ICourse> Courses { get; }
    }
}
