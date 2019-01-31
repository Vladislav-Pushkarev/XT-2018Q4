var pause = document.getElementById('pause'),
    reset = document.getElementById('reset'),
    countdown = document.getElementById('countdown'),
    next = document.getElementById('next').href,
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
        location.href = next;
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