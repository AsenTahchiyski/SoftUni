namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class UserRepository : Repository<IUser>, IUserRepository
    {
        //// private Dictionary<string, IUser> usersByUsername;

        public IUser GetByUsername(string username)
        {
            return this.GetAll().FirstOrDefault(u => u.UserName == username);
        }
    }
}
