var app = app || {};

var Party = (function() {
    function Party(options) {
        Event.call(this, options);
        this.setIsCatered(options.isCatered);
        this.setIsBirthday(options.isBirthday);
        this.setOrganiser(options.organiser);
    }

    Party.prototype = Object.create(Event.prototype);
    Party.prototype.constructor = this;

    Party.prototype.checkIsCatered = function() {
        return this._isCatered;
    };

    Party.prototype.setIsCatered = function(isCatered) {
        this._isCatered = isCatered == true;
    };

    Party.prototype.checkIsBirthday = function() {
        return this._isBirthday;
    };

    Party.prototype.setIsBirthday = function(isBirthday) {
        this._isBirthday = isBirthday == true;
    };

    Party.prototype.getOrganiser = function() {
        return this._organiser;
    };

    Party.prototype.setOrganiser = function(organiser) {
        if(!(organiser instanceof Employee)) {
            throw new Error('Invalid organiser, must be an employee.');
        }

        this._organiser = organiser;
    };

    return Party;
})();

app.party = function(options) {
    return new Party(options);
};