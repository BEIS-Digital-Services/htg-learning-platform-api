using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Dapper;

namespace Beis.LearningPlatform.Dal
{
	public class LocationRepository : ILocationRepository
	{
		private readonly IDapperContext _context;

		public LocationRepository(IDapperContext context)
		{
			_context = context;
		}

		public async Task<Location> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetAsync<Location>(id);
			return rtn;
		}

		public async Task<IEnumerable<Location>> GetPaginated(PaginationParameter paginationParameter)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetListPagedAsync<Location>(paginationParameter.PageNumber, paginationParameter.PageSize, string.Empty, "\"Id\"");
			return rtn;
		}

		public async Task<int?> Add(Location location)
		{
			using var connection = _context.CreateConnection();
			var id = await connection.InsertAsync(location);
			return id;
		}

		public async Task<int> Update(Location location)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.UpdateAsync(location);
			return rowCount;
		}

		public async Task<int> DeleteById(int id)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.DeleteAsync<Location>(id);
			return rowCount;
		}
	}
}