using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }
        
        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            
            string title = this.Data[1];
            string body = this.Data[2];

            IQuestion newQuestion = new Question(title, this.Forum.Questions.Count + 1, body, this.Forum.CurrentUser);
            this.Forum.Questions.Add(newQuestion);
            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, newQuestion.Id));
        }
    }
}
