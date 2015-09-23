namespace ConsoleForum.Entities.Posts
{
    using Contracts;

    public abstract class Post : IPost
    {
        public int Id { get; set; }
        public IUser Author { get; set; }
        public string Body { get; set; }

        protected Post(int id, IUser author, string body)
        {
            this.Id = id;
            this.Author = author;
            this.Body = body;
        }
    }
}
