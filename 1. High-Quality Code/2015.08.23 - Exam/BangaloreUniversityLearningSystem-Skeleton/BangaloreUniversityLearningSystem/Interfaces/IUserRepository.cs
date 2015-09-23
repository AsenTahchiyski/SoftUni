namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IUserRepository : IRepository<IUser>
    {
        IUser GetByUsername(string username);
    }
}
