function solve(arr) {
    var total = {};
    arr.forEach(function(line) {
        var data = line.split(' & ');
        var name = data[0]; // Array Matcher
        var type = data[1]; // strings
        var number = Number(data[2]);
        var score = Number(data[3]);
        var lines = Number(data[4]);

        var taskName = 'Task ' + number;
        if(total[taskName] === undefined) {
            total[taskName] = {
                tasks : [],
                average: 0,
                lines: 0
            }
        }

        total[taskName].tasks.push({
            name: name,
            type: type
        });

        total[taskName].tasks.sort(function(a, b) {
            return a.name > b.name;
        });

        total[taskName].average += score;
        total[taskName].lines += lines;
    });

    var totalTasks = 0;
    for (var property in total) {
        totalTasks++;
        if (total.hasOwnProperty(property)) {
            total[property].average = parseFloat((total[property].average / total[property].tasks.length).toFixed(2));
        }
    }

    var sorted = Object.keys(total).sort(function(a,b){
        if(total[a].average != total[b].average) {
            return total[a].average < total[b].average;
        } else {
            return total[a].lines > total[b].lines;
        }
    });

    var counter = 0;
    var output = '';
    sorted.forEach(function(x) {
        if(counter == 0) {
            output += '{';
        }

        output += '"' + x + '":';
        output += JSON.stringify(total[x]);
        if(counter == totalTasks - 1) {
            output += '}';
        }

        if(counter < totalTasks - 1) {
            output += ',';
        }

        counter++;
    });

    console.log(output);
}

var input = [
    'Array Matcher & strings & 4 & 100 & 38',
    'Magic Wand & draw & 3 & 100 & 15',
    'Dream Item & loops & 2 & 88 & 80',
    'Knight Path & bits & 5 & 100 & 65',
    'Basket Battle & conditionals & 2 & 100 & 120',
    'Torrent Pirate & calculations & 1 & 100 & 20',
    'Encrypted Matrix & nested loops & 4 & 90 & 52',
    'Game of bits & bits & 5 &  100 & 18',
    'Fit box in box & conditionals & 1 & 100 & 95',
    'Disk & draw & 3 & 90 & 15',
    'Poker Straight & nested loops & 4 & 40 & 57',
    'Friend Bits & bits & 5 & 100 & 81'];
solve(input);