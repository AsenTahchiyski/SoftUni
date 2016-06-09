﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Author
    {
        private ICollection<Book> books;

        public Author(string lastName, string firstName = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
