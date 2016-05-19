'use strict';

angular
    .module('app.controllers-right-sidebar', [])
    .controller('RightSidebarController', [
        '$scope',
        'categoriesService',
        'townsService',
        '$rootScope',
        function ($scope, categoriesService, townsService, $rootScope) {
            $scope.categories = categoriesService.getCategories();
            $scope.towns = townsService.getTowns();

            $scope.categoryClicked = function (clickedCategoryId) {
                $scope.selectedCategoryId = clickedCategoryId;
            };
            $scope.townClicked = function (clickedTownId) {
                $scope.selectedTownId = clickedTownId;
            };

            $scope.categoryClicked = function (clickedCategoryId) {
                $scope.selectedCategoryId = clickedCategoryId;
                $rootScope.$broadcast("categorySelectionChanged", clickedCategoryId);
            };
            $scope.townClicked = function (clickedTownId) {
                $scope.selectedTownId = clickedTownId;
                $rootScope.$broadcast("townSelectionChanged", clickedTownId);
            };
        }]);