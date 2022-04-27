using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;

namespace Beis.LearningPlatform.Dal.Interfaces
{
	public partial interface ISatisfactionSurveyEntryRepository
	{
		Task<SatisfactionSurveyEntry> GetById(int id);		

        Task<IEnumerable<SatisfactionSurveyEntry>> GetPaginated(PaginationParameter paginationParameter);
		
        Task<int?> Add(SatisfactionSurveyEntry satisfactionSurveyEntry);
		
        Task<int> Update(SatisfactionSurveyEntry satisfactionSurveyEntry);
		
        Task<int> DeleteById(int id);		
	}
}