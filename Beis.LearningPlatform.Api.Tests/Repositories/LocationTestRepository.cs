using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.Repositories
{
    public class LocationTestRepository : ILocationRepository
	{
        private readonly List<Location> _testDataStore = new()
        {
            new Location { Id = 1 },
            new Location { Id = 2 },
            new Location { Id = 3 },
            new Location { Id = 4 }
        };

		public async Task<int?> Add(Location location)
		{
			var newId = _testDataStore.Max(x => x.Id) + 1;
			location.Id = newId;
			_testDataStore.Add(location);
			return await Task.FromResult((int?)newId);
		}

		public async Task<int> DeleteById(int id)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            if (record == null) return await Task.FromResult(0);

            _testDataStore.Remove(record);
            return await Task.FromResult(1);
        }

		public async Task<Location> GetById(int id)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == id);
			return await Task.FromResult(record);
		}

		public async Task<IEnumerable<Location>> GetPaginated(PaginationParameter paginationParameter)
		{
			var records = _testDataStore.Skip(paginationParameter.Skip).Take(paginationParameter.PageSize);
			return await Task.FromResult(records);
		}

		public async Task<int> Update(Location location)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == location.Id);
            if (record == null) return await Task.FromResult(0);

            var index = _testDataStore.IndexOf(record);
            _testDataStore[index] = location;
            return await Task.FromResult(1);
        }
    }
}