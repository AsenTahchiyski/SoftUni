"use strict";
var Person = (function () {
    var names;
    function Person(firstName, lastName) {
        this._firstName = firstName;
        this._lastName = lastName;
    }

    Person.prototype = {
        get fullName() {
            return this._firstName + " " + this._lastName;
        },

        set fullName(name) {
            names = name.split(" ");
            this._firstName = names[0];
            this._lastName = names[1];
        }
    };

    return Person;
})();

var person = new Person("Peter", "Jackson");
// Getting values
//console.log(person._firstName);
//console.log(person._lastName);
//console.log(person.fullName);

// Changing values
//person._firstName = "Michael";
//console.log(person._firstName);
//console.log(person.fullName);
//person._lastName = "Williams";
//console.log(person._lastName);
//console.log(person.fullName);

// Changing the full name should work too
person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person._firstName);
console.log(person._lastName);