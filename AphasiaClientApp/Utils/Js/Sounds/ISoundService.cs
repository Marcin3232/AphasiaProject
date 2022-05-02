using System.Threading.Tasks;

namespace AphasiaClientApp.Utils.Js.Sounds
{
    public interface ISoundService
    {
        Task<int> PlayAsync(string id);
        Task<int> PlaySrcAsync(string src);
        int Play(string id);
        int PlaySrc(string src);
        Task StopPlayAnyAudios();
    }
}