"use strict";

angular
    .module('app.controllers.home', [])
    .controller('HomeController', [
        '$scope',
        '$rootScope',
        'adsService',
        'notifyService',
        'pageSize',
        function HomeController($scope, $rootScope, adsService, notifyService, pageSize) {
            adsService.getAds(
                null,
                function success(data) {
                    // TODO: put the ads in the scope
                    $scope.ads = data;
                },
                function error(err) {
                    notifyService.showError("Cannot load ads", err);
                });

            $scope.adsParams = {
                'startPage': 1,
                'pageSize': pageSize
            };

            $scope.reloadAds = function () {
                adsService.getAds(
                    $scope.adsParams,
                    function success(data) {
                        $scope.ads = data;
                    },
                    function error(err) {
                        notifyService.showError('Cannot load ads', err);
                    }
                );
            };
            $scope.reloadAds();

            // This event is sent by RightSideBarController when the current category is changed
            $scope.$on("categorySelectionChanged", function (event, selectedCategoryId) {
                $scope.adsParams.categoryId = selectedCategoryId;
                $scope.adsParams.startPage = 1;
                $scope.reloadAds();
            });
            // TODO: implement similar logic for filtering by category
            $scope.$on("townSelectionChanged", function (event, selectedTownId) {
                $scope.adsParams.townId = selectedTownId;
                $scope.adsParams.startPage = 1;
                $scope.reloadAds();
            });
        }
    ]);