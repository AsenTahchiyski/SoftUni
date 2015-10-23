namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername = new Dictionary<string, User>();

        public User GetByUsername(string username)
        {
            return this.GetAll().FirstOrDefault(u => u.Username == username);
        }
    }
}
