function solve(arr) {
    for (var i = 0; i < arr.length; i++) {
        arr[i] = +arr[i];
        if(isNaN(arr[i])) {
            arr.splice(i, 1);
        }
    }

    var frequency = [];
    for (var i = 0; i < arr.length; i++) { // after the first iteration the object with numerical value is still present in the array
        arr[i] = +arr[i];
        if(isNaN(arr[i])) {
            arr.splice(i, 1);
        }
    }

    arr.sort(function(x, y) {
        return x <= y;
    });

    var mostFrequent;
    var freqCounter = 0;
    for (var i = 0; i < arr.length; i++) {
        if(isNaN(frequency[arr[i]])) {
            frequency[arr[i]] = 0;
        }

        frequency[arr[i]]++;
        if(frequency[arr[i]] > freqCounter) {
            freqCounter = frequency[arr[i]];
            mostFrequent = arr[i];
        }
    }

    var min = arr[arr.length - 1];
    var max = arr[0];
    console.log('Min number: ' + min);
    console.log('Max number: ' + max);
    console.log('Most frequent number: ' + mostFrequent);
    console.log('[' + arr.join(', ') + ']');
}

var arr = ["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0,
        "Penka", { bunniesCount : 10}, [10, 20, 30, 40]];
solve(arr);