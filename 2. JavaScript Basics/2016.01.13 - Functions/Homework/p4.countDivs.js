function countDivs(html) {
    var lengthStart = html.length;
    var noDivs = html.replace(/<div/g, '').replace(/div>/g, '');
    var lengthEnd = noDivs.length;
    return (lengthStart - lengthEnd) / 8;
}

var input = '\<!DOCTYPE html>\
    <html>\
    <head lang="en">\
    <meta charset="UTF-8">\
    <title>index</title>\
    <script src="/yourScript.js" defer></script>\
</head>\
<body>\
<div id="outerDiv">\
    <div\
class="first">\
    <div><div>hello</div></div>\
    </div>\
    <div>hi<div></div></div>\
    <div>I am a div</div>\
</div>\
</body>\
</html>';

console.log(countDivs(input));