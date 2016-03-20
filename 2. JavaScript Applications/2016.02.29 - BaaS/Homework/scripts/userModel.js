var app = app || {};

app.UserModel = (function() {
    function UserModel() {
        this.serviceUrl = app.requester.baseUrl + 'user/' + app.requester.appId;
    }

    UserModel.prototype.signUp = function (username, password, email) {
        var requestUrl = this.serviceUrl,
            data = {
                username: username,
                password: password,
                email: email
            };

        app.requester.makeRequest('POST', requestUrl, data).then(function(success) {
            var result = success;
            sessionStorage['sessionAuth'] = result._kmd.authtoken;
            sessionStorage['userId'] = result._id;
        }, function(error) {
            console.error(error);
        }).done()
    };

    UserModel.prototype.login = function(username, password) {
        var requestUrl = this.serviceUrl + '/login',
            data = {
                username: username,
                password: password
            };

        app.requester.makeRequest('POST', requestUrl, data).then(function(success) {
            sessionStorage['sessionAuth'] = success._kmd.authtoken;
            sessionStorage['userId'] = success._id;
        }, function(error) {
            console.error(error);
        }).done(function() {
            sessionStorage['userToken'] = btoa(username + ':' + password);
        })
    };

    UserModel.prototype.getInfo = function() {
        var requestUrl = this.serviceUrl + '/_me';
        app.requester.makeRequest('GET', requestUrl, null, true).then(function(success) {
            console.log(success);
        }, function(error) {
            console.error(error);
        }).done()
    };

    //UserModel.prototype.logout = function() {
    //    var requestUrl = this.serviceUrl + '/_logout';
    //    app.requester.makeRequest('POST', requestUrl, null, true).then(function(success) {
    //        console.log(success);
    //    }, function(error) {
    //        console.error(error);
    //    }).done()
    //};

    return UserModel;
})();