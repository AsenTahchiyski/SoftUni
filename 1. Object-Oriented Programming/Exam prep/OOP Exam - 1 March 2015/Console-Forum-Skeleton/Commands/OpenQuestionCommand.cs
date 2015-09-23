using System.Linq;

namespace ConsoleForum.Commands
{
    using ConsoleForum.Contracts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = 0;
            if (!int.TryParse(this.Data[1], out questionId))
            {
                throw new CommandException(Messages.NoQuestion);
            }

            IQuestion question = this.Forum.Questions.FirstOrDefault(q => q.Id == questionId);
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestion);
            }

            this.Forum.CurrentQuestion = question;
            this.Forum.Output.AppendLine(question.ToString());
        }
    }
}
