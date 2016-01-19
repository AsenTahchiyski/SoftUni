function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.toString = function() {
        return this.firstName + ' ' + this.lastName + '(age ' + this.age + ')';
    }
}

function groupBy(criteria, array) {
    var result = {};
    array.forEach(function(p) {
        var critValue = p[criteria];
        if(result[critValue] == undefined) {
            result[critValue] = [];
        }

        result[critValue].push(p);
    });

    return result;
}

var people = [
    new Person("Scott", "Guthrie", 38),
    new Person("Scott", "Johns", 36),
    new Person("Scott", "Hanselman", 39),
    new Person("Jesse", "Liberty", 57),
    new Person("Jon", "Skeet", 38)
];
var criteria = 'lastName';
var grouped = groupBy(criteria, people);

for (var property in grouped) {
    if (grouped.hasOwnProperty(property)) {
        console.log('Group ' + property + ': [' + grouped[property].join(', ') + ']');
    }
}