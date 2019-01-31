function charRemover(input) {
    var words = splitString(input);
    var currentWord;
    var repeated = [];

    for (var i = 0; i < words.length; i++) {
        currentWord = words[i];

        var fR = findRepeated(currentWord);
        for (var j = 0; j < fR.length; j++) {
            repeated[repeated.length] = fR[j];
        }
    }

    repeated = unique(repeated);

    return getResult(input, repeated);
}

function getResult(input, repeated) {
    var result;
    for (var i = 0; i < input.length; i++) {
        var isRepeated = false;
        var isSplitter = false;

        for (var j = 0; j < splitters.length; j++) {
            if (input[i] === splitters[j]) {
                result = addLetter(result, input[i]);
                isSplitter = true;
                break;
            }
        }

        for (var k = 0; k < repeated.length; k++) {
            if (input[i] === repeated[k]) {
                isRepeated = true;
                break;
            }
        }

        if (!isRepeated && !isSplitter) {
            result = addLetter(result, input[i])
        }
    }

    return result;
}

function splitString(input) {
    var words = [];
    var isSplitter = false;
    var word;

    for (var i = 0; i < input.length; i++) {

        for (var j = 0; j < splitters.length; j++) {

            if (input[i] === splitters[j]) {
                isSplitter = true;
                break;
            }
        }
        if (!isSplitter) {
            word = addLetter(word, input[i])
            if (i === (input.length - 1)) {

                if (word != undefined) {
                    words[words.length] = word;
                    word = undefined;
                }
            }
        } else {

            if (word != undefined) {

                words[words.length] = word;
                word = undefined;
            }
        }
        isSplitter = false;
    }

    return words;
}

function addLetter(word, letter) {
    if (word === undefined) {
        word = letter;
    } else {
        word += letter;
    }

    return word;
}

function findRepeated(input) {
    var repeated = [];
    for (var i = 0; i < input.length; i++) {

        if (input.lastIndexOf(input[i]) != input.indexOf(input[i])) {
            repeated[repeated.length] = input[i];
        }
    }

    return repeated;
}

function unique(stringArray) {
    var obj = {};

    for (var i = 0; i < stringArray.length; i++) {
        var str = stringArray[i];
        obj[str] = true;
    }

    return Object.keys(obj);
}

var splitters = [' ', '  ', '?', '!', '.', ',', ':', ';'];
alert(charRemover("У попа была собака"));