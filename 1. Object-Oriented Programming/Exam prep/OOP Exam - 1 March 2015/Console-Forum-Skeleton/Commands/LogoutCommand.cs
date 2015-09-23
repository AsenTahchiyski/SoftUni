namespace ConsoleForum.Commands
{
    using System.Linq;
    using ConsoleForum.Contracts;
    using ConsoleForum.Entities.Users;
    using ConsoleForum.Utility;

    public class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }
        
        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            this.Forum.CurrentUser = null;
            this.Forum.CurrentQuestion = null;
            this.Forum.Output.AppendLine(Messages.LogoutSuccess);
        }
    }
}
