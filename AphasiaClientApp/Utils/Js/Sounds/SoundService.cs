using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Utils.Js.Sounds
{
    public class SoundService : ISoundService
    {
        public IJSRuntime _js;

        public SoundService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task<int> Play(string id) =>
            await _js.InvokeAsync<int>("PlaySound", id);

        public async Task<int> PlaySrc(string src) =>
            await _js.InvokeAsync<int>("PlaySoundSrc", src);
    }
}
