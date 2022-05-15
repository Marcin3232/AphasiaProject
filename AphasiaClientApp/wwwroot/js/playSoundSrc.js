window.PlaySoundSrc = async function (src) {
    try {
        var sounds = document.getElementsByTagName('audio');
        if (sounds.length>0)
            for (i = 0; i < sounds.length; i++) sound[i].pause();
    }
    catch (error) {
    }
    var audio = new Audio(src);
    audio.type = 'audio/mp3';
    try {
        await audio.play();
        var time = parseInt(audio.duration * 1000);
        return time;
    }
    catch (error) {
        console.warn(error);
        return 0;
    }
};

