﻿namespace Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CatalogueId { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }
    }
}