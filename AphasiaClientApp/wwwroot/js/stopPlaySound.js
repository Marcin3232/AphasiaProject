window.StopPlaySounds = function () {
    try {
        var sounds = document.getElementsByTagName('audio');
        for (i = 0; i < sounds.length; i++) sound[i].pause();
    }
    catch (error) {
        console.warn(error);
    }
}