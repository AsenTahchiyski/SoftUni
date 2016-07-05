using System.ComponentModel.DataAnnotations;

namespace ATM.Models
{
    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string CardPIN { get; set; }

        [Required]
        public decimal CardCash { get; set; }
    }
}
