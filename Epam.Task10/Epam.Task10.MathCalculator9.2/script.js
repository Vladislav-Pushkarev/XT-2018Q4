function calculate(input) {
    'use strict';

    var nums = input.match(/[0-9.]+/g);
    var symbol = input.match(/[-+*/]/g);
    var result = nums[0];

    for (var i = 1, j = 0; i < nums.length; i++, j++) {
        result = calc(result, nums[i], symbol[j]);
    }

    return result.toFixed(2);;
}

function calc(a, b, symbol) {
    a = +a;
    b = +b;
    var result;

    switch (symbol) {
        case '-':
            {
                result = a - b;
                break;
            }
        case '+':
            {
                result = a + b;
                break;
            }
        case '/':
            {
                result = a / b;
                break;
            }
        case '*':
            {
                result = a * b;
                break;
            }
    }

    return result;
}

alert(calculate("3.5 +4*10-5.3 /5 ="));