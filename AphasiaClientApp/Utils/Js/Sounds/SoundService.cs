using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace AphasiaClientApp.Utils.Js.Sounds
{
    public class SoundService : ISoundService
    {
        private IJSRuntime _js;
        private IJSUnmarshalledRuntime _jSUnmarshalledRuntime;
        private IJSInProcessRuntime _jSInProcessRuntime;

        public SoundService(IJSRuntime js, IJSUnmarshalledRuntime jSUnmarshalledRuntime,
            IJSInProcessRuntime jSInProcessRuntime)
        {
            _js = js;
            _jSUnmarshalledRuntime = jSUnmarshalledRuntime;
            _jSInProcessRuntime = jSInProcessRuntime;
        }

        public async Task<int> PlayAsync(string id) =>
            await _js.InvokeAsync<int>("PlaySound", id);

        public async Task<int> PlaySrcAsync(string src) =>
            await _js.InvokeAsync<int>("PlaySoundSrc", src);

        public int Play(string id) =>
            _jSInProcessRuntime.Invoke<int>("PlaySound", id);

        public int PlaySrc(string src) =>
            _jSInProcessRuntime.Invoke<int>("PlaySoundSrc", src);

        public async Task StopPlayAnyAudios() =>
            await _js.InvokeAsync<string>("StopPlaySounds");
    }
}
