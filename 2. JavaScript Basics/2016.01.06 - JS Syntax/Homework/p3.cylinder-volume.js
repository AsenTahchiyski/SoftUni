function calcCylinderVol(arr) {
    var radius = arr[0];
    var height = arr[1];
    var volume = Math.PI * radius * radius * height;
    console.log(volume.toFixed(3));
}

var input = [[2, 4], [5, 8], [12, 3]];
input.forEach(function (arr) {
    calcCylinderVol(arr);
})