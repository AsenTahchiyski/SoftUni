var app = app || {};

var Event = (function() {
    function Event(options) {
        this.setTitle(options.title);
        this.setType(options.type);
        this.setDuration(options.duration);
        this.setDate(options.date);
    }

    Event.prototype.getTitle = function() {
        return this._title;
    };

    Event.prototype.setTitle = function(title) {
        if(typeof title != 'string') {
            throw new Error('Invalid string.');
        }

        if(!/^[A-Za-z\s]+$/i.test(title)) {
            throw new Error('Invalid characters, use only latin letters and space.');
        }

        this._title = title;
    };

    Event.prototype.getType = function() {
        return this._type;
    };

    Event.prototype.setType = function(type) {
        if(typeof type != 'string') {
            throw new Error('Invalid string.');
        }

        if(!/^[A-Za-z\s]+$/i.test(type)) {
            throw new Error('Invalid characters, use only latin letters and space.');
        }

        this._type = type;
    };

    Event.prototype.getDuration = function() {
        return this._duration;
    };

    Event.prototype.setDuration = function(duration) {
        duration = Number(duration);
        if(isNaN(duration)) {
            throw new Error('Invalid number.');
        }

        this._duration = duration;
    };

    Event.prototype.getDate = function() {
        return this._date;
    };

    Event.prototype.setDate = function(date) {
        if(!(date instanceof Date)) {
            throw new Error('Invalid date.');
        }

        this._date = date;
    };

    return Event;
})();

// not being returned as it is an abstract module