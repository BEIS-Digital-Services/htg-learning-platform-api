using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beis.LearningPlatform.Model
{
    [Table("Location")]
	public class Location
    {        
		[Key]
		public int Id { get; set; }
		[Required]
		public bool IsActive { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Updated { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
		public string Name { get; set; }
    }
}