using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beis.LearningPlatform.Model
{
    [Table("SatisfactionSurveyEntry")]
	public class SatisfactionSurveyEntry
    {        
		[Key]
		public int Id { get; set; }
		public string UserEmailAddress { get; set; }
		public string SessionId { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public string url { get; set; }
		public string rating { get; set; }
		public string comment { get; set; }
    }
}