using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Dapper;

namespace Beis.LearningPlatform.Dal
{
    public class FeedbackPageUsefulRepository : IFeedbackPageUsefulRepository
	{
		private readonly IDapperContext _context;

		public FeedbackPageUsefulRepository(IDapperContext context)
		{
			_context = context;
		}

		public async Task<FeedbackPageUseful> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetAsync<FeedbackPageUseful>(id);
			return rtn;
		}

		public async Task<IEnumerable<FeedbackPageUseful>> GetPaginated(PaginationParameter paginationParameter)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetListPagedAsync<FeedbackPageUseful>(paginationParameter.PageNumber, paginationParameter.PageSize, string.Empty, "\"Id\"");
			return rtn;
		}

		public async Task<int?> Add(FeedbackPageUseful feedbackPageUseful)
		{
			using var connection = _context.CreateConnection();
			var id = await connection.InsertAsync(feedbackPageUseful);
			return id;
		}

		public async Task<int> Update(FeedbackPageUseful feedbackPageUseful)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.UpdateAsync(feedbackPageUseful);
			return rowCount;
		}

		public async Task<int> DeleteById(int id)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.DeleteAsync<FeedbackPageUseful>(id);
			return rowCount;
		}
	}
}