using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        private Author author;
        private ICollection<Category> categories;
        private ICollection<Book> relatedBooks;

        public Book(string title, Editions edition, Author author, decimal price, int copies, AgeRestrictions ageRestriction, DateTime? releaseDate = null, string description = null)
        {
            this.Title = title;
            this.Description = description;
            this.Edition = edition;
            this.author = author;
            this.Price = price;
            this.Copies = copies;
            this.ReleaseDate = releaseDate;
            this.categories = new HashSet<Category>();
            this.AgeRestriction = ageRestriction;
            this.relatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public Editions Edition { get; set; }

        public AgeRestrictions AgeRestriction { get; set; }

        public int AuthorId { get; set; }

        [Required]
        public virtual Author Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }

        public virtual ICollection<Book> RelatedBooks
        {
            get { return this.relatedBooks; }
            set { this.relatedBooks = value; }
        }
    }
}
