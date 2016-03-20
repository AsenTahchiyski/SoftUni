var app = app || {};

app.requester = (function() {
    function Requester(appId, appSecret, baseUrl) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = baseUrl;
    }

    Requester.prototype.get = function(url, useSession) {
        var headers = getHeaders.call(this, useSession);
        return makeRequest('GET', url, headers, null);
    };

    Requester.prototype.post = function(url, data, useSession) {
        var headers = getHeaders.call(this, useSession, data);
        return makeRequest('POST', url, headers, data);
    };

    Requester.prototype.put = function(url, data, useSession) {
        var headers = getHeaders.call(this, useSession, data);
        return makeRequest('PUT', url, headers, data);
    };

    Requester.prototype.delete = function(url, useSession) {
        var headers = getHeaders.call(this, useSession);
        return makeRequest('DELETE', url, headers);
    };

    function makeRequest (method, url, headers, data) {
        var defer = Q.defer();

        $.ajax({
            method: method,
            url: url,
            headers: headers,
            data: JSON.stringify(data) || null,
            success: function(data) {
                defer.resolve(data);
            },
            error: function(data) {
                defer.reject(data);
            }
        });

        return defer.promise;
    }

    function getHeaders(useSession, useJson) {
        var headers = {},
            token;

        if(useJson) {
            headers['Content-Type'] = 'application/json';
        }

        if(useSession) {
            token = sessionStorage['sessionId'];
            headers['Authorization'] = 'Kinvey ' + token;
        } else {
            token = this.appId + ':' + this.appSecret;
            headers['Authorization'] = 'Basic ' + btoa(token);
        }

        return headers;
    }

    return {
        load: function (appId, appSecret, baseUrl) {
            return new Requester(appId, appSecret, baseUrl);
        }
    };
})();