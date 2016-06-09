using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Resource
    {
        private Course course;
        private ICollection<ResourceLicense> licenses;

        public Resource(Course course, int lectureNumber, string name, ResourceType type, string url)
        {
            this.course = course;
            this.LectureNumber = lectureNumber;
            this.Name = name;
            this.Type = type;
            this.Url = url;
            this.licenses = new HashSet<ResourceLicense>();
        }

        // necessary to enable printing courses with no resources
        public Resource() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public int LectureNumber { get; set; }

        public virtual Course Course
        {
            get { return this.course; }
            set { this.course = value; }
        }

        public virtual ICollection<ResourceLicense> Licenses
        {
            get { return this.licenses; }
            set { this.licenses = value; }
        }
    }
}
