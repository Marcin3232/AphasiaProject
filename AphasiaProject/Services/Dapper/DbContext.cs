using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace AphasiaProject.Services.Dapper
{
    public class DbContext : IDbContext
    {
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection() =>
            new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}
