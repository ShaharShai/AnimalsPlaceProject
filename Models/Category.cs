using System.ComponentModel.DataAnnotations;

namespace AnimalPlaceProject.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		[Required]
		public string? Name { get; set; }

		public virtual ICollection<Animal>? Animals { get; set; }
	}
}
