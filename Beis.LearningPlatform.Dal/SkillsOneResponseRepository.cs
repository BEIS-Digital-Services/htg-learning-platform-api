using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Dapper;

namespace Beis.LearningPlatform.Dal
{
    public class SkillsOneResponseRepository : ISkillsOneResponseRepository
	{
		private readonly IDapperContext _context;

		public SkillsOneResponseRepository(IDapperContext context)
		{
			_context = context;
		}

		public async Task<SkillsOneResponse> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetAsync<SkillsOneResponse>(id);
			return rtn;
		}

		public async Task<IEnumerable<SkillsOneResponse>> GetPaginated(PaginationParameter paginationParameter)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetListPagedAsync<SkillsOneResponse>(paginationParameter.PageNumber, paginationParameter.PageSize, string.Empty, "\"Id\"");
			return rtn;
		}

		public async Task<int?> Add(SkillsOneResponse skillsOneResponse)
		{
			using var connection = _context.CreateConnection();
			var id = await connection.InsertAsync(skillsOneResponse);
			return id;
		}

		public async Task<int> Update(SkillsOneResponse skillsOneResponse)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.UpdateAsync(skillsOneResponse);
			return rowCount;
		}

		public async Task<int> DeleteById(int id)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.DeleteAsync<SkillsOneResponse>(id);
			return rowCount;
		}
	}
}