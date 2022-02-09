using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AphasiaProject.Services.Dapper
{
    public interface IDbRepository
    {
        Task<int> ExecuteAsync(string query, object parameters, CommandType commandType = CommandType.Text);
        Task<T> ExecuteScalarAsync<T>(string query, object parameters, CommandType commandType = CommandType.Text);
        List<T> Get<T>(string query, object parameters, CommandType commandType = CommandType.Text);
    }
}