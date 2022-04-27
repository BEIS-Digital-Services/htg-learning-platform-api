using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;

namespace Beis.LearningPlatform.Dal.Interfaces
{
    public interface IFeedbackProblemReportRepository
    {
        Task<FeedbackProblemReport> GetById(int id);

        Task<IEnumerable<FeedbackProblemReport>> GetPaginated(PaginationParameter paginationParameter);

        Task<int?> Add(FeedbackProblemReport feedbackProblemReport);

        Task<int> Update(FeedbackProblemReport feedbackProblemReport);

        Task<int> DeleteById(int id);
    }
}