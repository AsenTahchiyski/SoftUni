function solve(arr) {
    var banned = arr[arr.length - 1].split(' ');
    var usernameRegex = /#[a-z][a-z0-9_-]+[a-z0-9]/gi;
    var isCode = false;
    for (var i = 0; i < arr.length - 1; i++) {
        var line = arr[i];
        var codeStartIndex = line.indexOf("<code>");
        var codeEndIndex = line.indexOf("</code>");
        if (codeStartIndex >= 0) {
            isCode = true;
        }

        var match;
        while (match = usernameRegex.exec(line)) {
            var matchIndex = line.indexOf(match);
            var ban = isBanned(match, banned);
            if(!isCode && !ban ||
                (isCode && (codeStartIndex >= 0 && codeStartIndex > matchIndex) ||
                (codeEndIndex >= 0 && matchIndex > codeEndIndex))) {

                var nickname = String(match).replace('#', '');
                var replacement = '\<a href="/users/profile/show/' + nickname + '">' + nickname + '</a>';
                line = line.replace(match, replacement);
            }

            if(ban) {
                line = line.replace(match, buildString(match[0].length - 1, '*'));
            }
        }

        console.log(line);

        if (codeEndIndex >= 0 && isCode) {
            isCode = false;
        }
    }

    function isBanned(nick, banned) {
        var user = String(nick).replace('#', '');
        for (var i = 0; i < banned.length; i++) {
            if(banned[i] === user) {
                return true;
            }
        }

        return false;
    }

    function buildString(length, char) {
        var result = '';
        for (var i = 0; i < length; i++) {
            result += char;
        }

        return result;
    }
}

var input = [
    '#RoYaL: I\'m not sure what you mean,',
    'but I am confident that I\'ve written',
    'everything correctly. Ask #iordan_93',
    'and #pesho if you don\'t believe me',
    '<code>',
    '#trying to print stuff',
    'print("yoo")',
    '</code>',
    'pesho gosho'];
solve(input);