namespace ConsoleForum.Entities.Posts
{
    using Contracts;

    public class BestAnswer : Answer
    {
        public BestAnswer(int id, IUser author, string body) 
            : base(id, author, body)
        {
        }
    }
}
