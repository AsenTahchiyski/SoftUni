using System.ComponentModel.DataAnnotations;

namespace NewsDB.Models
{
    public class News
    {
        public News(string content)
        {
            this.Content = content;
        }

        public News() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
