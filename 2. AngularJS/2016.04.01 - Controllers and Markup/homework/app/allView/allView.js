'use strict';

angular.module('myApp.allView', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/all', {
            templateUrl: 'app/allView/allView.html',
            controller: 'AllViewCtrl'
        });
    }])

    .controller('AllViewCtrl', ['$scope', 'videos',
        function AllViewCtrl($scope, videos) {
            $scope.videos = videos.getVideos();
        }]);