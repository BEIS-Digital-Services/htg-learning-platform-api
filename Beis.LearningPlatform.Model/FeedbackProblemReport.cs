using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beis.LearningPlatform.Model
{
    [Table("FeedbackProblemReport")]
	public class FeedbackProblemReport
    {        
		[Key]
		public int Id { get; set; }
		public string WhatIWasDoing { get; set; }
		public string WhatWentWrong { get; set; }
		public string SessionId { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public string url { get; set; }
    }
}