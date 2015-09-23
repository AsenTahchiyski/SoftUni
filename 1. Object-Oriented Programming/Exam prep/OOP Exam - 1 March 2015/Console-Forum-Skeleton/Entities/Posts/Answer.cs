using System.Text;

namespace ConsoleForum.Entities.Posts
{
    using Contracts;

    public class Answer : Post, IAnswer
    {
        public Answer(int id, IUser author, string body) : base(id, author, body)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("[ Answer ID: {0} ]", this.Id));
            output.AppendLine(string.Format("Posted by: {0}", this.Author.Username));
            output.AppendLine(string.Format("Answer Body: {0}", this.Body));
            output.Append("--------------------");

            return output.ToString();
        }
    }
}
