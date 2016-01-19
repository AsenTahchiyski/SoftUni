var readline = require('readline');
var rl = readline.createInterface(process.stdin, process.stdout);
rl.setPrompt('Please, enter a speed value in km/h> ');
rl.prompt();
rl.on('line', function(line) {
    if (line === "end") {
        console.log("Thank you for testing my program!");
        rl.close();
    }
    var speedKmH = parseFloat(line)
    var speedKnots = speedKmH * 0.5399568034557235;
    console.log(speedKnots.toFixed(2));

    rl.prompt();
}).on('close',function(){
    process.exit(0);
});