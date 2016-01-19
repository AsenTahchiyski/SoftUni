function extractObjects(array) {
    var output = [];
    array.forEach(function(e) {
        if(typeof(e) === 'object' && !Array.isArray(e)) {
            output.push(e);
        }
    });
    return output;
}

var input = [
        "Pesho",
        4,
        4.21,
        { name : 'Valyo', age : 16 },
        { type : 'fish', model : 'zlatna ribka' },
        [1,2,3],
        "Gosho",
        { name : 'Penka', height: 1.65}
    ];
console.log(extractObjects(input));