using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Dapper;

namespace Beis.LearningPlatform.Dal
{
    public class FeedbackProblemReportRepository : IFeedbackProblemReportRepository
    {
        private readonly IDapperContext _context;

        public FeedbackProblemReportRepository(IDapperContext context)
        {
            _context = context;
        }

        public async Task<FeedbackProblemReport> GetById(int id)
        {
            using var connection = _context.CreateConnection();
            var rtn = await connection.GetAsync<FeedbackProblemReport>(id);
            return rtn;
        }

        public async Task<IEnumerable<FeedbackProblemReport>> GetPaginated(PaginationParameter paginationParameter)
        {
            using var connection = _context.CreateConnection();
            var rtn = await connection.GetListPagedAsync<FeedbackProblemReport>(paginationParameter.PageNumber, paginationParameter.PageSize, string.Empty, "\"Id\"");
            return rtn;
        }

        public async Task<int?> Add(FeedbackProblemReport feedbackProblemReport)
        {
            using var connection = _context.CreateConnection();
            var id = await connection.InsertAsync(feedbackProblemReport);
            return id;
        }

        public async Task<int> Update(FeedbackProblemReport feedbackProblemReport)
        {
            using var connection = _context.CreateConnection();
            var rowCount = await connection.UpdateAsync(feedbackProblemReport);
            return rowCount;
        }

        public async Task<int> DeleteById(int id)
        {
            using var connection = _context.CreateConnection();
            var rowCount = await connection.DeleteAsync<FeedbackProblemReport>(id);
            return rowCount;
        }
    }
}