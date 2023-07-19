using Microsoft.Build.Framework;

namespace AnimalPlaceProject.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]

        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
