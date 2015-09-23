using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }
        
        public override void Execute()
        {
            string body = this.Data[1];

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            IAnswer answer = new Answer(this.Forum.Answers.Count + 1, this.Forum.CurrentUser, body);

            this.Forum.CurrentQuestion.Answers.Add(answer);
            this.Forum.Answers.Add(answer);
            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, answer.Id));
        }
    }
}
