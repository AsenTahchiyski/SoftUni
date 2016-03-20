var app = app || {};

app.ajaxRequester = (function() {
    function Requester(appId, appSecret) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = 'https://baas.kinvey.com/';
    }

    Requester.prototype.makeRequest = function(method, url, headers, data, useSession) {
        var defer = Q.defer();
        $.ajax({
            url: url,
            method: method,
            data: JSON.stringify(data),
            headers: headers,
            success: function(data) {
                defer.resolve(data);
            },
            error: function(error) {
                defer.reject(error);
            }
        });

        return defer.promise;
    };

    Requester.prototype.makeGetRequest = function(url, headers) {
        this.makeRequest('GET', url, headers, null, true);
    };

    Requester.prototype.makePostRequest = function(url, data, headers) {
        this.makeRequest('POST', url, headers, data, true);
    };

    Requester.prototype.makeLoginRequest = function(url, data, headers) {
        this.makeRequest('POST', url, headers, data, false);
    };

    Requester.prototype.makePutRequest = function(url, data, headers) {
        this.makeRequest('PUT', url, headers, data, true);
    };

    Requester.prototype.makeDeleteRequest = function(url, headers) {
        this.makeRequest('DELETE', url, headers, null, true);
    };

    return {
        MakeGetRequest: makeGetRequest,
        MakePostRequest: makePostRequest,
        MakePutRequest: makePutRequest,
        MakeDeleteRequest: makeDeleteRequest,
        MakeLoginRequest: makeLoginRequest
    }
})();