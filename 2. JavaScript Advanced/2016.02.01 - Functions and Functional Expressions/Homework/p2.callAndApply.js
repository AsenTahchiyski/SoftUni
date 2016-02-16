function printArgsInfo() {
    for (var i = 0; i < arguments.length; i++) {
        var arg = arguments[i];
        if(Array.isArray(arg)) {
            console.log(arg + ' (array)')
        } else {
            console.log(arg + ' (' + typeof(arg) + ')')
        }
    }
}

printArgsInfo.call();
console.log('---');

printArgsInfo.call(0, 1, 2, 'three');
console.log('---');

printArgsInfo.apply();
console.log('---');

printArgsInfo.apply(0, [1, 2, 3, 'four', { number: 5}]);
console.log('---');