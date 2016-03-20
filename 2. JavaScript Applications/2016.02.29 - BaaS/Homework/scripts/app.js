var app = app || {};

app.requester.config('kid_WJDMgxMaCx', '5791d61c584041a19a6ea1e78791ec94');
var userModel = new app.UserModel(),
    countryModel = new app.CountryModel(),
    townModel = new app.TownModel();

userModel.login('pesho', '1234');
//userModel.getInfo();

function addCountryToHTML(name) {
    var lineItem = $('<li>');
    var editButton = $('<button>Edit</button>');
    editButton.on('click', function() {
        var newValue = $('<input type="text">').addClass(name);
        var confirm = $('<button>Update</button>').addClass('confirm' + name);
        confirm.on('click', function() {
            countryModel.edit(name, newValue.val());
            $('.' + name)[0].remove();
            $('.confirm' + name)[0].remove();
        });
        var lineItem = $('.' + name);
        lineItem.append(newValue);
        lineItem.append(confirm);
    });
    var deleteButton = $('<button>Delete</button>');
    deleteButton.on('click', function() {
        countryModel.delete(name);
        $('.' + name).remove();
    });
    var label = $('<span>' + name + '</span>');
    lineItem.append(editButton);
    lineItem.append(deleteButton);
    lineItem.append(label);
    lineItem.on('click', function() {
        townModel.getFor(name);
        setTimeout(function() {
            var towns = JSON.parse(sessionStorage.townsForCountry);
            var container = $('#town-list');
            container.empty();
            for (var i = 0; i < towns.length; i++) {
                var town = towns[i];
                var lineItem = $('<li>' + town.Name + '</li>');
                container.append(lineItem);
            }
        }, 1000);
    });
    lineItem.addClass(name);
    return lineItem;
}

//function addTownToHTML(name, country) {
//    var lineItem = $('<li>');
    //var editButton = $('<button>Edit</button>');
    //editButton.on('click', function() {
    //    var newValue = $('<input type="text">').addClass(name);
    //    var confirm = $('<button>Update</button>').addClass('confirm' + name);
    //    confirm.on('click', function() {
    //        townModel.edit(name, newValue.val());
    //        $('.' + name)[0].remove();
    //        $('.confirm' + name)[0].remove();
    //    });
    //    var lineItem = $('.' + name);
    //    lineItem.append(newValue);
    //    lineItem.append(confirm);
    //});
//    var deleteButton = $('<button>Delete</button>');
//    deleteButton.on('click', function() {
//        townModel.delete(name, country);
//        $('.' + name + country).remove();
//    });
//    var label = $('<span>' + name + '</span>');
//    //lineItem.append(editButton);
//    lineItem.append(deleteButton);
//    lineItem.append(label);
//    lineItem.on('click', function() {
//        townModel.getFor(name, country);
//        setTimeout(function() {
//            var towns = JSON.parse(sessionStorage.townsForCountry);
//            var container = $('#town-list');
//            container.empty();
//            for (var i = 0; i < towns.length; i++) {
//                var town = towns[i];
//                var lineItem = $('<li>' + town.Name + '</li>');
//                container.append(lineItem);
//            }
//        }, 1000);
//    });
//    lineItem.addClass(name + country);
//    return lineItem;
//}

var countryLoadButton = $('#loadCountries');
countryLoadButton.on('click', function() {
    countryModel.getAll();
    var countries = JSON.parse(sessionStorage.getCountries);
    var container = $('#country-list');
    for (var i = 0; i < countries.length; i++) {
        var country = countries[i];
        var lineItem = addCountryToHTML(country.Name);
        container.append(lineItem);
    }
});

var townLoadButton = $('#loadTowns');
townLoadButton.on('click', function() {
    townModel.getAll();
    var towns = JSON.parse(sessionStorage.getTowns);
    var container = $('#town-list');
    container.empty();
    for (var i = 0; i < towns.length; i++) {
        var town = towns[i];
        var lineItem = $('<li>' + town.Name + '</li>');
        container.append(lineItem);
    }
});

var addCountryButton = $('#addCountries');
addCountryButton.on('click', function() {
    var nameInput = $('#add-country');
    if(nameInput) {
        countryModel.add(nameInput.val());
        var lineItem = addCountryToHTML(nameInput.val());
        $('#country-list').append(lineItem);
    }
});
//userModel.logout();