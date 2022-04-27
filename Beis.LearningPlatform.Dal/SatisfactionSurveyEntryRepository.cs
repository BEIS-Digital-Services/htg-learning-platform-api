using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Dapper;

namespace Beis.LearningPlatform.Dal
{
	public class SatisfactionSurveyEntryRepository : ISatisfactionSurveyEntryRepository
	{
		private readonly IDapperContext _context;

		public SatisfactionSurveyEntryRepository(IDapperContext context)
		{
			_context = context;
		}

		public async Task<SatisfactionSurveyEntry> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetAsync<SatisfactionSurveyEntry>(id);
			return rtn;
		}

		public async Task<IEnumerable<SatisfactionSurveyEntry>> GetPaginated(PaginationParameter paginationParameter)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetListPagedAsync<SatisfactionSurveyEntry>(paginationParameter.PageNumber, paginationParameter.PageSize, string.Empty, "\"Id\"");
			return rtn;
		}

		public async Task<int?> Add(SatisfactionSurveyEntry satisfactionSurveyEntry)
		{
			using var connection = _context.CreateConnection();
			var id = await connection.InsertAsync(satisfactionSurveyEntry);
			return id;
		}

		public async Task<int> Update(SatisfactionSurveyEntry satisfactionSurveyEntry)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.UpdateAsync(satisfactionSurveyEntry);
			return rowCount;
		}

		public async Task<int> DeleteById(int id)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.DeleteAsync<SatisfactionSurveyEntry>(id);
			return rowCount;
		}
	}
}