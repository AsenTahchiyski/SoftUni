namespace NewsDB.Data
{
    using System.Data.Entity;
    using Models;
    public class NewsDB : DbContext
    {
        public NewsDB()
            : base("name=NewsDB.Context")
        {
        }

        public virtual DbSet<News> News { get; set; }
    }
}