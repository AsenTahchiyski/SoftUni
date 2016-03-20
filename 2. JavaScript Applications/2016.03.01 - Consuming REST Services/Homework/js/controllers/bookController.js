define(['Q'], function (Q) {
    return (function () {
        function BookController(thisRequester) {
            this._requester = thisRequester;
            this.serviceUrl = thisRequester.baseUrl + 'appdata/' + thisRequester.appId + '/books';
        }

        BookController.prototype.getAll = function () {
            var defer = Q.defer();
            this._requester.makeRequest('GET', this.serviceUrl, null, true).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        };

        BookController.prototype.add = function (book) {
            var defer = Q.defer();
            this._requester.makeRequest('POST', this.serviceUrl, book, true).then(function (success) {
                console.log('Added.');
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        };

        BookController.prototype.getByIsbn = function (isbn) {
            var defer = Q.defer(),
                requestUrl = this.serviceUrl + '/?query={"isbn":"' + isbn + '"}';
            this._requester.makeRequest('GET', requestUrl, null, true).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        };

        BookController.prototype.edit = function (id, book) {
            var defer = Q.defer(),
                resourceUrl = this.serviceUrl + '/' + id;
            this._requester.makeRequest('PUT', resourceUrl, book, true).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        };

        BookController.prototype.delete = function (id) {
            var defer = Q.defer(),
                requestUrl = this.serviceUrl + '/' + id;
            this._requester.makeDeleteRequest('DELETE', requestUrl, null, true).then(function (success) {
                defer.resolve(success);
            }, function (error) {
                console.error(error);
                defer.reject(error);
            }).done();

            return defer.promise;
        };

        return BookController;
    })();
});