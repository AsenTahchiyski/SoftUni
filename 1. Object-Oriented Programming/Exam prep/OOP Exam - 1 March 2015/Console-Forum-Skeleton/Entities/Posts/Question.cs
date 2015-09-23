using System.Linq;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    using Contracts;
    using System.Collections.Generic;

    public class Question : Post, IQuestion
    {
        public string Title { get; set; }

        public IList<IAnswer> Answers { get; set; }

        public int BestAnswerId { get; set; }

        public Question(string title, int id, string body, IUser author)
            : base(id, author, body)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("[ Question ID: {0} ]", this.Id));
            output.AppendLine(string.Format("Posted by: {0}", this.Author.Username));
            output.AppendLine(string.Format("Question Title: {0}", this.Title));
            output.AppendLine(string.Format("Question Body: {0}", this.Body));
            output.AppendLine("====================");

            if (this.Answers.Count == 0)
            {
                output.Append("No answers");
            }
            else
            {
                output.AppendLine("Answers:");

                if (this.BestAnswerId != 0)
                {
                    output.AppendLine("********************");
                    output.AppendLine(this.Answers[BestAnswerId - 1].ToString());
                    output.AppendLine("********************");
                }

                foreach (IAnswer answer in this.Answers)
                {
                    if (answer.Id != BestAnswerId)
                    {
                        output.AppendLine(answer.ToString());
                    }
                }
            }
            
            return output.ToString().TrimEnd();
        }
    }
}
