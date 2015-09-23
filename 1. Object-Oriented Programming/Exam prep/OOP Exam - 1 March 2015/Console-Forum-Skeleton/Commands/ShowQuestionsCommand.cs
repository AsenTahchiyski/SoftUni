using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }
        
        public override void Execute()
        {
            var questions = this.Forum.Questions;

            if (questions.Count == 0 || questions == null)
            {
                throw new CommandException(Messages.NoQuestions);
            }
            else
            {
                foreach (IQuestion question in questions)
                {
                    this.Forum.Output.AppendLine(question.ToString());
                }
            }
        }
    }
}
