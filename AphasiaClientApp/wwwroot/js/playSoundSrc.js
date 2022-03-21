window.PlaySoundSrc = async function (src) {
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

