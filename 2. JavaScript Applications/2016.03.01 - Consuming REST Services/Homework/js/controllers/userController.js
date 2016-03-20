define(['Q'], function (Q) {
    return (function () {
        function UserController(thisRequester) {
            this.serviceUrl = thisRequester.baseUrl + 'user/' + thisRequester.appId;
            this._requester = thisRequester;
        }

        UserController.prototype.signUp = function (username, password) {
            var defer = Q.defer(),
                requestUrl = this.serviceUrl,
                data = {
                    username: username,
                    password: password
                };

            this._requester.makeRequest('POST', requestUrl, data).then(function (success) {
                sessionStorage['sessionAuth'] = success._kmd.authtoken;
                sessionStorage['userId'] = success._id;
                defer.resolve();
            }, function (error) {
                console.error(error);
                defer.reject();
            }).done();

            return defer.promise;
        };

        UserController.prototype.login = function (username, password) {
            var defer = Q.defer(),
                requestUrl = this.serviceUrl + '/login',
                data = {
                    username: username,
                    password: password
                };

            this._requester.makeRequest('POST', requestUrl, data).then(function (success) {
                sessionStorage['sessionAuth'] = success._kmd.authtoken;
                sessionStorage['userId'] = success._id;
                sessionStorage['userToken'] = btoa(username + ':' + password);
                defer.resolve();
            }, function (error) {
                console.error(error);
                defer.reject();
            }).done();

            return defer.promise;
        };

        UserController.prototype.getInfo = function () {
            var defer = Q.defer(),
                requestUrl = this.serviceUrl + '/_me';
            this._requester.makeRequest('GET', requestUrl, null, true).then(function (success) {
                console.log(success);
                defer.resolve();
            }, function (error) {
                console.error(error);
                defer.reject();
            }).done();

            return defer.promise;
        };

        UserController.prototype.logout = function () {
            var defer = Q.defer(),
                requestUrl = this.serviceUrl + '/_logout';
            this._requester.makeRequest('POST', requestUrl, null, true).then(function (success) {
                console.log(success);
                defer.resolve();
            }, function (error) {
                console.error(error);
                defer.reject();
            }).done();

            return defer.promise;
        };

        return UserController;
    })();
});