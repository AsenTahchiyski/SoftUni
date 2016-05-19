"use strict";

angular
    .module('app.controllers.login', [])
    .controller('LoginController', [
        '$scope',
        '$location',
        'authService',
        'notifyService',
        function LoginController($scope, $location, authService, notifyService) {
            $scope.login = function (userData) {
                authService.login(userData,
                    function success() {
                        notifyService.showInfo("Login successful");
                        $location.path("/");
                    },
                    function error(err) {
                        notifyService.showError('Login unsuccessful', err);
                    }
                );
            };
        }
    ]);