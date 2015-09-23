namespace BangaloreUniversityLearningSystem.Data
{
    using Interfaces;

    public class Data : IData
    {
        public Data()
        {
            this.Users = new UsersRepository();
            this.Courses = new Repository<ICourse>();
        }

        public IUserRepository Users { get; private set; }
        
        public IRepository<ICourse> Courses { get; private set; }
    }
}
