var app = app || {};

app.CountryModel = (function () {
    function CountryModel() {
        this.serviceUrl = app.requester.baseUrl + 'appdata/' + app.requester.appId + '/countries';
    }

    CountryModel.prototype.getAll = function () {
        app.requester.makeRequest('GET', this.serviceUrl, null, true).then(function (success) {
            sessionStorage['getCountries'] = JSON.stringify(success);
        }, function (error) {
            console.error(error);
        }).done()
    };

    CountryModel.prototype.add = function(name) {
        var newCountry = {"Name":name};
        app.requester.makeRequest('POST', this.serviceUrl, newCountry, true);
    };

    CountryModel.prototype.delete = function(name) {
        var url = this.serviceUrl + '/?query={"Name":"' + name + '"}';
        app.requester.makeRequest('DELETE', url, null);
    };

    CountryModel.prototype.getByName = function(name) {
        var url = this.serviceUrl + '/?query={"Name":"' + name + '"}';
        app.requester.makeRequest('GET', url, null, true).then(function (success) {
            sessionStorage['currentCountryDetails'] = JSON.stringify(success);
        }, function (error) {
            console.error(error);
        }).done()
    };

    CountryModel.prototype.edit = function(oldName, newName) {
        this.getByName(oldName);
        var countryDetails = JSON.parse(sessionStorage.currentCountryDetails);
        var id = countryDetails[0]._id;
        var url = this.serviceUrl + '/' + id;
        var updated = {"Name":newName};
        app.requester.makeRequest('PUT', url, updated, true);
    };

    return CountryModel;
})();