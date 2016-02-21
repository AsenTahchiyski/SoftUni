var app = app || {};

var Hall = (function() {
    function Hall(name, capacity) {
        this.setName(name);
        this.setCapacity(capacity);
        this.parties = [];
        this.lectures = [];
    }

    Hall.prototype.getName = function() {
        return this._name;
    };

    Hall.prototype.setName = function(name) {
        if(typeof name != 'string') {
            throw new Error('Invalid string.');
        }

        if(!/^[A-Za-z\s]+$/i.test(name)) {
            throw new Error('Invalid characters, use only latin letters and space.');
        }

        this._name = name;
    };

    Hall.prototype.getCapacity = function() {
        return this._capacity;
    };

    Hall.prototype.setCapacity = function(capacity) {
        capacity = Number(capacity);
        if(isNaN(capacity)) {
            throw new Error('Invalid number.');
        }

        this._capacity = capacity;
    };

    Hall.prototype.addEvent = function(event) {
        if(event instanceof Party) {
            this.parties.push(event);
        } else if(event instanceof Lecture) {
            this.lectures.push(event);
        } else {
            throw new Error('Wrong event type.');
        }
    };

    return Hall;
})();

app.hall = function(name, capacity) {
    return new Hall(name, capacity);
};