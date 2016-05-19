"use strict";

angular
    .module('app.controllers.register', [])
    .controller('RegisterController', [
        '$scope',
        'categoriesService',
        'townsService',
        'notifyService',
        '$location',
        'authService',
        function RegisterController($scope, categoriesService, townsService, notifyService, $location, authService) {
            $scope.userData = {townId: null};
            $scope.towns = townsService.getTowns();
            $scope.register = function (userData) {
                authService.register(userData, function success() {
                    notifyService.showInfo('Registration successful');
                    $location.path('/login');
                }, function error(err) {
                    notifyService.showError("User registration failed", err);
                });
            };
        }
    ])
;