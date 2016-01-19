function solve(input) {
    input = input.replace(/'/g, "\"");
    var jsonArray = JSON.parse(input);
    for (var i = 0; i < jsonArray.length; i++) {
        jsonArray[i].score = parseFloat((jsonArray[i].score * 1.1).toFixed(1));
    }

    var studentsPassed = jsonArray.filter(function(x) {
        return x.score >= 100;
    });

    for (var i = 0; i < studentsPassed.length; i++) {
        studentsPassed[i].hasPassed = true;
    }

    studentsPassed = studentsPassed.sort(function(x, y) {
        return x.name > y.name;
    });

    var result = '[';
    for (var i = 0; i < studentsPassed.length; i++) {
        result += JSON.stringify(studentsPassed[i]);
        if(i < studentsPassed.length - 1) {
            result += ',';
        }
    }
    result += ']';
    console.log(result);
}

var input = "[\
{\
    'name' : 'Пешо',\
    'score' : 91\
},\
{\
    'name' : 'Лилия',\
    'score' : 290\
},\
{\
    'name' : 'Алекс',\
    'score' : 343\
},\
{\
    'name' : 'Габриела',\
    'score' : 400\
},\
{\
    'name' : 'Жичка',\
    'score' : 70\
}\
]";
solve(input);