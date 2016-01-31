function solve(arr) {
    var inputWords = arr[0].split(/\W/);
    var wordsDictionary = {};
    inputWords.forEach(function(w) {
        if(w != undefined && w.length > 0) {
            if(wordsDictionary[w.toLowerCase()] == undefined) {
                wordsDictionary[w.toLowerCase()] = 0;
            }

            wordsDictionary[w.toLowerCase()] += 1;
        }
    });

    var wordsToSearch = [];
    Object.keys(wordsDictionary).forEach(function(key) {
        if(wordsDictionary[key] >= 3) {
            wordsToSearch.push(key);
        }
    });

    if(wordsToSearch.length < 2) {
        console.log('No words');
        return;
    }

    var sentences = arr[1].match(/[A-Z][\w\s:]*[.?!]/g);

    var noResult = true;
    sentences.forEach(function(s) {
        var wordCounter = 0;
        wordsToSearch.forEach(function(w) {
            var regex = new RegExp('\b' + w + '\b');
            if(regex.test(s)) {
                wordCounter += 1;
            }
        });

        if(wordCounter >= 2) {
            console.log(s);
            noResult = false;
        }
    });

    if(noResult) {
        console.log('No sentences');
    }
}

//var input = ["Captain Obvious was walking down the street. As the captain was walking a person came and told him: You are Captain Obvious! He replied: Thank you CAPTAIN OBVIOUS you are the man!",
//    "The captain was walking and he was obvious. He did not know what was going to happen to you in the future. Was he curious? We do not know."];
var input = ['Bogi prasna kat jivotno izpita po JS. Zareji che malko govorq po shlokavica, ti pak trebva da pretyrsi taq text po nekva raota deto beshe v uslovieto i sega se chudish kaf e adjeba taq test i koi idiot e pisal taq shlokavica. Da znaite taq shlokavica po KPK ne se priema.',
    'Da si znaesh vhe ot taq shlokavica trebva da zemesh tova izrehenie no ima i tretata duma po! Mai mai tova e nai typiq text. Trqbva da machnete i tva izrechenie zashtoto sydyrja po i shlokavica.'];

solve(input);