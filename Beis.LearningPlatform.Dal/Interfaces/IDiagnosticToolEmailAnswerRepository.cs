using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;

namespace Beis.LearningPlatform.Dal.Interfaces
{
    public interface IDiagnosticToolEmailAnswerRepository
	{
		Task<DiagnosticToolEmailAnswer> GetById(int id);
		
        Task<IEnumerable<DiagnosticToolEmailAnswer>> GetByUserEmailAddress(string userEmailAddress);
		
        Task<IEnumerable<DiagnosticToolEmailAnswer>> GetPaginated(PaginationParameter paginationParameter);
		
        Task<int?> Add(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer);
		
        Task<int> Update(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer);
		
        Task<int> DeleteById(int id);		
	}
}