using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;

namespace Beis.LearningPlatform.Dal.Interfaces
{
	public interface IFeedbackPageUsefulRepository
	{
		Task<FeedbackPageUseful> GetById(int id);		
		
        Task<IEnumerable<FeedbackPageUseful>> GetPaginated(PaginationParameter paginationParameter);
		
        Task<int?> Add(FeedbackPageUseful feedbackPageUseful);
		
        Task<int> Update(FeedbackPageUseful feedbackPageUseful);
		
        Task<int> DeleteById(int id);		
	}
}