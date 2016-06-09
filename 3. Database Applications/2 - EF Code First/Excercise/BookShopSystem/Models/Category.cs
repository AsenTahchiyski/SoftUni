﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        private ICollection<Book> books;

        public Category(string name)
        {
            this.Name = name;
            this.books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this.books; }
            set { this.books = value; }
        }
    }
}
