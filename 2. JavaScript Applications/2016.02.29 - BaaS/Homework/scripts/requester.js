// copied from Bogomil's lecture, delete method implemented by me
var app = app || {};

app.requester = (function() {
    function Requester(appId, appSecret) {
        this.appId = appId;
        this.appSecret = appSecret;
        this.baseUrl = 'https://baas.kinvey.com/';
    }

    Requester.prototype.makeRequest = function(method, url, data, useSession) {
        var token,
            defer = Q.defer(),
            options = {
                method: method,
                url: url,
                headers: {
                    'Content-Type': method != 'DELETE' ? 'application/json' : undefined
                },
                data: JSON.stringify(data),
                success: function(data) {
                    defer.resolve(data);
                },
                error: function(error) {
                    defer.reject(error);
                }
            };

        if(method != 'DELETE') {
            if(!useSession) {
                token = this.appId + ':' + this.appSecret;
                options.beforeSend = function(xhr) {
                    xhr.setRequestHeader('Authorization', 'Basic ' + btoa(token));
                };
            } else {
                token = sessionStorage['sessionAuth'];
                options.beforeSend = function(xhr) {
                    xhr.setRequestHeader('Authorization', 'Kinvey ' + token);
                };
            }
        } else {
            token = sessionStorage.userToken;
            options.beforeSend = function(xhr) {
                xhr.setRequestHeader('Authorization', 'Basic ' + sessionStorage.userToken);
            }
        }

        $.ajax(options);

        return defer.promise;
    };

    return {
        config: function(appId, appSecret) {
            app.requester = new Requester(appId, appSecret);
        }
    }
})();