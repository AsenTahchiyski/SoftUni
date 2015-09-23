using System.Linq;
using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            // a question may have only one best answer
            int bestAnswerId = 0;
            if (!int.TryParse(this.Data[1], out bestAnswerId))
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            if (this.Forum.CurrentQuestion.Answers.All(a => a.Id != bestAnswerId))
            {
                throw new CommandException(Messages.NoAnswer);
            }

            if ((this.Forum.CurrentQuestion.Author.Username != this.Forum.CurrentUser.Username))
            {
                throw new CommandException(Messages.NoPermission);
            }

            //if (!(this.Forum.CurrentUser is IAdministrator))
            //{
            //    throw new CommandException(Messages.NoPermission);
            //}

            IAnswer currentAnswer = this.Forum.CurrentQuestion.Answers.FirstOrDefault(a => a.Id == bestAnswerId);
            if (currentAnswer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }
            
            Question currentQuestion = this.Forum.CurrentQuestion as Question;
            currentQuestion.BestAnswerId = bestAnswerId;
            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, bestAnswerId));
        }
    }
}
