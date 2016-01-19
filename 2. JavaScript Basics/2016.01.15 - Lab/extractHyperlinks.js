function solve(arr) {
    var total = arr.join();
    var regex = /<a\s+.*?href\s*=\s*(['"]*)(.*?)\1/g;
    var match;
    var result = [];
    while(match = regex.exec(total)) {
        result.push(match[2]);
        console.log(match[2]);
    }

    result.forEach(function(m) {
        if(m.toString().charAt(0) == '\'' || m.toString().charAt(m.length - 1) == '"') {
            result.push(m.substring(1, m.length - 2));
        }
    });
    return result;
}

var input = ["<!DOCTYPE html>\
    <html>\
    <head>\
    <title>Hyperlinks</title>\
    <link href=\"theme.css\" rel=\"stylesheet\" />\
    </head>\
    <body>\
    <ul><li><a   href=\"/\"  id=\"home\">Home</a></li><li><a\
class=\"selected\" href=/courses>Courses</a>\
</li><li><a href =\
    '/forum' >Forum</a></li><li><a class=\"href\"\
onclick=\"go()\" href= \"#\">Forum</a></li>\
    <li><a id=\"js\" href =\
    \"javascript:alert('hi yo')\" class=\"new\">click</a></li>\
    <li><a id='nakov' href =\
    http://www.nakov.com class='new'>nak</a></li></ul>\
<a href=\"#empty\"></a>\
    <a id=\"href\">href='fake'<img src='http://abv.bg/i.gif'\
alt='abv'/></a><a href=\"#\">&lt;a href='hello'&gt;</a>\
    <!-- This code is commented:\
    <a href=\"#commented\">commentex hyperlink</a> -->\
</body>"];
solve(input);