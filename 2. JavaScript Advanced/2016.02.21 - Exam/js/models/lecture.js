var app = app || {};

var Lecture = (function() {
    function Lecture(options) {
        Event.call(this, options);
        this.setTrainer(options.trainer);
        this.setCourse(options.course);
    }

    Lecture.prototype = Object.create(Event.prototype);
    Lecture.prototype.constructor = this;

    Lecture.prototype.getTrainer = function() {
        return this._trainer;
    };

    Lecture.prototype.setTrainer = function(trainer) {
        if(!(trainer instanceof Trainer)) {
            throw new Error('Invalid trainer.');
        }

        this._trainer = trainer;
    };

    Lecture.prototype.getCourse = function() {
        return this._course;
    };

    Lecture.prototype.setCourse = function(course) {
        if(!(course instanceof Course)) {
            throw new Error('Invalid course.');
        }

        this._course = course;
    };

    return Lecture;
})();

app.lecture = function(options) {
    return new Lecture(options);
};