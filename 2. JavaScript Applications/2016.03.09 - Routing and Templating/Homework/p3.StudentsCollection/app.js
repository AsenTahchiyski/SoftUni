var app = app || {};
app.requester.config('kid_WJDMgxMaCx', '5791d61c584041a19a6ea1e78791ec94');

var users = new app.UserModel,
    students = new app.StudentModel;
users.login('pesho', '1234').then(function() {
    $.get('studentsTemplate.html', function (template) {
        students.getAll().then(function(success) {
            var allStudents = {
                header: 'Welcome to Мустак!',
                data: JSON.parse(success),
                empty: false
            };
            var output = Mustache.render(template, allStudents);
            $('#wrapper').html(output);
        });
    });
});

//var studentsList = [{"gender":"Male","firstName":"Joe","lastName":"Riley","age":22,"country":"Russia"},
//    {"gender":"Female","firstName":"Lois","lastName":"Morgan","age":41,"country":"Bulgaria"},
//    {"gender":"Male","firstName":"Roy","lastName":"Wood","age":33,"country":"Russia"},
//    {"gender":"Female","firstName":"Diana","lastName":"Freeman","age":40,"country":"Argentina"},
//    {"gender":"Female","firstName":"Bonnie","lastName":"Hunter","age":23,"country":"Bulgaria"},
//    {"gender":"Male","firstName":"Joe","lastName":"Young","age":16,"country":"Bulgaria"},
//    {"gender":"Female","firstName":"Kathryn","lastName":"Murray","age":22,"country":"Indonesia"},
//    {"gender":"Male","firstName":"Dennis","lastName":"Woods","age":37,"country":"Bulgaria"},
//    {"gender":"Male","firstName":"Billy","lastName":"Patterson","age":24,"country":"Bulgaria"},
//    {"gender":"Male","firstName":"Willie","lastName":"Gray","age":42,"country":"China"},
//    {"gender":"Male","firstName":"Justin","lastName":"Lawson","age":38,"country":"Bulgaria"},
//    {"gender":"Male","firstName":"Ryan","lastName":"Foster","age":24,"country":"Indonesia"},
//    {"gender":"Male","firstName":"Eugene","lastName":"Morris","age":37,"country":"Bulgaria"},
//    {"gender":"Male","firstName":"Eugene","lastName":"Rivera","age":45,"country":"Philippines"},
//    {"gender":"Female","firstName":"Kathleen","lastName":"Hunter","age":28,"country":"Bulgaria"}];
//studentsList.forEach(function(s) {
//    students.add(s);
//});

