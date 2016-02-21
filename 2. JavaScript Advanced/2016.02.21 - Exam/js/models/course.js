var app = app || {};

var Course = (function() {
    function Course(name, numberOfLectures) {
        this.setName(name);
        this.setNumberOfLectures(numberOfLectures);
    }

    Course.prototype.getName = function() {
        return this._name;
    };

    Course.prototype.setName = function(name) {
        if(typeof name != 'string') {
            throw new Error('Invalid string.');
        }

        if(!/^[A-Za-z\s]+$/i.test(name)) {
            throw new Error('Invalid characters, use only latin letters and space.');
        }

        this._name = name;
    };

    Course.prototype.getNumberOfLectures = function() {
        return this._numberOfLectures;
    };

    Course.prototype.setNumberOfLectures = function(numberOfLectures) {
        numberOfLectures = Number(numberOfLectures);
        if(isNaN(numberOfLectures)) {
            throw new Error('Invalid number.');
        }

        this._numberOfLectures = numberOfLectures;
    };

    return Course;
})();

app.course = function(name, numberOfLectures) {
    return new Course(name, numberOfLectures);
};