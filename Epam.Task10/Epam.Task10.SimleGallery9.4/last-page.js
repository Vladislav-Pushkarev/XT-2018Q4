var pause = document.getElementById('pause'),
    reset = document.getElementById('reset'),
    countdown = document.getElementById('countdown'),
    startTime = 4,
    time = startTime - 1,
    stop = false;

countdown.innerText = startTime;

function timer() {
    if (stop) {
        return;
    }
    countdown.innerText = time;
    time--;
    if (time < 0) {
        var isRepeat = confirm("Repeat one more time?");

        if (isRepeat) {
            location.href = "index.html";
        } else {
            open(location, '_self').close();
            stop = true;
            return;
        }

        return;
    }
    setTimeout(timer, 1000);
}

setTimeout(timer, 1000);


reset.onclick = function() {
    time = startTime;
    countdown.innerText = time;
}

pause.onclick = function() {
    stop = !stop;
    if (!stop) {
        setTimeout(timer, 1000);
    }
}