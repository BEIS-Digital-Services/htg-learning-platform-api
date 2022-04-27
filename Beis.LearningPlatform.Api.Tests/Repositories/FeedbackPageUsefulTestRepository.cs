using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.Repositories
{
    public class FeedbackPageUsefulTestRepository : IFeedbackPageUsefulRepository
    {
        private readonly List<FeedbackPageUseful> _testDataStore = new()
        {
            new FeedbackPageUseful { Id = 1 },
            new FeedbackPageUseful { Id = 2 },
            new FeedbackPageUseful { Id = 3 },
            new FeedbackPageUseful { Id = 4 }
        };

        public async Task<int?> Add(FeedbackPageUseful feedbackPageUseful)
        {
            var newId = _testDataStore.Max(x => x.Id) + 1;
            feedbackPageUseful.Id = newId;
            _testDataStore.Add(feedbackPageUseful);
            return await Task.FromResult((int?)newId);
        }

        public async Task<int> DeleteById(int id)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            if (record == null) return await Task.FromResult(0);

            _testDataStore.Remove(record);
            return await Task.FromResult(1);
        }

        public async Task<FeedbackPageUseful> GetById(int id)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(record);
        }

        public async Task<IEnumerable<FeedbackPageUseful>> GetPaginated(PaginationParameter paginationParameter)
        {
            var records = _testDataStore.Skip(paginationParameter.Skip).Take(paginationParameter.PageSize);
            return await Task.FromResult(records);
        }

        public async Task<int> Update(FeedbackPageUseful feedbackPageUseful)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == feedbackPageUseful.Id);
            if (record == null) return await Task.FromResult(0);

            var index = _testDataStore.IndexOf(record);
            _testDataStore[index] = feedbackPageUseful;
            return await Task.FromResult(1);
        }
    }
}