var app = app || {};

app.TownModel = (function () {
    function TownModel() {
        this.serviceUrl = app.requester.baseUrl + 'appdata/' + app.requester.appId + '/towns';
    }

    TownModel.prototype.getAll = function () {
        app.requester.makeRequest('GET', this.serviceUrl, null, true).then(function (success) {
            sessionStorage['getTowns'] = JSON.stringify(success);
        }, function (error) {
            console.error(error);
        }).done()
    };

    TownModel.prototype.getFor = function (country) {
        var url = this.serviceUrl + '/?query={"Country":"' + country + '"}';
        app.requester.makeRequest('GET', url, null, true).then(function (success) {
            sessionStorage['townsForCountry'] = JSON.stringify(success);
        }, function (error) {
            console.error(error);
        }).done()
    };

    TownModel.prototype.add = function (name, country) {
        var data = {
            Name:name,
            Country:country
        };
        app.requester.makeRequest('POST', this.serviceUrl, data, true).then(function (success) {
            console.log(success);
        }, function(error) {
            console.error(error);
        }).done();
    };

    return TownModel;
})();