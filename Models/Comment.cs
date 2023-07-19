using System.ComponentModel.DataAnnotations;

namespace AnimalPlaceProject.Models
{
	public class Comment
	{
		public int Id { get; set; }
		[Required, MaxLength(50)]
		public string? Content { get; set; }
		public int? animalId { get; set; }
        public int? numOfLikes { get; set; }
		public bool? isLiked { get; set; }	
        public virtual Animal? Animal { get; set; }

	}
}
