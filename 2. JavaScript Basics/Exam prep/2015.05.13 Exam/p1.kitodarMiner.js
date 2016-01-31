function solve(arr) {
    var pattern = /mine\s+([\w:\d]*)*\s*-\s+(\w+)\s*:\s*(\d+)/i;
    var totalSilver = 0, totalGold = 0, totalDiamonds = 0;
    arr.forEach(function(line) {
        var match;
        if(match = pattern.exec(line)) {
            var qty = match.length == 4 ? match[3] : match[2];
            switch(match[2].toLowerCase()) {
                case 'silver': totalSilver += parseInt(qty); break;
                case 'gold': totalGold += parseInt(qty); break;
                case 'diamonds': totalDiamonds += parseInt(qty); break;
                default: break;
            }
        }
    });

    console.log('*Silver: ' + totalSilver);
    console.log('*Gold: ' + totalGold);
    console.log('*Diamonds: ' + totalDiamonds);
}

//var input = [
//    'mine bobovDol - gold: 10"',
//    'mine medenRudnik - silver: 22"',
//    'mine chernoMore - shrimps : 24"',
//    'gold: 50'];
//
var input = [
    'mine bobovdol - gold: 10',
    'mine - diamonds: 5',
    'mine colas - wood: 10',
    'mine myMine - silver:  14',
    'mine silver:14 - silver: 14'];

solve(input);