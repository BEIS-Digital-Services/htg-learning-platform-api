using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;

namespace Beis.LearningPlatform.Dal.Interfaces
{
    public partial interface ISkillsOneResponseRepository
	{
		Task<SkillsOneResponse> GetById(int id);		

        Task<IEnumerable<SkillsOneResponse>> GetPaginated(PaginationParameter paginationParameter);
		
        Task<int?> Add(SkillsOneResponse skillsOneResponse);
		
        Task<int> Update(SkillsOneResponse skillsOneResponse);
		
        Task<int> DeleteById(int id);		
	}
}