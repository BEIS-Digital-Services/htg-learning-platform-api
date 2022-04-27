using Beis.LearningPlatform.Dal.Interfaces;
using Beis.LearningPlatform.Model;
using Beis.LearningPlatform.Model.RequestParameters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beis.LearningPlatform.Api.Tests.Repositories
{
    public class DiagnosticToolEmailAnswerTestRepository : IDiagnosticToolEmailAnswerRepository
    {
        private readonly List<DiagnosticToolEmailAnswer> _detailedTestDataStore = new()
        {
            new DiagnosticToolEmailAnswer { Id = 1, UserEmailAddress = "mailme_1@mailememore.com" },
            new DiagnosticToolEmailAnswer { Id = 2, UserEmailAddress = "mailme_2@mailememore.com" },
            new DiagnosticToolEmailAnswer { Id = 3, UserEmailAddress = "mailme_3@mailememore.com" },
            new DiagnosticToolEmailAnswer { Id = 4, UserEmailAddress = "mailme_4@mailememore.com" }
        };

        private readonly List<DiagnosticToolEmailAnswer> _testDataStore = new()
        {
            new DiagnosticToolEmailAnswer { Id = 1 },
            new DiagnosticToolEmailAnswer { Id = 2 },
            new DiagnosticToolEmailAnswer { Id = 3 },
            new DiagnosticToolEmailAnswer { Id = 4 }
        };

        public async Task<int?> Add(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer)
        {
            var newId = _testDataStore.Max(x => x.Id) + 1;
            diagnosticToolEmailAnswer.Id = newId;
            _testDataStore.Add(diagnosticToolEmailAnswer);
            return await Task.FromResult((int?)newId);
        }

        public async Task<int> DeleteById(int id)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            if (record == null) return await Task.FromResult(0);

            _testDataStore.Remove(record);
            return await Task.FromResult(1);
        }

        public async Task<DiagnosticToolEmailAnswer> GetById(int id)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(record);
        }

        public async Task<IEnumerable<DiagnosticToolEmailAnswer>> GetByUserEmailAddress(string userEmailAddress)
        {
            var records = _detailedTestDataStore.Where(x => x.UserEmailAddress == userEmailAddress);
            return await Task.FromResult(records);
        }

        public async Task<IEnumerable<DiagnosticToolEmailAnswer>> GetPaginated(PaginationParameter paginationParameter)
        {
            var records = _testDataStore.Skip(paginationParameter.Skip).Take(paginationParameter.PageSize);
            return await Task.FromResult(records);
        }

        public async Task<int> Update(DiagnosticToolEmailAnswer diagnosticToolEmailAnswer)
        {
            var record = _testDataStore.FirstOrDefault(x => x.Id == diagnosticToolEmailAnswer.Id);
            if (record == null) return await Task.FromResult(0);

            var index = _testDataStore.IndexOf(record);
            _testDataStore[index] = diagnosticToolEmailAnswer;
            return await Task.FromResult(1);
        }
    }
}