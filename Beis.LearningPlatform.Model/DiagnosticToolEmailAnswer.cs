using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beis.LearningPlatform.Model
{
    [Table("DiagnosticToolEmailAnswer")]
	public class DiagnosticToolEmailAnswer
    {        
		[Key]
		public int Id { get; set; }
		public string UserEmailAddress { get; set; }
		public bool? IsPrivacyPolicyAccepted { get; set; }
		public bool? IsOptedInForMarketing { get; set; }
		public bool? IsUnsubscribed { get; set; }
		public DateTime? UnsubscribeTimestamp { get; set; }
		public string SessionId { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public string url { get; set; }
		public string HowSalesTakePlace { get; set; }
		public string WhichSector { get; set; }
		public string SoftwareUsed { get; set; }
		public string CurrentSupport { get; set; }
		public string StoreOnPaper { get; set; }
		public string StoreOnIndividualDrives { get; set; }
		public string StoreOnSharedDrives { get; set; }
		public string StoreOnCloud { get; set; }
		public string SoftwareNeedsKnown { get; set; }
		public string SoftwareCRM { get; set; }
		public string SoftwareECommerce { get; set; }
		public string SoftwareDigitalAccounting { get; set; }
		public string SoftwareSomethingElse { get; set; }
		public string SoftwareAdditionalInfo { get; set; }
		public string SimplifyPaymentsAndListing { get; set; }
		public string SimplifySellingViaWebsite { get; set; }
		public string SimplifyCustomerExperiences { get; set; }
		public string SimplifyTaxAndAccounting { get; set; }
		public string SimplifySalesInfo { get; set; }
		public string SimplifyStockLevels { get; set; }
		public string SimplifyMonitoringSales { get; set; }
		public string SimplifyCustomersNeeds { get; set; }
		public string SimplifyCommunication { get; set; }
		public string SimplifyNone { get; set; }
		public string SimplifyAdditionalInfo { get; set; }



    }
}