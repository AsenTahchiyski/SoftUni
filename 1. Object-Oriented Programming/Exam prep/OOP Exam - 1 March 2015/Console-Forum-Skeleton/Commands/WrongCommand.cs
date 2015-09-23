using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class WrongCommand : AbstractCommand
    {
        public WrongCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
