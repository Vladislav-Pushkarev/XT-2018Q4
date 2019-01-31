var allAvailable = document.getElementById('allAvailable'),
    allSelected = document.getElementById('allSelected'),
    available = document.getElementById('available'),
    selected = document.getElementById('selected'),
    toAvailable = document.getElementById('toAvailable'),
    toSelected = document.getElementById('toSelected');

allSelected.onclick = function() {
    if (available.options.length === 0) {
        alert("The list is empty.");
        return;
    }
    while (available.options.length != 0) {
        selected.appendChild(available.options[0]);
    }
}

allAvailable.onclick = function() {
    if (selected.options.length === 0) {
        alert("The list is empty.");
        return;
    }
    while (selected.options.length != 0) {
        available.appendChild(selected.options[0]);
    }
}

toSelected.addEventListener('click', function() {
    if (available.selectedIndex === -1) {
        alert("Please select something, and then try again.");
        return;
    };
    while (available.selectedIndex > -1) {
        selected.appendChild(available.options[available.selectedIndex]);
        selected.options[selected.selectedIndex].selected = false;
    }
})


toAvailable.addEventListener('click', function() {
    if (selected.selectedIndex === -1) {
        alert("Please select something, and then try again.");
        return;
    };
    while (selected.selectedIndex > -1) {
        available.appendChild(selected.options[selected.selectedIndex]);
        available.options[available.selectedIndex].selected = false;
    }
})