function clone(obj) {
    return JSON.parse(JSON.stringify(obj));
}

function compareObjects(obj, objCopy) {
    console.log('a == b --> ' + (obj == objCopy));
}

var a = {name: 'Pesho', age: 21}
var b = clone(a); // a deep copy
//var b = a; // not a deep copy
compareObjects(a, b);