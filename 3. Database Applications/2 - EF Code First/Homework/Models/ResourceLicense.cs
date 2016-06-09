using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ResourceLicense
    {
        public ResourceLicense(string name)
        {
            this.Name = name;
        }

        public ResourceLicense() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
