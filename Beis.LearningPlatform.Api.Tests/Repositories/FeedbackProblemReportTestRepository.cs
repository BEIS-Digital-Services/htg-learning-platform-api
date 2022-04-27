using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.Repositories
{
    public class FeedbackProblemReportTestRepository : IFeedbackProblemReportRepository
	{
        private readonly List<FeedbackProblemReport> _testDataStore = new()
        {
            new FeedbackProblemReport { Id = 1 },
            new FeedbackProblemReport { Id = 2 },
            new FeedbackProblemReport { Id = 3 },
            new FeedbackProblemReport { Id = 4 }
        };

		public async Task<int?> Add(FeedbackProblemReport feedbackProblemReport)
		{
			var newId = _testDataStore.Max(x => x.Id) + 1;
			feedbackProblemReport.Id = newId;
			_testDataStore.Add(feedbackProblemReport);
			return await Task.FromResult((int?)newId);
		}

		public async Task<int> DeleteById(int id)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            if (record == null) return await Task.FromResult(0);

            _testDataStore.Remove(record);
            return await Task.FromResult(1);
        }

		public async Task<FeedbackProblemReport> GetById(int id)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == id);
			return await Task.FromResult(record);
		}

		public async Task<IEnumerable<FeedbackProblemReport>> GetPaginated(PaginationParameter paginationParameter)
		{
			var records = _testDataStore.Skip(paginationParameter.Skip).Take(paginationParameter.PageSize);
			return await Task.FromResult(records);
		}

		public async Task<int> Update(FeedbackProblemReport feedbackProblemReport)
		{
			var record = _testDataStore.FirstOrDefault(x => x.Id == feedbackProblemReport.Id);
            if (record == null) return await Task.FromResult(0);

            var index = _testDataStore.IndexOf(record);
            _testDataStore[index] = feedbackProblemReport;
            return await Task.FromResult(1);
        }
    }
}