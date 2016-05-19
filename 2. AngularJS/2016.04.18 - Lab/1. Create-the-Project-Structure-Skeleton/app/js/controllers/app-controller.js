"use strict";

angular
    .module('app.controllers.app', [])
    .controller('AppController', [
        '$scope',
        'authService',
        'notifyService',
        '$location',
        function AppController($scope, authService, notifyService, $location) {
            // Put the authService in the $scope to make it accessible from all screens
            $scope.authService = authService;
            // Implement the "logout" button click event handler
            $scope.logout = function () {
                authService.logout();
                // TODO: display "Logout successful" notification
                notifyService.showInfo('Logout successful');
                // TODO: redirect to the application home page };
                $location.path('/');
            }
        }]);