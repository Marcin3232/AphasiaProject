using System.Net.Http;
using System.Threading.Tasks;

namespace AphasiaClientApp.Extensions.RequestMethod
{
    public interface IRequestMethod
    {
        Task<T> Get<T>(string path, HttpClient httpClient);
        Task<TResult> Post<T, TResult>(string path, HttpClient httpClient, T data);
    }
}
