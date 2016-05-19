var app = angular.module('myApp', []);
app.controller('PersonCtrl', function ($scope) {
    $scope.persons = [
        {
            "name": "Pesho",
            "photo": "http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png",
            "grade": 5,
            "school": "High School of Mathematics",
            "teacher": "Gichka Pesheva",
        },
        {
            "name": "Gosho",
            "photo": "http://pascalprecht.github.io/slides/angularjs-insights/img/angularjs-logo.png",
            "grade": 6,
            "school": "High School of Physics",
            "teacher": "Ganka Gosheva"
        }
    ]
});