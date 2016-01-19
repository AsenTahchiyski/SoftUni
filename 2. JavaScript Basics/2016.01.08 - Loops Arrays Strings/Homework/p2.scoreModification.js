function solve(arr) {
    var validScores = arr.filter(function(x) {
        return x <= 400 && x >= 0;
    });
    validScores = validScores.map(function(x) {
        return +(x * 0.8).toFixed(1);
    });
    validScores.sort(function(x, y) {
        return x >= y;
    });
    console.log('[ ' + validScores.join(', ') + ' ]')
}

var arr = [200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1];
solve(arr);