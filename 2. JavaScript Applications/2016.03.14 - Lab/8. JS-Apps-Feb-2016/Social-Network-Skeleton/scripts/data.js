var app = app || {};

app.data = (function() {
    var baseUrl = 'https://baas.kinvey.com/',
        appId = 'kid_bJyOWsc_JW',
        appSecret = 'c680092361c942e9a61846aa7a2af3eb';

    var credentials = (function() {
        function getHeaders(contentType, useSession) {
            var result = {};
            if(contentType) {
                result['Content-Type'] = 'application/json';
            }

            if(useSession) {
                result['Authorization'] = 'Basic use basic kinvey credentials';
            } else {
                result['Authorization'] = 'Kinvey use kinvey appId & pass';
            }

            return result;
        }

        function getSessionToken() {
            return sessionStorage['sessionToken'];
        }

        function setSessionToken() {
            return sessionStorage['sessionToken'];
        }

        function getUserId() {
            return sessionStorage['userId'];
        }

        function setUserId() {
            return sessionStorage['userId'];
        }

        function getUserName() {
            return sessionStorage['userName'];
        }

        function setUserName() {
            return sessionStorage['userName'];
        }

        function clearStorage() {
            sessionStorage.clear();
        }

    })();

    var users = (function() {
        function login(username, password) {
            var url = baseUrl + 'user/' + appId,
                data = {
                    username: username,
                    password: password
                },
                headers = credentials.getHeaders();
            app.ajaxRequester.MakeLoginRequest(url, data, headers);
        }
    })();

    var posts = (function() {

    })();
})();