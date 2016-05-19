"use strict";

angular
    .module('app.services.towns', [])
    .factory('townsService', [
        '$resource',
        'baseServiceUrl',
        function townsService($resource, baseServiceUrl) {
            var townsResource = $resource(baseServiceUrl + '/api/towns');
            return {
                getTowns: function (success, error) {
                    return townsResource.query(success, error);
                }
            }
        }
    ]);