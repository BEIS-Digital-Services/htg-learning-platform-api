using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beis.LearningPlatform.Model
{
    [Table("FeedbackPageUseful")]
	public class FeedbackPageUseful
    {        
		[Key]
		public int Id { get; set; }
		[Required]
		public bool IsPageUseful { get; set; }
		public string SessionId { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public string url { get; set; }
    }
}