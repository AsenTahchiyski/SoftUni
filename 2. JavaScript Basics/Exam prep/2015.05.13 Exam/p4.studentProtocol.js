function solve(arr) {
    function Course(name) {
        this.name = name;
        this.students = [];
    }

    function Student(name, score) {
        this.name = name;
        this.score = score;
    }

    var result = [];
    arr.forEach(function(e) {
        e.replace(/\s+/, ' ');
        var params = e.split('-');
        var name = params[0].trim();
        var course = params[1].split(':');
        var courseName = course[0].trim();
        var courseScore = Number(course[1].trim);

        var course = new Course(courseName);
        var student = new Student(name, courseScore);

        if(result[course] == undefined) {
            result[course] = [];
        }

        if(result[course][student] == undefined) {
            result[course][student] = [];
        }

        result[course][name].push(courseScore);
    });

    console.log(result);
}

var input = ['Peter Jackson - Java : 350',
'Jane - JavaScript : 200',
'Jane     -    JavaScript :     400',
'Simon Cowell - PHP : 100',
'Simon Cowell-PHP: 500',
'Simon Cowell - PHP : 200'];
solve(input);