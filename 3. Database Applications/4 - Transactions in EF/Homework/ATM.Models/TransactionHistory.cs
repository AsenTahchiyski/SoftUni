using System;
using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
