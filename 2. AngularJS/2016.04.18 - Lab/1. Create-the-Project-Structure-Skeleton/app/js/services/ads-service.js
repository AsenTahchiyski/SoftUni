"use strict";

angular
    .module('app.services.ads', [])
    .factory('adsService', [
        '$resource',
        'baseServiceUrl',
        function adsService($resource, baseServiceUrl) {
            function getAds(params, success, error) {
                var adsResource = $resource(
                    baseServiceUrl + '/api/ads',
                    null,
                    {
                        'getAll': {
                            method: 'GET'
                        }
                    });
                return adsResource.getAll(params, success, error);
            }

            function adsPaginated(pageSize, startPage) {
                var adsPage = $resource(
                    baseServiceUrl + '/api/ads',
                    {
                        pageSize: pageSize,
                        startPage: startPage
                    },
                    {
                        'adsPage': {
                            method: 'GET'
                        }
                    }
                );

            }

            return {
                getAds: getAds,
                adsPaginated: adsPaginated
            }
        }
    ]);