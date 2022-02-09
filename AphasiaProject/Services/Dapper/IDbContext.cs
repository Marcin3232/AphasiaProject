using System.Data;

namespace AphasiaProject.Services.Dapper
{
    public interface IDbContext
    {
        IDbConnection CreateConnection();
    }
}