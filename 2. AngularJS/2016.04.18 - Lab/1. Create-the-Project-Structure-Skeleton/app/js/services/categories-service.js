"use strict";

angular
    .module('app.services.categories', [])
    .factory('categoriesService', [
        '$resource',
        'baseServiceUrl',
        function categoriesService($resource, baseServiceUrl) {
            var categoriesResource = $resource(baseServiceUrl + '/api/categories');
            return {
                getCategories: function (success, error) {
                    return categoriesResource.query(success, error);
                }
            }
        }
    ]);