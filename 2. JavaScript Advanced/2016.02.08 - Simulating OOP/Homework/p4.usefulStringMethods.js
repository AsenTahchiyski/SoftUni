String.prototype.startsWith = function(substring) {
    var index = this.indexOf(substring);
    return index == 0;
};
String.prototype.endsWith = function(substring) {
    var index = this.indexOf(substring);
    return index == this.length - substring.length;
};
String.prototype.left = function(count) {
    if(count > this.length) {
        return this.toString();
    } else {
        return this.substr(0, count);
    }
};
String.prototype.right = function(count) {
    if(count > this.length) {
        return this.toString();
    } else {
        return this.substr(this.length - count, count);
    }
};
String.prototype.padLeft = function(count, char) {
    var addition = Array(count + 1).join(char || ' ');
    return addition + this.toString();
};
String.prototype.padRight = function(count, char) {
    var addition = Array(count + 1).join(char || ' ');
    return this.toString() + addition;
};
String.prototype.repeat = function(count) {
    return Array(count + 1).join(this.toString());
};

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.startsWith("This"));
//console.log(example.startsWith("this"));
//console.log(example.startsWith("other"));

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.endsWith("poses."));
//console.log(example.endsWith ("example"));
//console.log(example.startsWith("something else"));

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.left(9));
//console.log(example.left(90));

//var example = "This is an example string used only for demonstration purposes.";
//console.log(example.right(9));
//console.log(example.right(90));

////Combinations must also work
//var example = "abcdefgh";
//console.log(example.left(5).right(2));

//var hello = "hello";
//console.log(hello.padLeft(5));
//console.log(hello.padLeft(10));
//console.log(hello.padLeft(5, "."));
//console.log(hello.padLeft(10, "."));
//console.log(hello.padLeft(2, "."));

//var hello = "hello";
//console.log(hello.padRight(5));
//console.log(hello.padRight(10));
//console.log(hello.padRight(5, "."));
//console.log(hello.padRight(10, "."));
//console.log(hello.padRight(2, "."));

//var character = "*";
//console.log(character.repeat(5));
//// Alternative syntax
//console.log("~".repeat(3));

// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));