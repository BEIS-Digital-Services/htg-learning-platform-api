using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.Repositories
{
    public class SatisfactionSurveyEntryTestRepository : ISatisfactionSurveyEntryRepository
    {
        private readonly List<SatisfactionSurveyEntry> _testDataStore = new()
        {
            new SatisfactionSurveyEntry { Id = 1 },
            new SatisfactionSurveyEntry { Id = 2 },
            new SatisfactionSurveyEntry { Id = 3 },
            new SatisfactionSurveyEntry { Id = 4 }
        };

        public async Task<int?> Add(SatisfactionSurveyEntry satisfactionSurveyEntry)
        {
            var newId = _testDataStore.Max(x => x.Id) + 1;
            satisfactionSurveyEntry.Id = newId;
            _testDataStore.Add(satisfactionSurveyEntry);
            return await Task.FromResult((int?)newId);
        }

        public async Task<int> DeleteById(int id)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            if (record == null) return await Task.FromResult(0);

            _testDataStore.Remove(record);
            return await Task.FromResult(1);
        }

        public async Task<SatisfactionSurveyEntry> GetById(int id)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(record);
        }

        public async Task<IEnumerable<SatisfactionSurveyEntry>> GetPaginated(PaginationParameter paginationParameter)
        {
            var records = _testDataStore.Skip(paginationParameter.Skip).Take(paginationParameter.PageSize);
            return await Task.FromResult(records);
        }

        public async Task<int> Update(SatisfactionSurveyEntry satisfactionSurveyEntry)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == satisfactionSurveyEntry.Id);
            if (record == null) return await Task.FromResult(0);

            var index = _testDataStore.IndexOf(record);
            _testDataStore[index] = satisfactionSurveyEntry;
            return await Task.FromResult(1);
        }
    }
}