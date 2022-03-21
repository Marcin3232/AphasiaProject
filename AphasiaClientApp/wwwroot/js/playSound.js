﻿window.PlaySound = async function (sound) {
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
