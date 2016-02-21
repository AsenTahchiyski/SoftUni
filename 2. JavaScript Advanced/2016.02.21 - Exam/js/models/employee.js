var app = app || {};

var Employee = (function() {
    function Employee(name, workHours) {
        this.setName(name);
        this.setWorkHours(workHours);
    }

    Employee.prototype.getName = function() {
        return this._name;
    };

    Employee.prototype.setName = function(name) {
        if(typeof name != 'string') {
            throw new Error('Invalid string.');
        }

        if(!/^[A-Za-z\s]+$/i.test(name)) {
            throw new Error('Invalid characters, use only latin letters and space.');
        }

        this._name = name;
    };

    Employee.prototype.getWorkhours = function() {
        return this._workHours;
    };

    Employee.prototype.setWorkHours = function(workHours) {
        workHours = Number(workHours);
        if(isNaN(workHours)) {
            throw new Error('Invalid number.');
        }

        this._workHours = workHours;
    };

    return Employee;
})();

app.employee = function(name, workHours) {
    return new Employee(name, workHours);
};