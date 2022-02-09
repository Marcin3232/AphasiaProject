using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Dapper
{
    public class DbRepository : IDbRepository
    {
        private readonly IDbContext _context;

        public DbRepository(IDbContext context)
        {
            _context = context;
        }

        public async Task<T> ExecuteScalarAsync<T>(string query, Object parameters, CommandType commandType = CommandType.Text)
        {
            T result;
            using (IDbConnection connection = _context.CreateConnection())
            {
                OpenConnection(connection);

                using var transaction = connection.BeginTransaction();
                try
                {
                    result = await connection.ExecuteScalarAsync<T>(query, parameters, transaction: transaction, commandType: commandType);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            };
            return result;
        }

        public async Task<int> ExecuteAsync(string query, Object parameters, CommandType commandType = CommandType.Text)
        {
            var result = 0;
            using (IDbConnection connection = _context.CreateConnection())
            {
                OpenConnection(connection);

                using var transaction = connection.BeginTransaction();
                try
                {
                    result = await connection.ExecuteAsync(query, parameters, transaction: transaction, commandType: commandType);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            };
            return result;
        }

        public List<T> Get<T>(string query, object parameters, CommandType commandType = CommandType.Text)
        {
            IDbConnection connection = _context.CreateConnection();
            return connection.Query<T>(query, parameters, commandType: commandType).ToList();
        }

        private void OpenConnection(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
    }
}
