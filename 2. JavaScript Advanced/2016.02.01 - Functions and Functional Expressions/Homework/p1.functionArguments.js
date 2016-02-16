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

//printArgsInfo(2, 3, 2.5, -110.5564, false);

//printArgsInfo(null, undefined, "", 0, [], {});
// Note that [].toString() returns ""

//printArgsInfo([1, 2], ["string", "array"], ["single value"]);

//printArgsInfo("some string", [1, 2], ["string", "array"], ["mixed", 2, false, "array"], {name: "Peter", age: 20});

printArgsInfo([[1, [2, [3, [4, 5]]]], ["string", "array"]]);