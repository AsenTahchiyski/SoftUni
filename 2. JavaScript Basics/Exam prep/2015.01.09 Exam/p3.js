function solve(arr) {
    var total = '';
    var regex = /<p>([\w\W]+?)<\/p>/g;
    var part;
    var result = '';
    while (part = regex.exec(arr[0])) {
        total += part[1];
    }

    for (var i = 0; i < total.length; i++) {
        var char = total.charAt(i);
        result += transformLetter(char);
    }

    result = result.replace(/\s+/g, ' ');

    function transformLetter(char) {
        var codeBefore = char.charCodeAt(0);
        if (codeBefore > 96 && codeBefore < 110) {
            return String.fromCharCode(codeBefore + 13);
        } else if (codeBefore > 109 && codeBefore < 123) {
            return String.fromCharCode(codeBefore - 13);
        } else if (codeBefore > 47 && codeBefore < 58) {
            return char;
        } else {
            return ' ';
        }

    }

    console.log(result);
}

//var input = ["\<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>"];

var input = ["\<html><head><title></title></head><body><h1>Intro</h1><ul><li>Item01</li><li>Item02</li><li>Item03</li></ul><p>jura qevivat va jrg fyvccrel fabjl</p><div><button>Click me, baby!</button></div><p> pbaqvgvbaf fabj  qpunvaf ner nofbyhgryl rffragvny sbe fnsr unaqyvat nygubhtu fabj punvaf znl ybbx </p><span>This manual is false, do not trust it! The illuminati wrote it down to trick you!</span><p>vagvzvqngvat gur onfvp vqrn vf ernyyl fvzcyr svg gurz bire lbhe gverf qevir sbejneq fybjyl naq gvtugra gurz hc va pbyq jrg</p><p> pbaqvgvbaf guvf vf rnfvre fnvq guna qbar ohg vs lbh chg ba lbhe gverf</p></body>"];
solve(input);