function solve(str) {
    String.prototype.replaceAt=function(index, character) {
        return this.substr(0, index) + character + this.substr(index+character.length);
    };

    var result = str
        .replace("<a", "[URL")
        .replace("\</a>", "[/URL]");
    var pattern = /\.\w+(>)/g;
    var matches = pattern.exec(result);
    result = result.replaceAt(matches.index + matches[0].length - 1, ']');
    console.log(result);
}

var input =
    '\<ul>\
    <li>\
    <a href=http://softuni.bg>SoftUni</a>\
    </li>\
    </ul>';
solve(input);
