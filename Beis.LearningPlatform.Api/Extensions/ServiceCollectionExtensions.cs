using Beis.LearningPlatform.Dal;
using Beis.LearningPlatform.Dal.DataContext;
using Beis.LearningPlatform.Dal.Interfaces;

namespace Beis.LearningPlatform.Api.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        internal static void RegisterAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDapperContext>(c => new NpgSqlDapperContext(configuration["DatabaseConfig:LearningPlatformDbConnectionString"]));
            services.AddScoped<IDiagnosticToolEmailAnswerRepository, DiagnosticToolEmailAnswerRepository>();
            services.AddScoped<IFeedbackPageUsefulRepository, FeedbackPageUsefulRepository>();
            services.AddScoped<IFeedbackProblemReportRepository, FeedbackProblemReportRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ISatisfactionSurveyEntryRepository, SatisfactionSurveyEntryRepository>();
            services.AddScoped<ISkillsOneResponseRepository, SkillsOneResponseRepository>();
        }
    }
}