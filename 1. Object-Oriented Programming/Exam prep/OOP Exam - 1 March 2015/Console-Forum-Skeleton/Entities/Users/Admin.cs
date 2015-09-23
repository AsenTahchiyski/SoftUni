namespace ConsoleForum.Entities.Users
{
    using Contracts;

    public class Admin : User, IAdministrator
    {
        public Admin(int id, string name, string password, string email)
            : base(id, name, password, email)
        {

        }
    }
}
