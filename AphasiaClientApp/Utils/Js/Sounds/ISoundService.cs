using System.Threading.Tasks;

namespace AphasiaClientApp.Utils.Js.Sounds
{
    public interface ISoundService
    {
        Task<int> Play(string id);
        Task<int> PlaySrc(string src);
    }
}