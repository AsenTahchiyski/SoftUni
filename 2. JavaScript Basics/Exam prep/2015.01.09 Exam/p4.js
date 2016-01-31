function solve(arr) {
    var regex = /([A-Z][a-z]+\s?[A-Z]?[a-z]+?\s?[A-Z]?[a-z]+?)\.*\*\.*([a-z]+)\.*\*\.*(true|false)\.*\*\.*(true|false)\.*\*\.*(true|false)\.*\*\.*(\d\.?[\d+?]?)\.*\*\.*([a-zA-Z]+)/g;
    var finalList = {};

    function getType(isFood, isDrink) {
        if (isFood) {
            return "food";
        } else if (isDrink) {
            return "drink"
        } else {
            return "other";
        }
    }

    function Luggage(kg, fragile, type, transferredWith) {
        this.kg = kg;
        this.fragile = fragile;
        this.type = type;
        this.transferredWith = transferredWith;
    }

    arr.forEach(function (line) {
        var matches;
        while (matches = regex.exec(line)) {
            var owner = matches[1];
            var name = matches[2];
            var isFood = matches[3] == 'true';
            var isDrink = matches[4] == 'true';
            var isFragile = matches[5] == 'true';
            var weight = Number(matches[6]);
            var carrier = matches[7];

            if(weight <= 100) {
                if (!finalList[owner]) {
                    finalList[owner] = {};
                }

                if (!finalList[owner][name]) {
                    finalList[owner][name] = [];
                }

                var luggage = new Luggage(weight, isFragile, getType(isFood, isDrink), carrier);
                finalList[owner][name].push(luggage);
            }
        }
    });

    var sortCriteria = arr[arr.length - 1];
    switch (sortCriteria) {
        case 'luggage name':
            var outputNameSort = {};
            Object.keys(finalList).forEach(function (key) {
                outputNameSort[key] = {};
                var sortedInnerKeys = Object.keys(finalList[key]).sort();
                sortedInnerKeys.forEach(function (innerkey) {
                    outputNameSort[key][innerkey] = finalList[key][innerkey];
                });
            });
            console.log(JSON.stringify(outputNameSort).replace(/[\[\]]/g, ''));
            break;
        case 'weight':
            var outputKgSort = {};
            Object.keys(finalList).forEach(function(key) {
                outputKgSort[key]={};
                var a = Object.keys(finalList[key]).sort(function (a,b) {
                    return finalList[key][a].kg - finalList[key][b].kg;
                });
                a.forEach(function (value) {
                    outputKgSort[key][value] = finalList[key][value];
                });
            });
            console.log(JSON.stringify(outputKgSort).replace(/[\[\]]/g, ''));
            break;
        case 'strict':
            console.log(JSON.stringify(finalList).replace(/[\[\]]/g, ''));
            break;
        default:
            break;
    }
}

var input = [
    'Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
    'weight'
];

solve(input);