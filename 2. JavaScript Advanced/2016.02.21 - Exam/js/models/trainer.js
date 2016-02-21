var app = app || {};

var Trainer = (function() {
    function Trainer(name, workHours) {
        Employee.call(this, name, workHours);
        this.courses = [];
        this.feedbacks = [];
    }

    Trainer.prototype = Object.create(Employee.prototype);
    Trainer.prototype.constructor = this;

    Trainer.prototype.addFeedback = function(feedback) {
        if(typeof feedback === 'string') {
            this.feedbacks.push(feedback);
        } else {
            throw new Error('Incorrect feedback format.')
        }
    };

    Trainer.prototype.addCourse = function(course) {
        if(course instanceof Course) {
            this.courses.push(course);
        } else {
            throw new Error('Incorrect course format.');
        }
    };

    return Trainer;
})();

app.trainer = function(name, workHours) {
    return new Trainer(name, workHours);
};