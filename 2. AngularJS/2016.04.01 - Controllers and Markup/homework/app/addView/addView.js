'use strict';

angular.module('myApp.addView', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/add', {
            templateUrl: 'app/addView/addView.html',
            controller: 'AddViewCtrl'
        });
    }])

    .controller('AddViewCtrl', ['$scope', 'videos', '$window',
        function AddViewCtrl($scope, videos, $window) {
            $scope.insertVideo = function addVideo() {
                var video = {
                    title: $scope.title,
                    picture: $scope.picUrl,
                    length: $scope.length || 0,
                    category: $scope.category,
                    likes: 0,
                    date: $scope.date || new Date().getFullYear(),
                    hasSubs: $scope.hasSubs ? 'yes' : 'no',
                    comments: []
                };

                videos.addVideo(video);
                $window.location.href = '#/all';
            };
        }]);