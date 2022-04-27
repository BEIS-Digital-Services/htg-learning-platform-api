using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using Dapper;

namespace Beis.LearningPlatform.Dal
{
    public class DiagnosticToolEmailAnswerRepository : IDiagnosticToolEmailAnswerRepository
	{
		private readonly IDapperContext _context;

		public DiagnosticToolEmailAnswerRepository(IDapperContext context)
		{
			_context = context;
		}

		public async Task<DiagnosticToolEmailAnswer> GetById(int id)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetAsync<DiagnosticToolEmailAnswer>(id);
			return rtn;
		}
        public async Task<IEnumerable<DiagnosticToolEmailAnswer>> GetByUserEmailAddress(string userEmailAddress)
        {
            if (string.IsNullOrEmpty(userEmailAddress))
            {
                throw new ArgumentException($"'{nameof(userEmailAddress)}' cannot be null or empty.", nameof(userEmailAddress));
            }

            using var connection = _context.CreateConnection();
            var rtn = await connection.GetListAsync<DiagnosticToolEmailAnswer>(new { UserEmailAddress = userEmailAddress });
            return rtn;
        }
		public async Task<IEnumerable<DiagnosticToolEmailAnswer>> GetPaginated(PaginationParameter paginationParameter)
		{
			using var connection = _context.CreateConnection();
			var rtn = await connection.GetListPagedAsync<DiagnosticToolEmailAnswer>(paginationParameter.PageNumber, paginationParameter.PageSize, string.Empty, "\"Id\"");
			return rtn;
		}

		public async Task<int?> Add(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer)
		{
			using var connection = _context.CreateConnection();
			var id = await connection.InsertAsync(diagnosticToolEmailAnswer);
			return id;
		}

		public async Task<int> Update(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.UpdateAsync(diagnosticToolEmailAnswer);
			return rowCount;
		}

		public async Task<int> DeleteById(int id)
		{
			using var connection = _context.CreateConnection();
			var rowCount = await connection.DeleteAsync<DiagnosticToolEmailAnswer>(id);
			return rowCount;
		}
	}
}