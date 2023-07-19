using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AnimalPlaceProject.Models
{
	public class Animal
	{
		public int AnimalId { get; set; }
		[Required]
		public string? Name { get; set; }
		[Required]
		public double? Age { get; set; }

		public string? PictureName { get; set; }
		[MaxLength(100)]
		public string? Description { get; set; }
		[Required]
		public int? CategoryId { get; set; }

		public virtual Category? Category { get; set; }

		public virtual ICollection<Comment>? Comments { get; set; }

		
	}
}
