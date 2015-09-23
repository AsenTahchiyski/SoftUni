namespace ConsoleForum.Commands
{
    using System.Linq;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Utility;
    using ConsoleForum.Contracts;

    public class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }
        
        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }

            IUser user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
            else
            {
                this.Forum.CurrentUser = user;
                this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, user.Username));
            }
        }
    }
}
