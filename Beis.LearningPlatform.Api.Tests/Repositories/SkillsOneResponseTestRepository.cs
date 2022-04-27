using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.Repositories
{
    public class SkillsOneResponseTestRepository : ISkillsOneResponseRepository
	{
        private readonly List<SkillsOneResponse> _testDataStore = new()
        {
            new SkillsOneResponse { Id = 1 },
            new SkillsOneResponse { Id = 2 },
            new SkillsOneResponse { Id = 3 },
            new SkillsOneResponse { Id = 4 }
        };

		public async Task<int?> Add(SkillsOneResponse skillsOneResponse)
		{
			var newId = _testDataStore.Max(x => x.Id) + 1;
			skillsOneResponse.Id = newId;
			_testDataStore.Add(skillsOneResponse);
			return await Task.FromResult((int?)newId);
		}

		public async Task<int> DeleteById(int id)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            if (record == null) return await Task.FromResult(0);

            _testDataStore.Remove(record);
            return await Task.FromResult(1);
        }

		public async Task<SkillsOneResponse> GetById(int id)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == id);
			return await Task.FromResult(record);
		}

		public async Task<IEnumerable<SkillsOneResponse>> GetPaginated(PaginationParameter paginationParameter)
		{
			var records = _testDataStore.Skip(paginationParameter.Skip).Take(paginationParameter.PageSize);
			return await Task.FromResult(records);
		}

		public async Task<int> Update(SkillsOneResponse skillsOneResponse)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == skillsOneResponse.Id);
            if (record == null) return await Task.FromResult(0);

            var index = _testDataStore.IndexOf(record);
            _testDataStore[index] = skillsOneResponse;
            return await Task.FromResult(1);
        }
	}
}