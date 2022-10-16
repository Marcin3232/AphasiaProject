window.PlaySound = async function (sound) {
    try {
        var sounds = document.getElementsByTagName('audio');
        if (sounds.length > 0)
            for (i = 0; i < sounds.length; i++) sound[i].pause();
    }
    catch (error) {
    }
    try {
        var audio = document.getElementById(sound);
        await audio.play();
        var time = parseInt(audio.duration * 1000);
        return time;
    }
    catch (error) {
        console.warn(error);
        return 0;
    }
};
