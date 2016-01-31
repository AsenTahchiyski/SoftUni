function solve(arr) {
    var avgCourseNames = arr[arr.length - 1].trim().split(/\s+/g);
    var avgCourseScores = [];
    for (var i = 0; i < avgCourseNames.length; i++) {
        avgCourseScores[i] = [];
    }

    for(var i = 0; i < arr.length - 1; i++)
    {
        var details = arr[i].trim().split(/\s+/g);
        var studentName = details[0];
        var courseName = details[1];
        var score = Number(details[2]);
        var bonus = Number(details[3]);
        if(score >= 0 && score < 100) {
            console.log(studentName + ' failed at "' + courseName + '"');
        } else if (score >= 100 && score <= 400) {
            var totalPoints = score / 5.0 + bonus;
            var grade = ((totalPoints / 80) * 4) + 2;
            console.log(studentName + ': Exam - "' + courseName + '"; Points - '
                + parseFloat((totalPoints).toFixed(2)) + '; Grade - ' + (grade >= 6.00 ? '6.00' : grade.toFixed(2)));
        }

        for (var j = 0; j < avgCourseNames.length; j++) {
            if(!avgCourseScores[j]) {
                avgCourseScores[j] = [];
            }

            if(avgCourseNames[j] === courseName) {
                avgCourseScores[j].push(score);
            }
        }
    }

    for (var i = 0; i < avgCourseNames.length; i++) {
        var average = getAverage(avgCourseScores[i]);
        console.log('"' + avgCourseNames[i] + '" average points -> ' + parseFloat(average.toFixed(2)));
    }

    function getAverage(scores) {
        var total = 0;
        for (var i = 0; i < scores.length; i++) {
            total += scores[i];
        }

        return total / scores.length;
    }
}

var input = [
    'Pesho C#-Advanced 100 3',
    'Gosho Java-Basics 157 3',
    'Tosho HTML&CSS 317 12',
    'Minka C#-Advanced 57 15',
    'Stanka C#-Advanced 157 15',
    'Kircho C#-Advanced 300 0',
    'Niki C#-Advanced 400 10',
    'C#-Advanced'];
solve(input);