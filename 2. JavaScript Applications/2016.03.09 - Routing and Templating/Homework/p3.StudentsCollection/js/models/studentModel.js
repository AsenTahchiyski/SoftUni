var app = app || {};

app.StudentModel = (function () {
    function StudentModel() {
        this.serviceUrl = app.requester.baseUrl + 'appdata/' + app.requester.appId + '/students';
    }

    StudentModel.prototype.getAll = function () {
        var defer = Q.defer();
        app.requester.makeRequest('GET', this.serviceUrl, null, true).then(function (success) {
            var data = JSON.stringify(success);
            sessionStorage['getStudents'] = data;
            defer.resolve(data);
        }, function (error) {
            console.error(error);
            defer.reject(error);
        }).done();

        return defer.promise;
    };

    StudentModel.prototype.add = function(student) {
        var newStudent = {
            "gender": student.gender,
            "firstName":student.firstName,
            "lastName":student.lastName,
            "age":student.age,
            "country":student.country};
        app.requester.makeRequest('POST', this.serviceUrl, newStudent, true);
    };

    return StudentModel;
})();