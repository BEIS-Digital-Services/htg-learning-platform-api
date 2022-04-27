using System.Data;

namespace Beis.LearningPlatform.Dal.Interfaces
{
    public interface IDapperContext
	{
		IDbConnection CreateConnection();
	}
}