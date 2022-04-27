using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;

namespace Beis.LearningPlatform.Dal.Interfaces
{
    public partial interface ILocationRepository
    {
        Task<Location> GetById(int id);

        Task<IEnumerable<Location>> GetPaginated(PaginationParameter paginationParameter);
        
        Task<int?> Add(Location location);
        
        Task<int> Update(Location location);
        
        Task<int> DeleteById(int id);
    }
}