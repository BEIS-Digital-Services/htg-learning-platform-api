using Beis.LearningPlatform.Dal.Interfaces;
using Dapper;
using Npgsql;
using System.Data;

namespace Beis.LearningPlatform.Dal.DataContext
{
    public class NpgSqlDapperContext : IDapperContext
	{
		private readonly string _connectionString;

		static NpgSqlDapperContext() { 
			SimpleCRUD.SetDialect(SimpleCRUD.Dialect.PostgreSQL);
		}

		public NpgSqlDapperContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public IDbConnection CreateConnection()
		{
			return new NpgsqlConnection(_connectionString);
		}
    }
}