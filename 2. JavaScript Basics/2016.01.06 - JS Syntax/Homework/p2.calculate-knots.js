function calcKnots(speedKmh) {
    var ratio = 1.852;
    var speedKnots = speedKmh / ratio;
    console.log(speedKnots.toFixed(2));
}

var input = [20, 112, 400];
input.forEach(function (num) {
    calcKnots(num);
});